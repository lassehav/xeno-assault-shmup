using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    // Use this for initialization
    void Start () {

        ScoreManager.setScore(0);
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void StartClicked()
    {
        Debug.Log("Change scene");
        StartCoroutine(LevelChange(0));
    }

    
     

    IEnumerator LevelChange(int loadLevel)
    {
        Debug.Log("Called CallLoad");
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Level1");
        yield return asyncOp;
    }
}
