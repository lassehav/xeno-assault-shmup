using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int score = 0;
    private int playerLives;

    public static int playerStartLives = 3;    
    public Text scoreText;
    public GameObject playerPrefab;
    public GameObject playerLifeIndicatorParent;
    public GameObject playerLifeIndicatorPrefab;
    public Text GameInfoText;
    

    // Use this for initialization
    void Start () {
        scoreText.text = score.ToString();
        playerLives = playerStartLives;
        GameInfoText.enabled = false;

        UpdatePlayerLifeIndicators();
    }
    
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        ScoreManager.setScore(score);
    }

    public void PlayerKilled()
    {
        Debug.Log("Killed");
        playerLives--;
        UpdatePlayerLifeIndicators();
        if (playerLives == 0)
        {

            StartCoroutine(GameOver());
        }       
        else
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator LevelChange()
    {
        Debug.Log("Called CallLoad");
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("GameOverSaveHiscore");
        yield return asyncOp;
    }

    IEnumerator GameOver()
    {
        GameInfoText.enabled = true;
        GameInfoText.text = "Game over";
        yield return new WaitForSeconds(2);
        yield return LevelChange();
}

    IEnumerator Respawn()
    {
        GameInfoText.enabled = true;
        for (int i = 3; i != 0; i--)
        {
            GameInfoText.text = "Respawn in " + i + "...";
            yield return new WaitForSeconds(1);
        }
        
        GameObject.Instantiate(playerPrefab, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0.0f), Quaternion.identity);
        GameInfoText.enabled = false;
    }

    private void UpdatePlayerLifeIndicators()
    {

        foreach (Transform child in playerLifeIndicatorParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < playerLives; i++)
        {
            GameObject pi = (GameObject)GameObject.Instantiate(playerLifeIndicatorPrefab, playerLifeIndicatorParent.transform);
            RectTransform rt = (RectTransform)pi.transform;

            rt.position = new Vector2(playerLifeIndicatorParent.transform.position.x + rt.rect.width * i, playerLifeIndicatorParent.transform.position.y);
        }
    }
}
