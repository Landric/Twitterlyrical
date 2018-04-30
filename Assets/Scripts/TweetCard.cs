using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetCard : MonoBehaviour {

    public float Speed;
    public float Distance;
    Vector2 scorePosition;

	// Use this for initialization
	void Start () {
        scorePosition = transform.parent.Find("ScorePoint").localPosition;
	}
	
	// Update is called once per frame
	void Update () {

        Distance = Vector2.Distance(transform.position, scorePosition);
		
	}

    private void FixedUpdate()
    {
        transform.position += (Vector3)Vector2.down * Speed * Time.fixedDeltaTime;
    }

}
