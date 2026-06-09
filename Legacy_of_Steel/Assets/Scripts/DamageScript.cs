using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageScript : MonoBehaviour
{
    public int damageAmount = 20;



    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Удар по: " + collision.gameObject.name + " тег: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Враг найден! Наносим урон");
            collision.gameObject.GetComponentInParent<EnemyScript>().TakeDamage(damageAmount);
        }
    }
}