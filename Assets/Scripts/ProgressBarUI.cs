using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ProgressBarUI : MonoBehaviour
{
    public Image fill;
    public TMP_Text progressText;

    int current = 0;
    int total = 10;

    public void SetProgress(int value)
    {
        current = value;
        progressText.text = $"{current} / {total} explored";
        StopAllCoroutines();
        StartCoroutine(FillAnimation((float)current / total));
    }

    IEnumerator FillAnimation(float target)
    {
        float start = fill.fillAmount;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            fill.fillAmount = Mathf.Lerp(start, target, t);
            yield return null;
        }

        fill.fillAmount = target;
    }

    public void TestAdd()
    {
        SetProgress(current + 1);
    }


}
