using UnityEngine;
using UnityEngine.AI;


public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float agroDistance;
    [SerializeField] public float attackDistance;
    Transform target;

    BaseState currentState;
    public IdleState idleState = new IdleState();
    public AgroState agroState = new AgroState();
    public AttackState attackState = new AttackState();

    public void SwitchState(BaseState newState)
    {
        if(currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        currentState.EnterState(this);
    }

    private void Start()
    {
        
        SwitchState(idleState);
    }

    private void Update()
    {
        SetDestination(player);
        navMeshAgent.destination = target.position;
        currentState.UpdateState(this);
    }

    public void SetSpeed(float newSpeed)
    {
        navMeshAgent.speed = newSpeed;
    }

    public void SetDestination(Transform newDestination)
    {
        target = newDestination;
    }

    public float DistanceToTarget()
    {
        return (transform.position - target.position).magnitude;
    }

    public void OnAnimatorMove()
    {
        if (navMeshAgent != null)
        {
            transform.position = navMeshAgent.nextPosition;
        }
    }
}
