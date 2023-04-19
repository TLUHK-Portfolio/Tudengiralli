using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private float bobHeight = 0.5f;
    [SerializeField]
    private float bobSpeed = 1.0f;
    [SerializeField]
    private GameObject GameManager;
    private Vector3 originalPosition;
    private AudioSource _audioSource;

    void Start()
    {
        originalPosition = transform.position;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float newY = originalPosition.y + bobHeight * Mathf.Sin(Time.time * bobSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("wowowowow");
            _audioSource.Play();
            GameManager.GetComponent<GameManager>().CollectibleCounter();
            Destroy(gameObject);
        }
    }
}
