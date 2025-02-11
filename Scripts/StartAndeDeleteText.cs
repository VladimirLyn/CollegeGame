using System.Collections;
using TMPro;
using UnityEngine;

public class StartAndeDeleteText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(15);
        gameObject.SetActive(false);
    }
}
