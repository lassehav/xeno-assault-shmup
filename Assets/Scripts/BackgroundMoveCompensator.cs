using UnityEngine;
using System.Collections;

public class BackgroundMoveCompensator : MonoBehaviour {

    public float moveSpeed = 0.1f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.0f, Time.deltaTime * moveSpeed, 0.0f);
    }
}
