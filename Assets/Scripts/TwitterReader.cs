using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class TwitterReader : MonoBehaviour {

    [Serializable]
    struct APIKeys
    {
        public string consumer_key;
        public string consumer_secret;
    }

    [Serializable]
    struct AuthResponse
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

        using (UnityWebRequest www = ObtainBearerToken(EncodeKeyAndSecret(ConsumerKey, ConsumerSecret)))
        {
            yield return www.SendWebRequest();
            
            if (www.error != null)
            {
                Debug.LogError("There was an error sending request: " + www.error);
                Debug.LogError(www.downloadHandler.text);
            }
            else
            {
                var response = JsonUtility.FromJson<AuthResponse>(www.downloadHandler.text);
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


    UnityWebRequest ObtainBearerToken(string token)
    {
        WWWForm postData = new WWWForm();
        postData.AddField("grant_type", "client_credentials");

        UnityWebRequest request = UnityWebRequest.Post("https://api.twitter.com/oauth2/token", postData);

        request.SetRequestHeader("Authorization", "Basic " + token);
        request.SetRequestHeader("Content-Type", "application / x - www - form - urlencoded; charset = UTF - 8");

        return request;
    }

    /*
    WWW ObtainBearerToken(string token)
    {
        WWWForm parameters = new WWWForm();
        parameters.AddField("grant_type", "client_credentials");

        var headers = parameters.headers;
        headers["Authorization"] = "Basic " + token;
        headers["Content-Type"] = "application / x - www - form - urlencoded; charset = UTF - 8";

        return new WWW("https://api.twitter.com/oauth2/token", parameters.data, headers);
    }
    */
}
