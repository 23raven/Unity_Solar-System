using UnityEngine;
using UnityEngine.UI;


public class OrbitMiniGame : MonoBehaviour
{
    
    public OrbitDotMovement dot;
    public Image targetZone;
    public System.Action OnWin;
    public RectTransform zoneMask;


    [Header("Zone Settings")]
    public float zoneAngle = 20f; // ← В ГРАДУСАХ, главный параметр

    float successAngle;
    bool canCheckInput = false;

    public Image orbitImage;
    public Image dotImage;

    public void InitSprites(Sprite orbit, Sprite dot, Sprite zone)
    {
        orbitImage.sprite = orbit;
        dotImage.sprite = dot;
        targetZone.sprite = zone;
    }




    void OnEnable()
    {
        SetupTargetZone();
        canCheckInput = false;
        Invoke(nameof(EnableInput), 0.1f);
    }

    void EnableInput()
    {
        canCheckInput = true;
    }

    void SetupTargetZone()
    {
        targetZone.fillAmount = zoneAngle / 360f;
        successAngle = zoneAngle / 2f;

        float randomAngle = Random.Range(0f, 360f);
        targetZone.rectTransform.localEulerAngles =
            new Vector3(0, 0, randomAngle);
    }


    void Update()
    {
        if (!canCheckInput) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            CheckWin();
        }
    }

    void CheckWin()
    {
        float dotAngle = dot.CurrentAngle;

        float zoneStart = targetZone.rectTransform.localEulerAngles.z;
        float zoneCenter = zoneStart + zoneAngle / 2f;

        float diff = Mathf.Abs(Mathf.DeltaAngle(dotAngle, zoneCenter));

        if (diff <= successAngle)
        {
            Debug.Log("WIN");
            OnWin?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("MISS");
        }
    }

}
