using UnityEngine;

public class MarkerSpawner : MonoBehaviour
{
    public GameObject markerPrefab;         // prefab Marker (che contiene Tip)
    public Transform cameraTransform;       
    public float distanceFromCamera = 0.5f;
    public RadialSelection radialSelection; 

    GameObject spawnedMarker;
    SetMaterialMarker tipMaterialMarker;

    bool listenerAdded = false;

    public void SpawnOrRecenterMarker()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (cameraTransform == null || markerPrefab == null || radialSelection == null)
        {
            Debug.LogWarning("MarkerSpawner: manca cameraTransform, markerPrefab o radialSelection");
            return;
        }

        Vector3 pos = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
        Quaternion rot = Quaternion.LookRotation(cameraTransform.forward, Vector3.up);

        if (spawnedMarker == null)
        {
            // crea il marker
            spawnedMarker = Instantiate(markerPrefab, pos, rot);

            // trova il Tip del marker appena creato
            tipMaterialMarker = spawnedMarker.GetComponentInChildren<SetMaterialMarker>();

            // collega la ruota al Tip 
            if (!listenerAdded)
            {
                radialSelection.onPartSelected.AddListener(tipMaterialMarker.SetMaterial);
                listenerAdded = true;
            }
        }
        else
        {
            // riposiziona
            spawnedMarker.transform.SetPositionAndRotation(pos, rot);
        }
    }

    void OnColorSelected(int index)
    {
        if (tipMaterialMarker != null)
            tipMaterialMarker.SetMaterial(index);
    }

    public void DestroyMarker()
    {
        if (spawnedMarker != null)
        {
            Destroy(spawnedMarker);
            spawnedMarker = null;
            tipMaterialMarker = null;
        }

        if (listenerAdded && radialSelection != null)
        {
            radialSelection.onPartSelected.RemoveListener(OnColorSelected);
            listenerAdded = false;
        }
    }
}



