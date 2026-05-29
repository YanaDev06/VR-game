using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    private bool collected = false;

    public void Collect()
    {
        if (collected) return;
        collected = true;
        score++;
        if (scoreText != null)
            scoreText.text = "Очки: " + score;
        gameObject.SetActive(false);
    }
}
