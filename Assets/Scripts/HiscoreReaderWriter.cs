using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Runtime.Serialization;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class HiscoreReaderWriter : MonoBehaviour {


    public GameObject HiScoreTextPrefab;
    public RectTransform HiScoreUIParent;    
    public Animator HiScoreAnimator;


    [Serializable]
    public class HiScore
    {
        public string _id;
        public string updatedAt;
        public string createdAt;
        public string name;
        public int value;
        public int __v;
    }

    [Serializable]
    public class HiScores
    {
        public HiScore[] scores;        
    }



    // Use this for initialization
    void Start () {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://hiscore-keeper-server.herokuapp.com/scores");
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            HiScores myObject = JsonUtility.FromJson<HiScores>(www.downloadHandler.text);          

            if(HiScoreAnimator != null)
            {
                HiScoreAnimator.SetTrigger("DataLoaded");
            }

            for (int i = 0; i < myObject.scores.Length; i++)
            {
                GameObject item = (GameObject)GameObject.Instantiate(HiScoreTextPrefab, HiScoreUIParent);
                var height = ((RectTransform)(item.transform)).rect.height;
                item.transform.localPosition = new Vector3(10.0f, -10.0f - i * height, 0);
                item.transform.localScale = new Vector3(1, 1, 1);
                item.GetComponent<Text>().text = myObject.scores[i].name;
                item.transform.GetChild(0).GetComponent<Text>().text = myObject.scores[i].value.ToString();
            }
        }
    }

    public void uploadScore(int score, String name)
    {
        HiScore hs = new HiScore();
        hs.name = name;
        hs.value = score;

        string hsJson = JsonUtility.ToJson(hs);

        Debug.Log(hsJson);                

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(hsJson);        
        StartCoroutine(UploadData(postData));        
    }

    IEnumerator UploadData(byte[] postData)
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
                        
        WWW www = new WWW("https://hiscore-keeper-server.herokuapp.com/scores", postData, headers);
        
        yield return www;

        Debug.Log(www);

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
            StartCoroutine(GetText());
        }
    }
}
