using UnityEngine;

public class SwapPlayer : MonoBehaviour
{
    public Sprite Player1;
    public Sprite Player2;
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
    }
}
