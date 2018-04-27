using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class TwitterReader : MonoBehaviour {

    [Serializable]
    class APIKeys
    {
        public string consumer_key;
        public string consumer_secret;
    }

    [Serializable]
    class AuthResponse
    {
        public string token_type;
        public string access_token;
    }

    public TextAsset json;

    public Queue<TweetResponse> tweetQueue;

    string ConsumerKey, ConsumerSecret;

    string authenticationToken;

    // Use this for initialization
    IEnumerator Start () {

        APIKeys keys = JsonUtility.FromJson<APIKeys>(json.text);
        ConsumerKey = keys.consumer_key;
        ConsumerSecret = keys.consumer_secret;

        using (WWW www = ObtainBearerToken(EncodeKeyAndSecret(ConsumerKey, ConsumerSecret)))
        {
            yield return www;
            if (www.error != null)
            {
                Debug.LogError("There was an error sending request: " + www.error);
            }
            else
            {
                var response = JsonUtility.FromJson<AuthResponse>(www.text);
                if (response.token_type != "bearer")
                {
                    throw new Exception("Unexpected token type: " + response.token_type);
                }
                else
                {
                    authenticationToken = response.access_token;
                }
            }
        }

        using (WWW www = ObtainBearerToken(EncodeKeyAndSecret(ConsumerKey, ConsumerSecret)))
        {
            yield return response;
            if (response.error != null)
            {
                Debug.LogError("There was an error sending request: " + response.error);
            }
            else
            {
                var authResponse = JsonUtility.FromJson<AuthResponse>(response.text);
                if(authResponse.token_type != "bearer")
                {
                    throw new Exception("Unexpected token type: " + authResponse.token_type);
                }
                else
                {
                    authenticationToken = authResponse.access_token;
                }
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }


    string EncodeKeyAndSecret(string key, string secret)
    {
        return Base64Encode(Uri.EscapeDataString(key) + ":" + Uri.EscapeDataString(secret));
    }
    

    public WWW ObtainBearerToken(string token)
    {
        var headers = new Dictionary<string, string>();
        headers["Authorization"] = "Basic " + token;
        headers["Content-Type"] = "application / x - www - form - urlencoded; charset = UTF - 8";

        var www = new WWW("https://api.twitter.com/oauth2/token", Encoding.UTF8.GetBytes("grant_type = client_credentials"), headers);
        return www;
    }
}
