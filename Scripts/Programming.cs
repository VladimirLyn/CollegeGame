using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class Programming : MonoBehaviour
{
    public TMPro.TMP_InputField Input;
    public GameObject Heart0;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject False;
    public GameObject Anemy;
    public GameObject Royal;
    public TMP_Text Name;
    float PlayerHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Name.text = PlayerPrefs.GetString("PlayerName");
        gameObject.GetComponent<Camera>().backgroundColor = new Color(0.7503194f, 0.1822268f, 0.8584906f, 0);
        PlayerHP = PlayerPrefs.GetFloat("PlayerHP");
    }

   private void FixedUpdate()
    {
        if (PlayerHP <= 0)
        {
            SceneManager.LoadScene("Losoe");
        }
        if (PlayerHP < 100)
        {
            Heart4.gameObject.SetActive(false);
        }
        if (PlayerHP < 80)
        {
            Heart3.gameObject.SetActive(false);
        }
        if (PlayerHP < 60)
        {
            Heart2.gameObject.SetActive(false);
        }
        if (PlayerHP < 40)
        {
            Heart1.gameObject.SetActive(false);
        }
        if (PlayerHP < 20)
        {
            Heart0.gameObject.SetActive(false);
        }
    }
    public void Check()
    {
        switch(Input.text)
        {
            case "2491":

                Yes();
                break;

            case "2194":

                Yes();
                break;
            case "2095":

                Yes();
                break;

            default:
                No();
                break;
        }
    }
    public void No()
    {
        PlayerHP -= 20;
        StartCoroutine(PlayerFalse());
        PlayerPrefs.SetFloat("PlayerHP", PlayerHP);

    }

    public void Yes()
    {
        StartCoroutine(AnemyDead());
    }
    IEnumerator PlayerFalse()
    {
        False.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        False.gameObject.SetActive(false);
    }
    IEnumerator AnemyDead()
    {
        Royal.SetActive(true);
        while (Royal.gameObject.transform.position.y > -2.5f)
        {
            Royal.gameObject.transform.position = new Vector2(Royal.gameObject.transform.position.x, Royal.gameObject.transform.position.y - 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
        Anemy.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
