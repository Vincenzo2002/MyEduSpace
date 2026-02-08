using UnityEngine;

public class SetMaterialMarker : MonoBehaviour
{
    public Material[] materials;

    public void SetMaterial(int i)
    {
        if (materials == null || i < 0 || i >= materials.Length)
            return;

        // cambia il MATERIALE del Tip
        GetComponent<Renderer>().material = materials[i];
    }
}
