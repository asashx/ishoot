using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss1Behaviour : MonoBehaviour
{
    [Header("Boss属性")]
    public int health = 100; // Boss 的生命值
    public float backToInitialSpeed = 3f; // Boss 回到初始位置的速度
    public float moveSpeed = 0.1f; // Boss 移动速度

    [Header("Boss路径")]
    public GameObject[][] phasePathPoints; // Boss 的路径点
    public GameObject[] phase1PathPoints; // 第一阶段的路径点
    public GameObject[] phase2PathPoints; // 第二阶段的路径点
    public GameObject[] phase3PathPoints; // 第三阶段的路径点

    public enum BossPhase
    {
        Phase1,
        Phase2,
        Phase3
    }

    // 存储阶段子物体
    public GameObject[] phaseObjects;
    private BossPhase currentPhase; // 当前 Boss 的阶段

    private Vector3 initialPosition; // Boss 的初始位置
    private bool isInvincible = false; // 是否处于无敌状态
    private bool phaseTransition = false; // 是否处于阶段切换状态
    private int phaseIndex;

    void Start()
    {
        currentPhase = BossPhase.Phase1;
        initialPosition = transform.position; // 记录 Boss 的初始位置
        phaseIndex = 0;
        // 初始化 Boss 的路径点
        phasePathPoints = new GameObject[][] { phase1PathPoints, phase2PathPoints, phase3PathPoints };
        ActivateEmitter(phaseIndex);
    }

    void Update()
    {
        // 根据当前阶段执行相应的行为
        if (!phaseTransition)
        {
            switch (currentPhase)
            {
                case BossPhase.Phase1:
                    Phase1Behaviour();
                    break;
                case BossPhase.Phase2:
                    Phase2Behaviour();
                    break;
                case BossPhase.Phase3:
                    Phase3Behaviour();
                    break;
            }
        }

        // 检查是否需要切换到下一个阶段
        CheckPhaseTransition();
    }

    void Phase1Behaviour()
    {
        // 第一阶段的行为逻辑
        // 比如移动、发射弹幕等
        StartCoroutine(MoveOnPathCoroutine(phase1PathPoints));
    }

    void Phase2Behaviour()
    {
        // 第二阶段的行为逻辑
        // 比如移动、发射弹幕等
        StartCoroutine(MoveOnPathCoroutine(phase2PathPoints));
    }

    void Phase3Behaviour()
    {
        // 第三阶段的行为逻辑
        // 比如移动、发射弹幕等
        StartCoroutine(MoveOnPathCoroutine(phase3PathPoints));
    }

    void ActivateEmitter(int index)
    {
        for (int i = 0; i < phaseObjects.Length; i++)
        {
            if (i == index)
            {
                phaseObjects[i].SetActive(true);
            }
            else
            {
                phaseObjects[i].SetActive(false);
            }
        }
        Debug.Log("Activate emitter " + index);
    }

    void DeactivateEmitter()
    {
        foreach (var obj in phaseObjects)
        {
            obj.SetActive(false);
        }
        Debug.Log("Deactivate emitter");
    }


    // 旋转发射器
    void SpinEmitter()
    {
        // // 获取当前时间
        // float currentTime = Time.time;

        // // 获取发射器的初始旋转角度
        // GameObject emitter = phaseObjects[phaseObjects.Length - phaseCnt];
        // float initialRotation = emitter.transform.rotation.eulerAngles.z;

        // // 计算旋转角度
        // float rotationAngle = Mathf.Pow(Mathf.Round(currentTime - initialRotation), 2);

        // // 旋转发射器
        // emitter.transform.rotation = Quaternion.Euler(0, 0, initialRotation + rotationAngle);

    }
    IEnumerator MoveOnPathCoroutine(GameObject[] path)
    {
        // 如果只有一个路径点，直接移动到该点并停止
        if (path.Length == 1)
        {
            Vector3 targetPosition = path[0].transform.position;
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
                yield return null;
            }
        }
        else
        {
            // 遍历路径点
            int index = 0;
            while (true)
            {
                // 获取当前路径点的位置
                Vector3 targetPosition = path[index].transform.position;

                // 移动直到到达当前路径点
                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
                    yield return null;
                }

                // 循环到下一个路径点
                index = (index + 1) % path.Length;

                // 暂停一段时间再移动到下一个点
                yield return new WaitForSeconds(1f);
            }
        }
    }

    // 检查阶段切换条件
    void CheckPhaseTransition()
    {
        if (!phaseTransition)
        {
            // 根据血量切换阶段
            if (health <= 0 && currentPhase == BossPhase.Phase3)
            {
                Die(); // 如果生命值小于等于0，执行死亡逻辑
                return; // 已经死亡，不再执行后续逻辑
            }

            // 根据血量判断切换到下一个阶段
            if (health < 10 && currentPhase != BossPhase.Phase3)
            {
                TransitionToNextPhase();
            }

            // 测试时，按下空格键手动切换到下一个阶段
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 停止所有移动协程
                StopAllCoroutines();
                TransitionToNextPhase();
            }
        }
    }

    // 切换到下一个阶段时的行为
    void TransitionToNextPhase()
    {
        phaseTransition = true;
        DeactivateEmitter();
        // 设置下一个阶段并执行相应的行为
        switch (currentPhase)
        {
            case BossPhase.Phase1:
                // 切换到第二阶段时，设置无敌状态并重置位置
                StartCoroutine(TransitionPhaseCoroutine(BossPhase.Phase2));
                break;
            case BossPhase.Phase2:
                // 切换到第三阶段时，设置无敌状态并重置位置
                StartCoroutine(TransitionPhaseCoroutine(BossPhase.Phase3));
                break;
            case BossPhase.Phase3:
                // 已经是最后一个阶段，无需额外处理
                break;
        }
    }

    // 使用协程执行阶段转换
    IEnumerator TransitionPhaseCoroutine(BossPhase nextPhase)
    {
        // 设置无敌状态
        isInvincible = true;
        // 重置生命值
        health = 100;

        // 移动到初始位置
        yield return MoveToInitialPosition();

        // 到达初始位置后，取消无敌状态，执行后续逻辑
        isInvincible = false;
        currentPhase = nextPhase;
        phaseTransition = false;
        phaseIndex++;
        ActivateEmitter(phaseIndex);
        Debug.Log("Transition to " + nextPhase);
        Debug.Log("Phase index " + phaseIndex);
    }

    IEnumerator MoveToInitialPosition()
    {
        // 获取初始位置
        Vector3 targetPosition = initialPosition;

        // 移动直到到达初始位置
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // 计算当前位置到目标位置的方向和距离
            Vector3 direction = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);

            // 将对象移动一小段距离
            transform.position += direction * Mathf.Min(Time.deltaTime * backToInitialSpeed, distance);

            // 等待一帧
            yield return null;
        }
    }

    // 受到伤害时的行为
    void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage; // 扣除生命值
            if (health <= 0)
            {
                Die(); // 如果生命值小于等于0，执行死亡逻辑
            }
        }
    }

    // 死亡时的行为
    void Die()
    {
        // 实现 Boss 死亡时的行为逻辑
        // 比如播放死亡动画、销毁对象等
    }
}

