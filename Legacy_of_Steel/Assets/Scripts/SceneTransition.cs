using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для работы со сценами

public class SceneTransition : MonoBehaviour
{
    // Имя сцены, куда нужно перейти (задайте в инспекторе)
    [SerializeField] private string targetSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что в триггер вошел именно игрок (у игрока должен быть тег "Player")
        if (other.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Загружаем сцену. SceneMode.Single закрывает текущую сцену.
        SceneManager.LoadScene(targetSceneName, LoadSceneMode.Single);
    }
}