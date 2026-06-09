using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneTransition : MonoBehaviour
{
    
    [SerializeField] private string targetSceneName;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
       
        SceneManager.LoadScene(targetSceneName, LoadSceneMode.Single);
    }
}