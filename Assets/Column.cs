using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    public string Key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Key)){
            CheckChildren();
        }
	}

    void CheckChildren()
    {
        foreach (Transform t in transform)
        {
            t.GetComponent<TweetCard>();
        }
    }
}
