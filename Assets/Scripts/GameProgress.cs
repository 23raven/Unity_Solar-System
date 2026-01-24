using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance;

    public ProgressBarUI progressBar;

    void Awake()
    {
        Instance = this;
    }

    public void CompletePlanet(int index)
    {
        progressBar.UnlockSymbol(index);
    }
}
