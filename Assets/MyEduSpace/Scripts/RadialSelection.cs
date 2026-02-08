using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;   

public class RadialSelection : MonoBehaviour
{

    public InputActionProperty spawnAction;

    [Range(2,10)]
    public int numberOfRadialPart;
    public GameObject radialPartPrefab;
    public Transform radialPartCanvas;
    public float angleBetweenPart = 10;
    public Transform handTransform;
    public List<Color> colors;


    public UnityEvent<int> onPartSelected;

    private List<GameObject> spawnedParts = new List<GameObject>();
    private int currentSelectedRadialPart = -1;

    void Start()
    {
        
    }

    void OnEnable()
    {
        if (spawnAction != null && spawnAction.action != null)
            spawnAction.action.Enable();
    }

    void OnDisable()
    {
        if (spawnAction != null && spawnAction.action != null)
            spawnAction.action.Disable();
    }

    void Update()
    {
        if (spawnAction == null || spawnAction.action == null)
            return;

        var action = spawnAction.action;

        if (action.WasPressedThisFrame())
        {
            SpawnRadialPart();
        }

        if (action.IsPressed())
        {
            GetSelectedRadialPart();
        }

        if (action.WasReleasedThisFrame())
        {
            HideAndTriggerSelected();
        }
    }


    public void HideAndTriggerSelected()
    {
        onPartSelected.Invoke(currentSelectedRadialPart);
        radialPartCanvas.gameObject.SetActive(false);
    }

    public void GetSelectedRadialPart()
    {
        Vector3 centerToHand = handTransform.position - radialPartCanvas.position;
        Vector3 centerToHandProjected = Vector3.ProjectOnPlane(centerToHand, radialPartCanvas.forward);

        float angle = Vector3.SignedAngle(radialPartCanvas.up, centerToHandProjected, -radialPartCanvas.forward);

        if(angle < 0) angle += 360;

        currentSelectedRadialPart = (int) (angle * numberOfRadialPart / 360);

        for (int i = 0; i < spawnedParts.Count; i++)
        {
            if (i == currentSelectedRadialPart)
            {
                //spawnedParts[i].GetComponent<Image>().color = Color.yellow;
                spawnedParts[i].transform.localScale = 1.3f * Vector3.one;
            }
            else
            {
                //spawnedParts[i].GetComponent<Image>().color = Color.white;
                spawnedParts[i].transform.localScale = Vector3.one;
            }
        }
    }


    public void SpawnRadialPart()
    {
        radialPartCanvas.gameObject.SetActive(true);
        radialPartCanvas.position = handTransform.position;
        radialPartCanvas.rotation = handTransform.rotation;

        foreach(var item in spawnedParts)
        {
            Destroy(item);
        }

        spawnedParts.Clear();

        for (int i = 0; i < numberOfRadialPart; i++)
        {
            float angle = -i * 360 / numberOfRadialPart - angleBetweenPart/2;
            Vector3 radialPartEulerAngle = new Vector3(0, 0, angle);

            GameObject spawnedRadialPart = Instantiate(radialPartPrefab, radialPartCanvas);
            spawnedRadialPart.transform.position = radialPartCanvas.position;
            spawnedRadialPart.transform.localEulerAngles = radialPartEulerAngle;

            //spawnedRadialPart.GetComponent<Image>().fillAmount = (1 / (float)numberOfRadialPart) - (angleBetweenPart/360);

            var img = spawnedRadialPart.GetComponent<Image>();
            img.fillAmount = (1f / (float)numberOfRadialPart) - (angleBetweenPart / 360f);

            // colore manuale dalla lista
            if (colors != null && colors.Count > i)
            {
                img.color = colors[i];
            }

            spawnedParts.Add(spawnedRadialPart);
        }
    }
}
