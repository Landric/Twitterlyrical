using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetCard : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.position += (Vector3)Vector2.down * Speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var collider in Physics2D.OverlapBoxAll(transform.position, transform.lossyScale, 0f))
        {
            Debug.Log(collider.gameObject.name);
        }

        Debug.Log("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
    }


}
