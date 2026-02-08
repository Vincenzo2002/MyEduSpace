using UnityEngine;

public class NotebookSpawner : MonoBehaviour
{
    public GameObject notebookPrefab;
    public Transform spawnPoint;

    private GameObject _currentNotebook;

    public void ToggleNotebook()
    {
        if (_currentNotebook == null)
            SpawnNotebook();
        else
            DestroyNotebook();
    }

    public void DestroyNotebook()
    {
        if (_currentNotebook == null)
            return;

        Destroy(_currentNotebook);
        _currentNotebook = null;
    }

    private void SpawnNotebook()
    {
        if (notebookPrefab == null || spawnPoint == null)
            return;

        _currentNotebook = Instantiate(
            notebookPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }

    // quando il bottone viene distrutto → elimina anche il notebook
    private void OnDestroy()
    {
        if (_currentNotebook != null)
            Destroy(_currentNotebook);
    }
}


