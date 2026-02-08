using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MarkerButtonHandler : MonoBehaviour
{
    public MarkerSpawner markerSpawner;
    public float longPressThreshold = 1.0f;   // secondi per considerare "press lungo"

    bool isPressed = false;
    float pressTime = 0f;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        isPressed = true;
        pressTime = Time.time;
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (!isPressed || markerSpawner == null)
            return;

        isPressed = false;

        float duration = Time.time - pressTime;

        if (duration >= longPressThreshold)
        {
            // press lungo -> ELIMINA il marker
            markerSpawner.DestroyMarker();
        }
        else
        {
            // press corto -> SPAWN o RECENTER
            markerSpawner.SpawnOrRecenterMarker();
        }
    }
}
