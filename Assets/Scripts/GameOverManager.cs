using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void BackToMain()
    {
        StartCoroutine(LevelChange());
    }

    IEnumerator LevelChange()
    {        
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("MainMenu");
        yield return asyncOp;
    }
}
