using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TweetResponse
{
    [System.Serializable]
    public class Tweet
    {
        [System.Serializable]
        public class User
        {
            public int id;
            public string name;
            public string screen_name;
            public string location;
            public string url;
            public string description;
        }

        public string created_at;
        public string id_str;
        public string text;
        public User user;
    }

    [System.Serializable]
    public class Place
    {

    }

    public Tweet tweet;
    public Place place;
}
