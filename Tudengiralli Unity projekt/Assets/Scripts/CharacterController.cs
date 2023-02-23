using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CharacterController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

	const float k_GroundedRadius = .5f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public float dash_force;
	private bool dashing = false;
	private float dash_timer = 0.1f;
	private float current_dash_timer;
	private int dash_direction;
	private float current_dash_cooldown;
	public float dash_cooldown;
	private float g;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}


	private void Update()
	{
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		if (colliders.Length != 0)
		{
			m_Grounded = true;
		}

		if (current_dash_cooldown <= dash_cooldown)
		{
			current_dash_cooldown += Time.deltaTime;
		}
	}

	public void Move(float move)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// Find the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// Smooth it out and apply it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left
			if (move > 0 && !m_FacingRight)
			{
				// flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right
			else if (move < 0 && m_FacingRight)
			{
				// flip the player.
				Flip();
			}
		}
	}

	public void Jump()
    {
		// If the player can jump
		if (m_Grounded)
		{
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
			Debug.Log("Jump");
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

	public void Dash()
    {
		if (current_dash_cooldown >= dash_cooldown)
		{
			StartCoroutine(dash_enum());
			current_dash_cooldown = 0;
		}

		IEnumerator dash_enum()
		{
			if (m_FacingRight)
			{
				dash_direction = 1;
			}
			else
			{
				dash_direction = -1;
			}

			dashing = true;
			g = m_Rigidbody2D.gravityScale;
			m_Rigidbody2D.gravityScale = 0;
			current_dash_timer = dash_timer;
			m_Rigidbody2D.velocity = Vector2.zero;

			yield return new WaitForSeconds(0.3f);

			dashing = false;
			m_Rigidbody2D.gravityScale = g;
		}

		if (dashing)
		{
			Debug.Log("Dash");
			m_Rigidbody2D.velocity = transform.right * dash_direction * dash_force;
			current_dash_timer -= Time.deltaTime;
			if (current_dash_timer <= 0)
			{
				dashing = false;
			}
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}