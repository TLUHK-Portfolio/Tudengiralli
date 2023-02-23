using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	[SerializeField] private CharacterController controller;

	private Rigidbody2D m_Rigidbody2D;
	private BoxCollider2D m_Collider2D;
	public float runSpeed = 40f;
	public float stunTimer = 0f;
	private bool stun = false;

	float horizontalMove = 0f;


    private void Awake()
    {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Collider2D = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    void Update()
	{
		if (stunTimer <= 0)
        {
			if (stun)
			{
				m_Rigidbody2D.sharedMaterial.friction = 0.0f;
				m_Collider2D.enabled = false;
				m_Collider2D.enabled = true;
				stun = false;
			}

			// Get player input for horizontal movement
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			// Get player input for jumpinng
			if (Input.GetButtonDown("Dash"))
			{
				controller.Dash();
			}
			// Get player input for jumping
			if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
			{
				controller.Jump();
			}
		}
		
		if (stunTimer > 0)
        {
			if (!stun)
            {
				m_Rigidbody2D.sharedMaterial.friction = 0.5f;
				m_Collider2D.enabled = false;
				m_Collider2D.enabled = true;
				Debug.Log("friction");
				stun = true;
			}
			stunTimer -= Time.deltaTime;
        }
	}

	void FixedUpdate()
	{
		if (stunTimer <= 0)
		{
			// Move character
			controller.Move(horizontalMove * Time.fixedDeltaTime);
		}
	}
}