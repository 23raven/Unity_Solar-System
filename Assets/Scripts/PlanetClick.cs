using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    public Camera mainCamera;
    public Camera focusCamera;
    public FocusCamera focusCameraScript;
    public GameObject clickText;

    [Header("Camera Settings")]
    public float focusDistance = 20f;

    static bool isFocused = false;

    void Update()
    {
        if (isFocused && Input.GetKeyDown(KeyCode.Escape))
            ReturnToMain();
    }

    void OnMouseDown()
    {
        if (isFocused) return;
        FocusOnPlanet();
    }

    void FocusOnPlanet()
    {
        isFocused = true;

        mainCamera.gameObject.SetActive(false);
        focusCamera.gameObject.SetActive(true);

        focusCameraScript.SetTarget(transform, focusDistance);

        if (clickText != null)
            clickText.SetActive(false);
    }

    void ReturnToMain()
    {
        isFocused = false;

        focusCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);

        if (clickText != null)
            clickText.SetActive(true);
    }
}
