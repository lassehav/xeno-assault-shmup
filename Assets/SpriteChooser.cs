using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[System.Serializable]
public class SpriteOption
{
    public Sprite sprite;
    public bool active;
}*/

public class SpriteChooser : MonoBehaviour {

    public Sprite[] spriteOptions;

    // Use this for initialization
    void Start () {


        gameObject.GetComponent<SpriteRenderer>().sprite = spriteOptions[(int)Random.Range(0, spriteOptions.Length - 1)];
        
    }

}
