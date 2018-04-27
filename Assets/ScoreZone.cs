using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour {

    public string label; //TODO: Replace with sprite effect/object?
    public float points;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("Tweet"))
        {
            Debug.Log(label);
        }
    }
}
