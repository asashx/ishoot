using UnityEngine;


namespace DanmakU
{

    public class PlayerExperience : DanmakuBehaviour
    {
        public int currentExperience = 0;
        public int currentLevel = 1;
        public int experienceToLevelUp = 100; // 每次升级所需的经验值
        public DanmakuEmitter danmakuEmitter; // 引用DanmakuEmitter组件

        void Start()
        {
            // 初始化经验和等级
            currentExperience = 0;
            currentLevel = 1;

        }

        public void IncreaseExperience(int amount)
        {
            currentExperience += amount;
            Debug.Log("Experience increased. Current Experience: " + currentExperience);

            // 检查是否需要升级
            while (currentExperience >= experienceToLevelUp)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            currentExperience -= experienceToLevelUp;
            currentLevel++;
            Debug.Log("Level up! Current Level: " + currentLevel);

            if (danmakuEmitter != null)
            {
                // 不同等级有不同效果
                if (currentLevel >= 2 && currentLevel <= 3)
                {
                    // 增加弹道
                    danmakuEmitter.Arc.Count += 5; // 每次升级增加10度的弹道角度，可以根据需要调整
                }
                else if (currentLevel >= 4)
                {
                    // 增加子弹数量
                    danmakuEmitter.FireRate += 10; // 每次升级增加1的发射频率，可以根据需要调整
                }
            }

            // 增加下一次升级所需的经验值，可以调整为你的需求
            experienceToLevelUp = Mathf.RoundToInt(experienceToLevelUp * 1.5f);
        }
    }
}
