using UnityEngine;

public class KatanaHitSound : MonoBehaviour
{
    [Header("Настройки")]
    public AudioClip hitClip; 
    public float minHitSpeed = 1f; 

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Dummy"))
        {
           
            if (collision.relativeVelocity.magnitude > minHitSpeed)
            {
                
                AudioSource.PlayClipAtPoint(hitClip, collision.GetContact(0).point);
            }
        }
    }
}