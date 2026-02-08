using UnityEngine;
using UnityEngine.UIElements;
using Unity.XR.CoreUtils;   

public class LessonSwitcher : MonoBehaviour
{
    [Header("UI")]
    public UIDocument uiDocument;
    public string btnAulaVuota = "joinAulaVuota";
    public string btnLezioneFrontale = "joinFrontale";
    public string btnLezioneIndividuale = "joinIndividuale";
    public string btnAttivitaGruppo = "joinGruppo";

    [Header("Set di Lezioni")]
    public GameObject aulaVuotaSet;
    public GameObject lezioneFrontaleSet;
    public GameObject lezioneIndividualeSet;
    public GameObject attivitaGruppoSet;

    [Header("Punti di Spawn")]
    public Transform spawnAulaVuota;
    public Transform spawnFrontale;
    public Transform spawnIndividuale;
    public Transform spawnGruppo;

    [Header("Rig del Player")]
    public XROrigin xrOrigin;   

    private GameObject[] _lessonSets;
    private Transform[] _spawns;

    void OnEnable()
    {
        if (!uiDocument)
            uiDocument = GetComponent<UIDocument>();

        var root = uiDocument.rootVisualElement;

        var bAulaVuota    = root.Q<Button>(btnAulaVuota);
        var bFrontale     = root.Q<Button>(btnLezioneFrontale);
        var bIndividuale  = root.Q<Button>(btnLezioneIndividuale);
        var bGruppo       = root.Q<Button>(btnAttivitaGruppo);

        _lessonSets = new GameObject[]
        {
            aulaVuotaSet,
            lezioneFrontaleSet,
            lezioneIndividualeSet,
            attivitaGruppoSet
        };

        _spawns = new Transform[]
        {
            spawnAulaVuota,
            spawnFrontale,
            spawnIndividuale,
            spawnGruppo
        };

        if (bAulaVuota != null)    bAulaVuota.clicked   += () => ShowLesson(0);
        if (bFrontale != null)     bFrontale.clicked    += () => ShowLesson(1);
        if (bIndividuale != null)  bIndividuale.clicked += () => ShowLesson(2);
        if (bGruppo != null)       bGruppo.clicked      += () => ShowLesson(3);

        ShowLesson(0);
    }

    private void ShowLesson(int index)
    {
        // attiva/disattiva i set
        for (int i = 0; i < _lessonSets.Length; i++)
        {
            if (_lessonSets[i] != null)
                _lessonSets[i].SetActive(i == index);
        }

        // teletrasporto corretto della camera
        if (xrOrigin != null && _spawns[index] != null)
        {
            // posizione dello spawn
            xrOrigin.MoveCameraToWorldLocation(_spawns[index].position);

            // orienta l’utente verso la direzione dello spawn
            xrOrigin.MatchOriginUpCameraForward(Vector3.up, _spawns[index].forward);
        }
    }
}
