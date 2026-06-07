using UnityEngine;

public class VRSpawnPoint : MonoBehaviour
{
    private void Start()
    {
        if (VRPlayerManager.Instance != null)
        {
            VRPlayerManager.Instance.TeleportTo(transform.position, transform.rotation);
        }
    }
}