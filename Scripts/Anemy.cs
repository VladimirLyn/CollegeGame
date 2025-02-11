using Unity.VisualScripting;
using UnityEngine;

public class Anemy : MonoBehaviour
{
    public GameObject NextAnemy;
    public float Hp;
    public float StartHP;
    private void Start()
    {
     StartHP = Hp;
    }
    private void OnDestroy()
    {
        NextAnemy.gameObject.SetActive(true);
    }

}
