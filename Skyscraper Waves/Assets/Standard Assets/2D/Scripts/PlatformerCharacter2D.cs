using System;
using UnityEngine;
using UnityEngine.Audio;

#pragma warning disable 649
namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] public float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis
        [SerializeField] public float m_JumpForce = 50f;                  // Amount of force added when the player jumps
        [SerializeField] public float m_MaxHealth = 100f;                  // The maximum health the player has
        [Range(0, 1)] [SerializeField] public float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        //Our implementation of the player with some variables
        private float currentSpeed;         // The player's current speed
        private float currentJumpForce;     // The player's current jump force
        public float health;                // The player's current health
        public float score = 0f;            // The player's current score

        private GameObject[] crates;         //Array of all crates in the level

        public Boolean canClimb = false;    // Whether the player can climb
        public Boolean isClimbing = false;  // Whether the player is climbing
        private Boolean alive = true;       // Whether the player is alive
        private Boolean isSwinging = false; // Whether the player is swinging

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        //shooting  variables
        public int ammo = 0; //amount of ammo currently available
        public GameObject pencil;
        [SerializeField]
        Transform pencilSpawnPos;
        private bool isShooting = false;
        public float pencilSpeed = 3f;
        public float shootDelay = 0.5f;

        //collectables
        private int coins = 0;
        private bool hasSpecialCollectable = false;

        //sound effects
        public AudioSource jumpingsound;
        public AudioSource grabbingsound;
        public AudioSource collectingsound;
        
        void start ()
        {
            jumpingsound = gameObject.AddComponent<AudioSource>();
            grabbingsound = gameObject.AddComponent<AudioSource>();
            collectingsound = gameObject.AddComponent<AudioSource>();
        }

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

            //Set initital speed, jump force and strength values
            currentSpeed = m_MaxSpeed;
            currentJumpForce = m_JumpForce;
            health = m_MaxHealth;

            crates = GameObject.FindGameObjectsWithTag("Crate");


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
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, float climb, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            //Start climbing if the player wants
            if (!crouch && canClimb && climb != 0)
            {
                canClimb = false;
                isClimbing = true;
                m_Rigidbody2D.gravityScale = 0;

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(climb));

                // Move the character up
                m_Rigidbody2D.velocity = new Vector2(0, climb * currentSpeed);
            }

            // If climbing, do not move horizontally but vertically. This cannot be done while crouching
            if (!crouch && isClimbing && !m_Grounded)
            {
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(climb));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(0, climb * currentSpeed);

            }
            else
            {
                // Set whether or not the character is crouching in the animator
                m_Anim.SetBool("Crouch", crouch);

                //only control the player if grounded or airControl is turned on
                if (m_Grounded || m_AirControl)
                {
                    // Reduce the speed if crouching by the crouchSpeed multiplier
                    move = (crouch ? move * m_CrouchSpeed : move);

                    // The Speed animator parameter is set to the absolute value of the horizontal input.
                    m_Anim.SetFloat("Speed", Mathf.Abs(move));

                    // Move the character
                    m_Rigidbody2D.velocity = new Vector2(move * currentSpeed, m_Rigidbody2D.velocity.y);

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
                // If the player should jump...
                if (m_Grounded && jump && m_Anim.GetBool("Ground"))
                {
                    jumpingsound.Play();
                    // Add a vertical force to the player.
                    m_Grounded = false;
                    m_Anim.SetBool("Ground", false);
                    m_Rigidbody2D.AddForce(new Vector2(0f, currentJumpForce));
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

        //Sets the maximum speed of the player to a new value. Use revert to bring the player back to its initial maximum speed.
        public void SetMaxSpeed(float newSpeed, Boolean revert)
        {
            if (revert) { currentSpeed = m_MaxSpeed; }
            else { currentSpeed = newSpeed; }

            foreach (GameObject crate in crates)
            {
                if (revert) { crate.GetComponent<Rigidbody2D>().mass /= 2; }
                else { crate.GetComponent<Rigidbody2D>().mass *= 2; }
            }
        }

        //Sets the jump force of the player to a new value. Use revert to bring the player back to its initial jump force.
        public void SetMaxJumpForce(float newJumpForce, Boolean revert)
        {
            if (revert) { currentJumpForce = m_JumpForce; }
            else { currentJumpForce = newJumpForce; }
        }

        //Sets the strength of the player to a new value. Use revert to bring the player back to its initial strength.
        public void SetStrength(Boolean revert)
        {
            foreach (GameObject crate in crates){
                if (revert) { crate.GetComponent<Rigidbody2D>().mass *= 2; }
                else { crate.GetComponent<Rigidbody2D>().mass /= 2; }
            }
        }

        //Increase the player's score with some amount
        public void IncreaseScore(float addedScore)
        {
            score += addedScore;
        }

        public float GetScore()
        {
            return score;
        }

        //Reset gravity
        public void resetGravity()
        {
            m_Rigidbody2D.gravityScale = 3.0f;
            canClimb = false;
            isClimbing = false;
        }

        //Will be executed upon death
        public void Die()
        {
            alive = false;
        }

        //Lose health with some amount and perhaps die because of it
        public void LoseHealth(float damage)
        {
            health -= damage;
            if (health <= 0) { Die(); }
        }

        public float HealthLeft()
        {
            return health;
        }

        //Pick up a collectable
        public void Collect(object collectable)
        {  
        //Make a distinction between a coin and a special collectable
            //For a special collectable, indicate it is collected and increase score.
            /* if(collectable.getType = ...) {...;} */

            //Increase the player's score
            //IncreaseScore(collectable.value);
        }
        
        // destroy coins when collected
        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                collectingsound.Play();
                Destroy (other.gameObject);
            }

             if (other.gameObject.CompareTag("PowerUp"))
            {
                grabbingsound.Play();
                Destroy (other.gameObject);
            }

            // destroy player when he touches the Water
            if (other.gameObject.CompareTag("Water"))
            {
                Destroy(this.gameObject);
            }
       
        }


        //attacking
        public void Attack() 
        {
            if (isShooting) {return;}
            
            if (ammo <= 0) {
                return;
            }

            isShooting = true;
            IncreaseAmmo(-1);

            GameObject p = Instantiate(pencil);
            p.GetComponent<PencilScript>().StartShoot(m_FacingRight);
            p.transform.position = pencilSpawnPos.transform.position;

            Invoke("ResetShoot", shootDelay);
        }

        private void ResetShoot() {
            isShooting = false;
        }

        public void IncreaseAmmo(int ammoValue) {
            ammo += ammoValue;
        }

        public int AmmoAmount()
        {
            return ammo;
        }

        //collectables
        public int CoinAmount() 
        {
            return coins;
        }

        public void IncreaseCoins(int value)
        {
            coins += value;
            IncreaseScore(value * 10);
        }

        public void SpecialCollectable(int value)
        {
           hasSpecialCollectable = true;
            IncreaseScore(value);
        }

        public bool GetSpecialCollectable()
        {
            return hasSpecialCollectable;
        }

      
    }
}
