using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        if (scoreText == null)
            Debug.LogError("[ScoreManager] Поле Score Text пустое! Перетащите TMP_Text сюда в инспекторе.");
    }

    public void AddScore(int value)
    {
        currentScore += value;
        UpdateUI();
        Debug.Log($"[ScoreManager] Очки начислены! Текущий счёт: {currentScore}");
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = currentScore.ToString("D6");
    }
}