using UnityEngine;

public class AttackState: BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);

    }
    public override void ExitState(EnemyStateManager manager)
    {

        manager.SetSpeed(0);
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        Debug.Log("Атакую");
        if (manager.DistanceToTarget() >= manager.agroDistance)
        {
            manager.SwitchState(manager.agroState);
            return;
        }
    }
}
