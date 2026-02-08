using System.Collections.Generic;
using UnityEngine;

public class SetColorMarker : MonoBehaviour
{
    public List<Color> colors;

    public void SetColor(int i)
    {
        if (colors == null || i < 0 || i >= colors.Count)
            return;

        // Renderer del TIP del MARKER ISTANZIATO
        GetComponent<Renderer>().material.color = colors[i];
    }
}

