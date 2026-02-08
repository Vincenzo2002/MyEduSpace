using UnityEngine;

public class MultiButtonLavagneActivator : MonoBehaviour
{
    [Header("GameObjects da controllare (ordine: bottone 1, 2, 3)")]
    [SerializeField] private GameObject[] targets;

    void Start()
    {
        DeactivateAll();
    }

    public void ActivateFirst()
    {
        ActivateOnly(0);
    }

    public void ActivateSecond()
    {
        ActivateOnly(1);
    }

    public void ActivateThird()
    {
        ActivateOnly(2);
    }

    public void DeactivateAll()
    {
        foreach (GameObject go in targets)
        {
            if (go != null)
                go.SetActive(false);
        }
    }

    private void ActivateOnly(int index)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
                targets[i].SetActive(i == index);
        }
    }
}
