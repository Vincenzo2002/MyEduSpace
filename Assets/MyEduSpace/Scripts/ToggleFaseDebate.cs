using UnityEngine;


public class ToggleFaseDebate : MonoBehaviour
{
    [Header("GameObject da attivare")]
    [SerializeField] private GameObject objectToEnable;

    [Header("GameObject da disattivare")]
    [SerializeField] private GameObject objectToDisable;

    // Metodo da collegare al bottone
    public void ToggleObjects()
    {
        if (objectToEnable != null)
            objectToEnable.SetActive(true);

        if (objectToDisable != null)
            objectToDisable.SetActive(false);
    }
}

