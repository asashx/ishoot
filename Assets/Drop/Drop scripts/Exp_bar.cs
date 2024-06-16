using UnityEngine;
using UnityEngine.UI;
using DanmakU;

public class ExperienceBar : MonoBehaviour
{
    public Image Bar; // UI Image 组件，用于显示经验条
    private PlayerExperience playerExperience; // 引用玩家的经验组件

    private GameObject player; // 引用玩家对象
    private float maxExperience = 100; // 最大经验值
    private float _lerpSpeed = 3; // 过渡速度

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player object with tag 'Player' not found in the scene.");
            return; // 如果没有找到 Player 对象，停止进一步执行
        }

        // 获取 PlayerExperience 组件
        playerExperience = player.GetComponent<PlayerExperience>();

        // 初始化经验条的当前经验值和最大经验值
        UpdateExpBar();
    }

    private void Update()
    {
        // 持续更新经验条显示
        ExpFiller();
    }

    private void ExpFiller()
    {
        // 使用 Lerp 平滑过渡经验条的填充效果
        Bar.fillAmount = Mathf.Lerp(Bar.fillAmount, (float)playerExperience.currentExperience / maxExperience, _lerpSpeed * Time.deltaTime);
    }

    private void UpdateExpBar()
    {
        // 更新当前经验值和最大经验值
        playerExperience = player.GetComponent<PlayerExperience>();
        maxExperience = playerExperience.experienceToLevelUp;
    }
}
