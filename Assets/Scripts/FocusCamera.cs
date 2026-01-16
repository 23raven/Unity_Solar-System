using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    public Transform target;

    float distance = 20f;

    public void SetTarget(Transform newTarget, float newDistance)
    {
        target = newTarget;
        distance = newDistance;
    }

    void LateUpdate()
    {
        if (!target) return;

        transform.position = target.position - target.forward * distance;
        transform.LookAt(target);
    }
}
