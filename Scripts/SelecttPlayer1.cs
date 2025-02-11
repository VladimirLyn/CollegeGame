using UnityEngine;

public class SelecttPlayer1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("Player", 1);
    }
}
