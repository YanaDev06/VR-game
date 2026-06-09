using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        FindActiveCamera();
    }

    void LateUpdate()
    {
       
        if (cameraTransform == null)
        {
            FindActiveCamera();
        }

        if (cameraTransform != null)
        {
            Vector3 targetPosition = new Vector3(cameraTransform.position.x, transform.position.y, cameraTransform.position.z);

            transform.LookAt(targetPosition);
        }
    }

    
    void FindActiveCamera()
    {
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }
}
