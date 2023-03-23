using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GetComponent<GameManager>().FinishMenu();
            Debug.Log("col0");
        }
    }
}
