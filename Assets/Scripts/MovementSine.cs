using UnityEngine;
using System.Collections;

public class MovementSine : MonoBehaviour {

    public float amplitude;
    public float moveSpeed = -1.0f;

	
	// Update is called once per frame
	void Update () {
        transform.Translate(Time.deltaTime * Mathf.Sin(transform.position.y) * amplitude, Time.deltaTime * moveSpeed, 0.0f);
    }
}
