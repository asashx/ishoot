using UnityEngine;
namespace DanmakU
{ 

    public class DropItemExperienceIncrease : DanmakuBehaviour
    {
        public int experienceIncreaseAmount = 10; // 增加的经验值

        void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞体是否具有玩家标签
        if (other.CompareTag("Player")) // 确保玩家对象的标签是 "Player"
        {
            // 获取玩家对象上的 PlayerExperience 组件
            PlayerExperience playerExperience = other.GetComponent<PlayerExperience>();
            if (playerExperience != null)
            {
                // 增加玩家的经验值
                playerExperience.IncreaseExperience(experienceIncreaseAmount);
            }
            // 销毁掉落物
            Destroy(gameObject);
        }
    }
    }
}