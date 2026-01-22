using UnityEngine;
using UnityEngine.UI;

public class PlanetClick : MonoBehaviour
{
    [Header("Orbit Sprites")]
    public Sprite orbitSprite;
    public Sprite dotSprite;
    public Sprite targetZoneSprite;

    [Header("UI")]
    public Image backgroundImage;
    public Sprite planetBackground; // пока null или заглушка

    public Camera mainCamera;
    public Camera focusCamera;
    public FocusCamera focusCameraScript;
    public GameObject clickText;

    [Header("Camera Settings")]
    public float focusDistance = 20f;

    static bool isFocused = false;
    public GameObject rightPanel;
    public GameObject miniGameContainer;

    [HideInInspector]
    public bool isCompleted = false;
    public OrbitMiniGame miniGame;




    void Update()
    {
        if (isFocused && Input.GetKeyDown(KeyCode.Escape))
            ReturnToMain();
    }

    void OnMouseDown()
    {
        if (isCompleted) return; // ← ВАЖНО
        if (isFocused) return;

        FocusOnPlanet();
    }

    void OnPlanetCompleted()
    {
        if (isCompleted) return; // защита от двойного вызова

        isCompleted = true;
        GameProgress.Instance.Increment();
    }



    void FocusOnPlanet()
    {
        miniGame.InitSprites(
        orbitSprite,
        dotSprite,
        targetZoneSprite
        );





        miniGame.OnWin = null;              // ← ВАЖНО
        miniGame.OnWin += OnPlanetCompleted;

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

        if (backgroundImage != null && planetBackground != null)
        {
            backgroundImage.sprite = planetBackground;
        }


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
