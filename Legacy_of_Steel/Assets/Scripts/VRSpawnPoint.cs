using UnityEngine;
using UnityEngine;
using System.Collections;

public class VRSpawnPoint : MonoBehaviour
{
    private void Start()
    {
       
        StartCoroutine(TeleportWithDelay());
    }

    private IEnumerator TeleportWithDelay()
    {
        
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.1f);

        if (VRPlayerManager.Instance != null)
        {
            VRPlayerManager.Instance.TeleportTo(transform.position, transform.rotation);
            Debug.Log($"Игрок телепортирован в {transform.position}");
        }
        else
        {
            Debug.LogError("VRPlayerManager не найден!");
        }
    }
}
