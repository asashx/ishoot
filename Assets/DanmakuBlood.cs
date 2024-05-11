using UnityEngine;

namespace DanmakU
{
    public class DestroyDanmakuCollider : MonoBehaviour
    {
        public DanmakuCollider Collider;
        private int destroyedDanmakuCount = 0;
        private const int danmakuToDestroy = 3;
        private bool gameEnded = false;

        void Update()
        {
            
        }

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
            if (gameEnded ) return;

            foreach (var collision in collisions)
            {
                collision.Danmaku.Destroy();
                destroyedDanmakuCount++;
            }

            if (destroyedDanmakuCount >= danmakuToDestroy)
            {
                EndGame();
            }
           
        }

        private void EndGame()
        {
            Debug.Log("Game Over!");
            Destroy(gameObject); // 销毁引用该脚本的物体
            gameEnded = true;
        }

        void Reset()
        {
            Collider = GetComponent<DanmakuCollider>();
        }
    }
}
