using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private int HP = 100;
    public Animator animator;
    public Slider HealthBar;


    void Update()
    {
        HealthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            HealthBar.gameObject.SetActive(false);
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }
}
