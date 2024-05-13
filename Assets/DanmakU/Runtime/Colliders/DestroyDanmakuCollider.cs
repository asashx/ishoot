using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanmakU
{

    public class DestroyDanmakuCollider : MonoBehaviour
    {

        public DanmakuCollider Collider;
        public int health = 3; // 物品的初始血量
        public Danmaku specialDanmakuPrefab; // 特定弹幕的预制体

        void OnEnable()
        {
            if (Collider != null)
            {
                Collider.OnDanmakuCollision += OnDanmakuCollision;
            }
        }

        void OnDisable()
        {
            if (Collider != null)
            {
                Collider.OnDanmakuCollision -= OnDanmakuCollision;
            }
        }

        void OnDanmakuCollision(DanmakuCollisionList collisions)
        {
            foreach (var collision in collisions)
            {
                if (collision.Danmaku == specialDanmakuPrefab)
                {
                    collision.Danmaku.Destroy();
                    health--; // 如果碰到特定弹幕，物品血量减一
                }
                if (health <= 0)
                {
                    DestroyItem(); // 如果血量小于等于0，销毁物品
                    break;
                }
            }
        }

        void DestroyItem()
        {
            Debug.Log("Item Destroyed!");
            Destroy(gameObject);
        }

        void Reset()
        {
            Collider = GetComponent<DanmakuCollider>();
        }
    }
}
