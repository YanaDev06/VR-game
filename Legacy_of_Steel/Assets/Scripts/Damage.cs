using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damageCount = 10;

    public void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.Damage(damageCount);
        }
    }
}
