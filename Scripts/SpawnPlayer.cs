using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (PlayerPrefs.GetInt("Player") == 1)
        {
            Player1.SetActive(true);
        }
        else
        {
            Player2.SetActive(true);
        }
    }
}
