using UnityEngine;

public class OrbitDotMovement : MonoBehaviour
{
    public RectTransform center;   // центр круга
    public float radius = 150f;     // радиус орбиты
    public float speed = 120f;      // градусов в секунду

    float angle;

    public float CurrentAngle => angle;


    void Update()
    {
        angle += speed * Time.deltaTime;
        if (angle >= 360f)
            angle -= 360f;

        float rad = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(rad) * radius;
        float y = Mathf.Sin(rad) * radius;

        transform.localPosition = new Vector2(x, y);
    }
}

