using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class KatanaSceneTransition : MonoBehaviour
{
    [Header("Настройки")]
    public string targetSceneName = "NextScene";

    private bool hasTransitioned = false;

    public void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("✅ [Katana] Метод OnGrab вызван!");

        if (hasTransitioned) return;
        hasTransitioned = true;

        // Сохраняем катану
        if (gameObject.scene.name != "DontDestroyOnLoad")
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("✅ [Katana] Катана сохранена");
        }

        // Ищем и сохраняем XR Origin
        GameObject xrOriginGO = FindXROrigin(args.interactorObject.transform);
        if (xrOriginGO != null)
        {
            if (xrOriginGO.scene.name != "DontDestroyOnLoad")
            {
                DontDestroyOnLoad(xrOriginGO);
                Debug.Log("✅ [Katana] XR Origin сохранен");
            }
        }
        else
        {
            Debug.LogError("❌ [Katana] Не найден XR Origin!");
        }

        // Привязываем катану
        transform.SetParent(args.interactorObject.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // Загружаем сцену
        Debug.Log($"🔄 Загрузка сцены: {targetSceneName}");
        SceneManager.LoadScene(targetSceneName);
    }

    private GameObject FindXROrigin(Transform startTransform)
    {
        Transform current = startTransform;

        while (current != null)
        {
            // Вариант 1: Ищем XROrigin (простой способ)
            var xrOrigin = current.GetComponent<XROrigin>();
            if (xrOrigin != null)
            {
                return current.gameObject;
            }

            // Вариант 2: Ищем по имени объекта (универсальный)
            if (current.name.Contains("XR Origin") || current.name.Contains("XRRig"))
            {
                return current.gameObject;
            }

            current = current.parent;
        }

        return null;
    }
}