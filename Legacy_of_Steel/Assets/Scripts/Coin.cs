using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [Header("Анимация")]
    [SerializeField] private float rotateSpeed = 40f;
    [SerializeField] private float bobAmplitude = 0.08f;
    [SerializeField] private float bobSpeed = 2.5f;

    [Header("Фидбек при подборе")]
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private GameObject pickupVFX; // Префаб с ParticleSystem

    [Header("Настройки")]
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private string controllerTag = "VRController";

    private Vector3 startPos;
    private float phaseOffset;
    private bool isCollected = false;

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

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;
        if (!other.CompareTag(controllerTag)) return;

        isCollected = true;

        // 1. Звук (пространственный, автоматически работает в VR)
        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

        // 2. Визуальный эффект
        if (pickupVFX != null)
            Instantiate(pickupVFX, transform.position, Quaternion.identity);

        // 3. Начисление очков
        ScoreManager.Instance?.AddScore(scoreValue);

        // 4. Деактивация (вместо Destroy, чтобы избежать сборщика мусора во время игры)
        gameObject.SetActive(false);
    }
}