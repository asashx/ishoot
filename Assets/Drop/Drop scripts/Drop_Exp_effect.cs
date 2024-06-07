using UnityEngine;
namespace DanmakU
{ 

    public class DropItemExperienceIncrease : DanmakuBehaviour
    {
        public int experienceIncreaseAmount = 10; // ���ӵľ���ֵ

        void OnTriggerEnter2D(Collider2D other)
    {
        // �����ײ���Ƿ������ұ�ǩ
        if (other.CompareTag("Player")) // ȷ����Ҷ���ı�ǩ�� "Player"
        {
            // ��ȡ��Ҷ����ϵ� PlayerExperience ���
            PlayerExperience playerExperience = other.GetComponent<PlayerExperience>();
            if (playerExperience != null)
            {
                // ������ҵľ���ֵ
                playerExperience.IncreaseExperience(experienceIncreaseAmount);
            }
            // ���ٵ�����
            Destroy(gameObject);
        }
    }
    }
}