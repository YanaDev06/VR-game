using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector3 offset = new Vector3(0f, -0.2f, 1.2f); // X: вбок, Y: вверх/вниз, Z: дистанция
    [SerializeField] private float smoothSpeed = 8f;

    private void LateUpdate()
    {
        if (cameraTransform == null) return;

        // Позиция относительно камеры
        Vector3 targetPos = cameraTransform.position
                          + cameraTransform.forward * offset.z
                          + cameraTransform.up * offset.y
                          + cameraTransform.right * offset.x;

        // Плавное следование
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTransform.rotation, Time.deltaTime * smoothSpeed);
    }
}