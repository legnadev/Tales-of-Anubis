using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
		[SerializeField] public float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		[SerializeField] private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Animat;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

		[SerializeField] private bool m_Ledged;
		[SerializeField] private bool m_canBeLedged;
		[SerializeField] private float m_originalGravity;

		private IEnumerator coroutine;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
			m_Animat = transform.Find("Anubis").gameObject.GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
			m_originalGravity = m_Rigidbody2D.gravityScale;
			RestartLedge ();
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
			m_Animat.SetBool("Ground", m_Grounded);


            // Set the vertical animation
			m_Animat.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump)
        {

            // If crouching, check to see if the character can stand up
			if (!crouch && m_Animat.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
			m_Animat.SetBool("Crouch", crouch);


            //only control the player if grounded or airControl is turned on
			if ( (!m_Ledged ) && (m_Grounded || m_AirControl) )
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
				m_Animat.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }

			if (m_Ledged && jump) {
				
				//print ("kitando ledge");
				m_Animat.SetBool ("EndLege", true);
				//Ledge (false, null);
			}

			if (m_Ledged && !jump && Input.GetButtonDown ("Jump")) {
				Ledge (false, null);
			}

            // If the player should jump...
			if (m_Grounded && jump && m_Animat.GetBool("Ground") && !m_Ledged)
            {
				Jump ();
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

		public void Ledge(bool status, Transform ledgeGO)
        {

			if (status) {
				m_Ledged = true;
				m_Animat.SetBool ("Ledge", m_Ledged);

				coroutine = ledgePosition (ledgeGO, 0.05f);
				StartCoroutine (coroutine);

				//m_Rigidbody2D.velocity = new Vector3 (0, 0, 0);
				m_Rigidbody2D.gravityScale = 0;
				m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
				//transform.position = ledgeGO.transform.position;

			} else if (!status && m_Ledged) { //End Ledge
				m_Ledged = false;
				//m_Rigidbody2D.velocity = new Vector3 (0, 0, 0);
				GameObject myAnubis = GameObject.Find ("Anubis");

				myAnubis.transform.localPosition = new Vector3 (0, 0, 0);
				//GameObject.Find ("Player").transform.position = new Vector3 (myAnubis.transform.position.x, myAnubis.transform.position.y, myAnubis.transform.position.z);


				m_Rigidbody2D.gravityScale = m_originalGravity;
				m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
				m_canBeLedged = false;
				m_Animat.SetBool ("EndLege", false);
				m_Animat.SetBool ("Ledge", false);
				Invoke ("RestartLedge", 1);
			}

        }

		private void RestartLedge(){
			m_canBeLedged = true;
		}

		void OnTriggerEnter2D(Collider2D other){
			if (other.transform.tag == "Ledge" && !m_Grounded && m_canBeLedged) {
				Ledge (true, other.transform);
			}
		}

		private void Jump(){
				m_Grounded = false;
				m_Animat.SetBool("Ground", false);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}

		private void JumpAfterLedge(){
			Ledge (false, null);
			Jump ();
		}

		private IEnumerator ledgePosition(Transform ledgeGO, float waitTime){
			while (m_Animat.GetCurrentAnimatorStateInfo(0).IsName("ledge") == false) {
				print ("No hay animacion tete");
				yield return new WaitForSeconds (waitTime);
			}
			print ("Yasta la animacion on joder");

			GameObject.Find ("Player").transform.position = new Vector3 (ledgeGO.transform.position.x, ledgeGO.transform.position.y, ledgeGO.transform.position.z);
			GameObject.Find ("Anubis").transform.localPosition = new Vector3 (0, -0.93f, 0);
		}
			
    }
}
