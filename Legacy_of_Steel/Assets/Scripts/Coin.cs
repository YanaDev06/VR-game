using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private string targetTag = "VRController";
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Coin] Касание! Объект: {other.gameObject.name}, Тег: {other.tag}");

        if (isCollected) return;
        if (!other.CompareTag(targetTag)) return;

        isCollected = true;
        Debug.Log("[Coin] Совпадение тега! Пытаюсь начислить очки...");

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddScore(10);
        else
            Debug.LogError("[Coin] ScoreManager.Instance == NULL! Проверьте иерархию.");

        // Не Destroy, а деактивация (стабильнее в VR)
        gameObject.SetActive(false);
    }
}