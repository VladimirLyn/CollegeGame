using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    string BOT_TOKEN = "6707889560:AAFBA6d6JrTMzq6JDWjrubUVituAWtRjjtY";
    string user = "5087021054";
    string url;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        url = $"https://api.telegram.org/bot{BOT_TOKEN}/sendMessage?chat_id={user}&text= {PlayerPrefs.GetFloat("PlayerHP")}";
        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        Debug.Log(request.result);
    }
}
