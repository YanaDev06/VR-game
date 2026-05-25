using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject loadingScreen;

    public void LoadDojo()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }
}
