using UnityEngine;
using System.Collections;

public class RockRotator : MonoBehaviour {

    public float rotationSpeedMin = 10.0f;
    public float rotationSpeedMax = 100.0f;


    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 359f));
    }

    // Update is called once per frame
    /*void Update () {
        this.transform.Rotate(Vector3.forward, Random.Range(rotationSpeedMin, rotationSpeedMax) * Time.deltaTime);
    }*/
}
