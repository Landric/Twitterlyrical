using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [System.Serializable]
    public struct ScoreDistance
    {
        public float min;
        public float max;
        public float score;
    }

    public ScoreDistance[] scores;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
