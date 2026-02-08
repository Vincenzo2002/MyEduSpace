using UnityEngine;

[DisallowMultipleComponent]
public class SpawnPlacement : MonoBehaviour
{
    public enum Mode { FloorSnap, WallSnap, EyeLevel, FixedY }

    [Header("Modalità")]
    public Mode mode = Mode.FloorSnap;

    [Header("Offset verticale finale (sempre applicato)")]
    public float offsetY = 0f;           

    [Header("Solo FixedY / EyeLevel")]
    public float fixedY = 1.6f;          

    [Header("Solo WallSnap")]
    public float wallBackPadding = 0.01f; // distanza dalla parete 
    public string anchorName = "MountPoint"; 
}

