using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabParenter : MonoBehaviour
{
    private bool isHeld = false;
    private IXRInteractor currentInteractor;

    public void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Взял катану");
        isHeld = true;
        currentInteractor = args.interactorObject;

        // Родительский объект - контроллер
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
        args.interactableObject.transform.localPosition = Vector3.zero;
        args.interactableObject.transform.localRotation = Quaternion.identity;

        // ВАЖНО: Сохраняем катану при загрузке сцены
        // ИСПРАВЛЕНИЕ: используем .transform.gameObject
        GameObject katanaGO = args.interactableObject.transform.gameObject;

        if (!katanaGO.scene.name.Contains("DontDestroyOnLoad"))
        {
            DontDestroyOnLoad(katanaGO);
            Debug.Log("Катана сохранена между сценами");
        }
    }

    public void OnUngrab(SelectExitEventArgs args)
    {
        Debug.Log("Отпустил катану");
        isHeld = false;
        currentInteractor = null;

        // Отвязываем от контроллера
        args.interactableObject.transform.SetParent(null);
    }
}