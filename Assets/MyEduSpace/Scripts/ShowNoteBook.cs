using UnityEngine;

public class ShowNoteBook : MonoBehaviour
{

    [Header("Oggetto da mostrare/nascondere")]
    public GameObject notebook;

    public void ShowNotebook()
    {
        if (notebook != null)
            notebook.SetActive(true);
    }

    public void HideNotebook()
    {
        if (notebook != null)
            notebook.SetActive(false);
    }

    public void ToggleNotebook()
    {
        if (notebook != null)
            notebook.SetActive(!notebook.activeSelf);
    }
}
