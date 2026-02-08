using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class EnvironmentEditToggle : MonoBehaviour
{
    public GameObject catalogUI;
    bool editMode = true;

    void Start()
    {
        ApplyMode(editMode);
    }

    public void ToggleEditMode()
    {
        editMode = !editMode;
        ApplyMode(editMode);
    }

    void ApplyMode(bool enable)
    {
        // XRGrabInteractable marcati EditableObject
        var grabs = Object.FindObjectsByType<XRGrabInteractable>(FindObjectsSortMode.None);
        foreach (var g in grabs)
            if (g != null && g.GetComponent<EditableObject>())
                g.enabled = enable;

        // Solo SimpleInteractable, non tutti i Behaviour
        var simples = Object.FindObjectsByType<XRSimpleInteractable>(FindObjectsSortMode.None);
        foreach (var s in simples)
            if (s != null && s.GetComponent<EditableObject>())
                s.enabled = enable;

        // UI per tag
        /*var uiObjs = GameObject.FindGameObjectsWithTag(tagUI);
        foreach (var ui in uiObjs)
            if (ui != null)
                ui.SetActive(enable);*/
        
        catalogUI.SetActive(enable);
    }
}



