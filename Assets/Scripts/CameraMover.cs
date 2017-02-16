using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    public float moveSpeed = 0.5f;
    
    // Update is called once per frame
    void Update () {        
        transform.Translate(0.0f, Time.deltaTime * moveSpeed, 0.0f);
    }
}
