using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Простой менеджер главного меню.
/// Вешай на пустой GameObject "MenuManager".
/// </summary>
public class MenuManager : MonoBehaviour
{
    [Header("Кнопки — перетащи из Hierarchy")]
    public Button newGameButton;
    public Button trainingButton;
    public Button settingsButton;
    public Button exitButton;

    [Header("Панель настроек")]
    public SettingsPanel settingsPanel;

    [Header("Имена сцен")]
    public string newGameScene   = "GameScene";
    public string trainingScene  = "TrainingScene";

    private void Start()
    {
        if (newGameButton  != null) newGameButton.onClick.AddListener(OnNewGame);
        if (trainingButton != null) trainingButton.onClick.AddListener(OnTraining);
        if (settingsButton != null) settingsButton.onClick.AddListener(OnSettings);
        if (exitButton     != null) exitButton.onClick.AddListener(OnExit);
    }

    public void OnNewGame()  => SceneManager.LoadScene(newGameScene);
    public void OnTraining() => SceneManager.LoadScene(trainingScene);

    public void OnSettings()
    {
        if (settingsPanel != null) settingsPanel.Open();
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
