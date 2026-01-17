using UnityEngine;
using UnityEngine.UI;

public class OrbitMiniGame : MonoBehaviour
{
    public OrbitDotMovement dot;
    public Image targetZone;

    [Header("Zone Settings")]
    public float zoneAngle = 20f; // ← В ГРАДУСАХ, главный параметр

    float successAngle;
    bool canCheckInput = false;

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
        // 1️⃣ Связываем угол → картинку
        targetZone.fillAmount = zoneAngle / 360f;

        // 2️⃣ successAngle = половина сектора
        successAngle = zoneAngle / 2f;

        // 3️⃣ Рандомный поворот зоны
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
        float zoneAngleZ = targetZone.rectTransform.localEulerAngles.z;

        float diff = Mathf.Abs(Mathf.DeltaAngle(dotAngle, zoneAngleZ));

        if (diff <= successAngle)
        {
            Debug.Log("WIN");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("MISS");
        }
    }
}
