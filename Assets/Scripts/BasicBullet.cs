using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour {

    public float forwardSpeed = 10.0f;

    // Use this for initialization
    void Start () {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * forwardSpeed;
    }
}
