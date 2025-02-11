using NUnit.Framework.Internal;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public Image HPBar;
    float StartAnemyHP;
    public GameObject Heart0;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public Sprite Player1;
    public Sprite Player2;
    public TMP_Text DisplayActions;
    public TMP_Text PlayerHPOnDisplay;
    public TMP_Text AnemyHPOnDisplay;
    public TMP_Text Dead;
    public TMP_Text Name;
    float PlayerHP = 100;
    float AnemyHP;
    GameObject Anemy;
    String[] actions;
    int ActionsCalc = 4;
    int kills = 0;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Anemy")
        {
            Anemy = collision.gameObject;
            AnemyHP = collision.gameObject.GetComponent<Anemy>().Hp;
            StartAnemyHP= collision.gameObject.GetComponent<Anemy>().StartHP;

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
            if (PlayerPrefs.GetInt("Player") == 1)
            {
            gameObject.GetComponent<SpriteRenderer>().sprite = Player1;
            }
            else
            {
            gameObject.GetComponent<SpriteRenderer>().sprite = Player2;
            }
            Name.text = PlayerPrefs.GetString("PlayerName");
        

    }
    public void Atack()
    {
        actions = DisplayActions.text.Split();
        foreach (String action in actions)
        {
            switch (action)
            {
                case "/2":
                    {
                        AnemyHP = AnemyHP / 2;
                        break;
                    }
                case "корень":
                    {
                        if (AnemyHP>0)
                        {

                            AnemyHP = (float)Math.Sqrt(AnemyHP);
                        }
                        break;
                    }
                case "округлить":
                {
                        AnemyHP = (float)Math.Round(AnemyHP);
                        break;
                    }
                case "+5":
                    {
                        AnemyHP += 5;
                        break;
                    }
                case "-5":
                    {
                        AnemyHP = AnemyHP - 5;
                        break;
                    }
            }
        }
        Anemy.gameObject.GetComponent<Anemy>().Hp = AnemyHP;
        StartCoroutine(Anim());
        ActionsCalc = 4;
        DisplayActions.text = "";
        AnemyHPOnDisplay.text = AnemyHP.ToString();
    }

    IEnumerator Anim()
    {
        if (AnemyHP != 0)
        {

            PlayerHP -= 20;
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
            while (Anemy.gameObject.transform.position.x > -5)
            {
                Anemy.gameObject.transform.position = new Vector2(Anemy.gameObject.transform.position.x - 0.4f, Anemy.gameObject.transform.position.y);
                yield return new WaitForSeconds(0.01f);
            }
            while (Anemy.gameObject.transform.position.x < 3.5f)
            {
                Anemy.gameObject.transform.position = new Vector2(Anemy.gameObject.transform.position.x + 0.6f, Anemy.gameObject.transform.position.y);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            while (gameObject.transform.position.x < 3.5f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.6f, gameObject.transform.position.y);
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.4f);
            while (gameObject.transform.position.x > -5)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y);
                yield return new WaitForSeconds(0.01f);
            }
            kills++;
            if(kills == 4)
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Destroy(Anemy);
            }
        }
        /*
        if (Anemy.gameObject.GetComponent<Anemy>().Hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        */
    }
    public void divide()
    {
        if(gameObject.activeSelf == true)
        {

        if (ActionsCalc > 0)
        {
        ActionsCalc -= 1;
        DisplayActions.text += "/2 ";
        }
        }
    }
    public void Root()
    {
        if (gameObject.activeSelf == true)
        {

        if (ActionsCalc > 0)
        {
        ActionsCalc -= 1;
        DisplayActions.text += "корень ";
        }
        }
    }
    public void RoundUp()
    {
        if (gameObject.activeSelf == true)
        {

        if (ActionsCalc > 0)
        {
        ActionsCalc -= 1;
        DisplayActions.text += "округлить ";
        }
        }
    }
    public void Minus()
    {
        if (gameObject.activeSelf == true)
        {

        if (ActionsCalc > 0)
        {
            ActionsCalc -= 1;
            DisplayActions.text += "-5 ";
        }
        }
    }
    public void Plus()
    {
        if (gameObject.activeSelf == true)
        {

        ActionsCalc -= 1;
        DisplayActions.text += "+5 ";
        }
    }
    public void ResetActions()
    {
        if (gameObject.activeSelf == true)
        {

        ActionsCalc = 4;
        DisplayActions.text = "";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        HPBar.fillAmount = Math.Abs(AnemyHP) / Math.Abs(StartAnemyHP);
        PlayerPrefs.SetFloat("PlayerHP", PlayerHP);

        AnemyHPOnDisplay.text = AnemyHP.ToString();

        if (PlayerHP <= 0)
        {
            StartCoroutine(PlayerDead());
        }
        AnemyHPOnDisplay.text = AnemyHP.ToString();
        PlayerHPOnDisplay.text = PlayerHP.ToString(); 
        
    }
    IEnumerator PlayerDead()
    {
        Dead.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");
    }
}
