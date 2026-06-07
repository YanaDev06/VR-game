using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    static float damageTimer = 0f;
    float damageCooldown = 0.7f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        damageTimer = 0f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);

        damageTimer += Time.deltaTime;

        if (damageTimer >= damageCooldown)
        {
            damageTimer = 0f;

            Collider[] hits = Physics.OverlapSphere(animator.transform.position, 5f);

            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    PlayerManager.Damage(10);
                    animator.SetBool("IsAttacking", false);
                    animator.SetBool("IsChasing", true);
                    return;
                }
            }
        }

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > 6f)
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}