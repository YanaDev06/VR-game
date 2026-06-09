using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Spin : MonoBehaviour
{
    [Header("Анимация")]
    [SerializeField] private float rotateSpeed = 40f;
    [SerializeField] private float bobAmplitude = 0.08f;
    [SerializeField] private float bobSpeed = 2.5f;

    private Vector3 startPos;
    private float phaseOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        startPos = transform.position;
        phaseOffset = Random.Range(0f, Mathf.PI * 2); // Чтобы монеты не колебались синхронно
    }

    private void Update()
    {
        // 1. Вращение вокруг локальной Y (явно, без Space.Self)
        transform.localRotation *= Quaternion.Euler(0, rotateSpeed * Time.deltaTime, 0);

        // 2. Покачивание (меняем только Y)
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed + phaseOffset) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
