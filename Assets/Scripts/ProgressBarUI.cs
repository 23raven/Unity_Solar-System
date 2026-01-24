using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    public Image[] symbols; // 10 UI Image иконок

    void Awake()
    {
        // На старте все иконки чёрные (locked)
        for (int i = 0; i < symbols.Length; i++)
        {
            symbols[i].color = Color.black;
        }
    }

    public void UnlockSymbol(int index)
    {
        if (index < 0 || index >= symbols.Length) return;
        symbols[index].color = Color.white;
    }
}
