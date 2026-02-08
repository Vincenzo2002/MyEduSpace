using UnityEngine;
using Unity.XR.CoreUtils;                 

public class JoinTeleport : MonoBehaviour
{
    [Header("References")]
    public XROrigin xrOrigin;             
    public Transform target;              // il punto di arrivo (StartPos)

    public void TeleportNow()
    {
        if (!xrOrigin || !target) return;

        var cc = xrOrigin.GetComponent<CharacterController>();
        if (cc) cc.enabled = false;

        xrOrigin.MoveCameraToWorldLocation(target.position);
        xrOrigin.MatchOriginUpCameraForward(target.up, target.forward);

        if (cc) cc.enabled = true;
    }
}

