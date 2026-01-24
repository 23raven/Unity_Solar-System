using UnityEngine;
using UnityEngine.UI;

public class PlanetClick : MonoBehaviour
{
    [Header("Progress")]
    public int progressIndex; // 0–9
    // 0 Sun, 1 Mercury, 2 Venus, 3 Earth, 4 Moon,
    // 5 Mars, 6 Jupiter, 7 Saturn, 8 Uranus, 9 Neptune

    [Header("UI")]
    public GameObject progressBar;

    [Header("Orbit Sprites")]
    public Sprite orbitSprite;
    public Sprite dotSprite;
    public Sprite targetZoneSprite;

    [Header("Background")]
    public Image backgroundImage;
    public Sprite planetBackground;

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
        if (isCompleted) return;
        if (isFocused) return;

        FocusOnPlanet();
    }

    void FocusOnPlanet()
    {
        // Инициализация мини-игры
        miniGame.InitSprites(
            orbitSprite,
            dotSprite,
            targetZoneSprite
        );

        // Скрываем прогресс-бар
        if (progressBar != null)
            progressBar.SetActive(false);

        // Подписка на победу
        miniGame.OnWin = null;
        miniGame.OnWin += OnPlanetCompleted;
        miniGame.OnWin += CloseFocus;

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
            backgroundImage.sprite = planetBackground;
    }

    void OnPlanetCompleted()
    {
        if (isCompleted) return;

        isCompleted = true;
        GameProgress.Instance.CompletePlanet(progressIndex);

        // Возвращаем прогресс-бар
        if (progressBar != null)
            progressBar.SetActive(true);
    }

    public void CloseFocus()
    {
        ReturnToMain();
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
