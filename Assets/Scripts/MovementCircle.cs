using UnityEngine;
using System.Collections;

public class MovementCircle : MonoBehaviour {

    public float circleSizeMultiplier = 1.0f;
    public float circleSpeed = 0.01f;
    public float phase = 0.0f;

    // Update is called once per frame
    void Update () {
        Vector3 t = transform.position;
        t.x = t.x + Mathf.Sin(phase) * circleSizeMultiplier * Time.deltaTime;
        t.y = t.y + Mathf.Cos(phase) * circleSizeMultiplier * Time.deltaTime;
        transform.position = t;
        phase += circleSpeed;
    }
}
