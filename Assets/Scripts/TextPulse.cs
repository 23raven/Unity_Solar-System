using UnityEngine;

public class TextPulse : MonoBehaviour
{
    public float scaleAmount = 0.08f;
    public float speed = 2f;

    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1f + Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = startScale * scale;
    }
}
