using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public Text scoreText;
    public InputField input;

    // Use this for initialization
    void Start () {
        scoreText.text = ScoreManager.getScore().ToString();
    }
    
    public void SaveScores()
    {
        Debug.Log(input.text + ", " + ScoreManager.getScore().ToString() + " points");
        GetComponent<HiscoreReaderWriter>().uploadScore(ScoreManager.getScore(), input.text);
    }
    
}
