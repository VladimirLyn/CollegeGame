using System;
using System.Collections;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
    string BOT_TOKEN = "6707889560:AAFBA6d6JrTMzq6JDWjrubUVituAWtRjjtY";
    string user = "5087021054";
    string url;
    public TMP_InputField FIO;
    public TMP_InputField Email;
    public TMP_InputField Phone;
    string PlayerName;
    public GameObject Player1;
    public GameObject Player2;
    
    private void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("Player")==1)
        {
            Player1.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        { 
            Player1.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (PlayerPrefs.GetInt("Player") == 2)
        {
       Player2.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            Player2.GetComponent <SpriteRenderer>().color = Color.white;    
        }
    }
    private void Start()
    {
        PlayerPrefs.SetInt("Player",0);
        PlayerPrefs.SetFloat("PlayerHP", 100);
    }
    public void StartG()
    {
        if(FIO != null && Email != null && Phone != null)
        {
        StartCoroutine(StartGame());
        }
    }
    public IEnumerator StartGame()
    {
        if (PlayerPrefs.GetInt("Player") != 0)
        try
        {
        PlayerName = FIO.text.ToString().Split(' ')[1];
        }
        catch(IndexOutOfRangeException)
        {
            StopAllCoroutines();
        }
        PlayerPrefs.SetString("PlayerName", PlayerName);
        Debug.Log(PlayerName);
        url = $"https://api.telegram.org/bot{BOT_TOKEN}/sendMessage?chat_id={user}&text= {FIO.text} {Email.text} {Phone.text}";
        PlayerPrefs.SetFloat("PlayerHP", 100);
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        Debug.Log(request.result);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
