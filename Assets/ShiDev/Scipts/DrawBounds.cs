using UnityEngine;

namespace DanmakU {
    [ExecuteInEditMode] // 在编辑模式中执行
    public class DrawBounds : MonoBehaviour {
        public DanmakuManager manager; // 引用 DanmakuManager 脚本
        private Bounds2D bounds; // 存储从 DanmakuManager 获取的 Bounds2D 数据

        private void OnDrawGizmos() {
            if (manager != null) {
                // 获取 DanmakuManager 中的 Bounds2D 数据
                bounds = manager.Bounds;

                // 绘制 Bounds2D 的范围
                Gizmos.color = Color.cyan;
                Vector2 min = bounds.Min;
                Vector2 max = bounds.Max;

                // 绘制矩形
                Gizmos.DrawLine(new Vector3(min.x, min.y), new Vector3(max.x, min.y));
                Gizmos.DrawLine(new Vector3(min.x, max.y), new Vector3(max.x, max.y));
                Gizmos.DrawLine(new Vector3(min.x, min.y), new Vector3(min.x, max.y));
                Gizmos.DrawLine(new Vector3(max.x, min.y), new Vector3(max.x, max.y));

                // 在编辑器中强制刷新场景视图
                UnityEditor.SceneView.RepaintAll();
            }
        }
    }
}
