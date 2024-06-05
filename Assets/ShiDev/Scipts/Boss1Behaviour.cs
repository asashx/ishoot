using UnityEngine;

public class Boss1Behaviour : MonoBehaviour {
    public int health; // Boss 的生命值
    public float backToInitialSpeed = 3f; // Boss 回到初始位置的速度
    // 定义 Boss 的各个阶段
    public enum BossPhase {
        Phase1,
        Phase2,
        Phase3
    }

    public BossPhase currentPhase; // 当前 Boss 的阶段

    private Vector3 initialPosition; // Boss 的初始位置
    private bool isInvincible = false; // 是否处于无敌状态

    void Start() {
        currentPhase = BossPhase.Phase1;
        initialPosition = transform.position; // 记录 Boss 的初始位置
    }

    void Update() {
        // 根据当前阶段执行相应的行为
        switch (currentPhase) {
            case BossPhase.Phase1:
                Phase1Behaviour();
                break;
            // case BossPhase.Phase2:
            //     Phase2Behaviour();
            //     break;
            // case BossPhase.Phase3:
            //     Phase3Behaviour();
            //     break;
        }

        // 检查是否需要切换到下一个阶段
        CheckPhaseTransition();
    }

    void PhaseTransitionInit() {
        // 移动到初始位置，移动时无敌，移动到位置后解除
        isInvincible = true;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, Time.deltaTime * backToInitialSpeed);
        if (transform.position == initialPosition) {
            isInvincible = false;
        }  
    }

    // 第一阶段的行为
    void Phase1Behaviour() {
        // 实现第一阶段的行为逻辑
        if (isInvincible) {
            // 如果处于无敌状态，执行位移向初始点的逻辑
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, Time.deltaTime * 3f); // 假设每秒位移3个单位
            if (transform.position == initialPosition) {
                // 已经回到初始点，结束无敌状态
                isInvincible = false;
            }
        } else {
            // 否则，执行第一阶段的其他行为逻辑
        }
    }

    // 第二阶段的行为
    // void Phase2Behaviour() {
    //     // 实现第二阶段的行为逻辑
    //     // 在这里可以定义 Boss 第二阶段的移动规律
    // }

    // 第三阶段的行为
    // void Phase3Behaviour() {
    //     // 实现第三阶段的行为逻辑
    //     // 在这里可以定义 Boss 第三阶段的移动规律
    // }

    // 检查阶段切换条件
    void CheckPhaseTransition() {
        // 根据血量切换阶段
        if (health <= 0) {
            Die(); // 如果生命值小于等于0，执行死亡逻辑
            return; // 已经死亡，不再执行后续逻辑
        }

        // 根据血量判断切换到下一个阶段
        if (health < 50) { // 例如，当血量小于50时切换到下一个阶段
            TransitionToNextPhase();
        }
    }

    // 切换到下一个阶段时的行为
    void TransitionToNextPhase() {
        // 设置下一个阶段并执行相应的行为
        switch (currentPhase) {
            case BossPhase.Phase1:
                // 切换到第二阶段时，设置无敌状态并重置位置
                TransitionPhase(BossPhase.Phase2);
                break;
            case BossPhase.Phase2:
                // 切换到第三阶段时，设置无敌状态并重置位置
                TransitionPhase(BossPhase.Phase3);
                break;
            case BossPhase.Phase3:
                // 已经是最后一个阶段，无需额外处理
                break;
        }
    }

    // 转换到指定阶段的行为
    void TransitionPhase(BossPhase nextPhase) {
        // 设置下一个阶段并执行相应的行为
        currentPhase = nextPhase;
        isInvincible = true; // 设置为无敌状态
        transform.position = initialPosition; // 移动到初始点
    }

    // 受到伤害时的行为
    void TakeDamage(int damage) {
        if (!isInvincible) {
            health -= damage; // 扣除生命值
            if (health <= 0) {
                Die(); // 如果生命值小于等于0，执行死亡逻辑
            }
        }
    }

    // 死亡时的行为
    void Die() {
        // 实现 Boss 死亡时的行为逻辑
        // 比如播放死亡动画、销毁对象等
    }
}
