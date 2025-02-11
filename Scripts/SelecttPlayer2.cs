using UnityEngine;

public class SelecttPlayer2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerPrefs.SetInt("Player", 2);
    }
}
