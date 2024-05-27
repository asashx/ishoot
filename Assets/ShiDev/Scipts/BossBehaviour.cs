using UnityEngine;

public class BossBehaviour : MonoBehaviour {
    public int health; // Boss 的生命值
    // 定义 Boss 的各个阶段
    public enum BossPhase {
        Phase1,
        Phase2,
        Phase3
    }

    public BossPhase currentPhase; // 当前 Boss 的阶段

    void Start() {
        currentPhase = BossPhase.Phase1;
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
            // 可根据需要添加更多阶段的行为
        }

        // 检查是否需要切换到下一个阶段
        CheckPhaseTransition();
    }

    // 第一阶段的行为
    void Phase1Behaviour() {
        // 实现第一阶段的行为逻辑
    }

    // 检查阶段切换条件
    void CheckPhaseTransition() {
        
    }
}
