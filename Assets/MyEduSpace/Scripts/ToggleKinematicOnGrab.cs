using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class ToggleKinematicOnGrab : MonoBehaviour
{
    Rigidbody rb;
    XRGrabInteractable grab;
    Coroutine kinematicRoutine;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
        grab.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (kinematicRoutine != null)
        {
            StopCoroutine(kinematicRoutine);
            kinematicRoutine = null;
        }

        // mentre lo grabbo: NON kinematic
        rb.isKinematic = false;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        // ogni volta che rilascio, riparte il ciclo
        if (kinematicRoutine != null)
            StopCoroutine(kinematicRoutine);

        kinematicRoutine = StartCoroutine(KinematicDelay());
    }

    IEnumerator KinematicDelay()
    {
        yield return null;
        rb.isKinematic = false;
        yield return new WaitForSeconds(1f);
        rb.isKinematic = true;
        kinematicRoutine = null;
    }
}


