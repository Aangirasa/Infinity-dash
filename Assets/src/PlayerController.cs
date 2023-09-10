using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float jumpForce;
    public float gravityModifier;
    private bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem dirtParticles;
    private Animator animator;

    public AudioClip jumpaudio;
    public AudioClip crashAudio;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && isOnGround && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)))
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            audioSource.PlayOneShot(jumpaudio, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.collider.gameObject.CompareTag("obstacle"))
        {
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            gameOver = true;
            audioSource.Stop();
            audioSource.PlayOneShot(crashAudio, 1.0f);
            dirtParticles.Stop();
        }

    }
}
