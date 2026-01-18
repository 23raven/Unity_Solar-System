using UnityEngine;
using TMPro;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance;

    public int totalObjects = 10;
    int completed = 0;

    public TextMeshProUGUI progressText;

    void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void Increment()
    {
        completed++;
        UpdateUI();
    }

    void UpdateUI()
    {
        progressText.text = $"{completed} / {totalObjects}";
    }
}
