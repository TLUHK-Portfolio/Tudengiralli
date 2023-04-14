using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager;

    [SerializeField]
    private int collectibles_needed;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.GetComponent<GameManager>().collected >= collectibles_needed)
            {
                Debug.Log("fin");
                GameManager.GetComponent<GameManager>().FinishMenu();
            }
        }
    }
}
