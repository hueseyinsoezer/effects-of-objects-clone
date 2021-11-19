using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver, doubleJump, doubleSpeed = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle, dirtSplatterParticle;
    public AudioClip jumpSound, crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            isOnGround = false;
            doubleJump = true;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtSplatterParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);           
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && doubleJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump",3,0f);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJump = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multilier", 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtSplatterParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",1);
            Debug.Log("Game Over!");
            explosionParticle.Play();
            dirtSplatterParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
}
