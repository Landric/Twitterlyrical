using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweetSpawner : MonoBehaviour {

    public GameObject tweetPrototype;

    GameObject canvas;
    TwitterReader reader;

    float timer = 0f;

	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        reader = FindObjectOfType<TwitterReader>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer = 0f;
            SpawnTweet();
        }
	}

    void SpawnTweet()
    {
        GameObject column;
        int c = Random.Range(-1, 2);
        switch (c){
            case -1: column = GameObject.Find("Left"); break;
            case 0: column = GameObject.Find("Centre"); break;
            case 1: column = GameObject.Find("Right"); break;
            default: throw new System.Exception();
        }

        //GameObject tweetGO = Instantiate(tweetPrototype);
        ////tweetGO.transform.SetParent(canvas.transform, false);
        //tweetGO.transform.localPosition = new Vector2((float)c, 6f);
        ////tweetGO.GetComponentInChildren<Text>().text = tweet.text;
    }
}
