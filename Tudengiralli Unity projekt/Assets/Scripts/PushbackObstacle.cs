using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushbackObstacle : MonoBehaviour
{
    [Tooltip("For how long will the player be stunned.")]
    [SerializeField] private float stunTimer = 1f;

    [Tooltip("How strongly will the player  be pushed.")]
    [SerializeField] private float pushbackForce = 1000f;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("impact");
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<PlayerInput>().stunTimer = stunTimer;
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRigidbody.AddForce((collision.transform.position - gameObject.transform.position) * pushbackForce);
        }
    }
}
