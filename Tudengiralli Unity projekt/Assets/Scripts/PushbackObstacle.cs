using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushbackObstacle : MonoBehaviour
{
    [Tooltip("For how long will the player be stunned.")]
    [SerializeField] private float stunTimer = 1f;

    [Tooltip("How strongly will the player  be pushed.")]
    [SerializeField] private float pushbackForce = 1000f;
    public AudioClip pushSound;
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("impact");
            SoundManager.instance.PlaySingle(pushSound);
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<PlayerInput>().stunTimer = stunTimer;
            
            playerRigidbody.AddForce((collision.transform.position - new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, 0)) * pushbackForce);
        }
    }
}
