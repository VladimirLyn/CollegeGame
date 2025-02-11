using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgrammingGame : MonoBehaviour
{
    public GameObject Heart0;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;   
    public GameObject False;
    public GameObject Anemy;
    public GameObject Royal;
    public TMP_Text PlayerDeadText;
    public TMP_Text Name;
    float PlayerHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Name.text = PlayerPrefs.GetString("PlayerName");
        PlayerHP = PlayerPrefs.GetFloat("PlayerHP");
    }
 
    public void No()
    {
        StartCoroutine(PlayerFalse());
        PlayerHP -= 20;
        PlayerPrefs.SetFloat("PlayerHP", PlayerHP);

    }

    public void Yes()
    {
        StartCoroutine(AnemyDead());
        Debug.Log("yes");
    }
    private void FixedUpdate()
    {

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
        if (PlayerHP <= 0)
        {
            StartCoroutine(PlayerDead());
        }
    }
    IEnumerator PlayerDead()
    {
        PlayerDeadText.gameObject.SetActive(true);
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Menu");
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
