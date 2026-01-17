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
    public GameObject rightPanel;
    public GameObject miniGameContainer;


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

        float distance = transform.localScale.x * 4f;
        focusCameraScript.SetTarget(transform, distance);

        if (clickText != null)
            clickText.SetActive(false);

        if (rightPanel != null)
            rightPanel.SetActive(true);

        if (miniGameContainer != null)
            miniGameContainer.SetActive(true);

    }


    void ReturnToMain()
    {
        isFocused = false;

        focusCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);

        if (clickText != null)
            clickText.SetActive(true);

        if (rightPanel != null)
            rightPanel.SetActive(false);

        if (miniGameContainer != null)
            miniGameContainer.SetActive(false);

    }

}
