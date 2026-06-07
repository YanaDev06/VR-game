using UnityEngine;

public class VRPlayerManager : MonoBehaviour
{
    public static VRPlayerManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TeleportTo(Vector3 newPosition, Quaternion newRotation)
    {
        // Перемещаем весь XR Origin
        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}