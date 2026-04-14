using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float gravityModifier;
    private bool isOnGround;
    private bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public InputActionAsset InputActions;
    private InputAction jumpAction;
    private int currentLives;
    [SerializeField] int maxLives;
    [SerializeField] HudManager hudManager;

    void Awake()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
    }
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        currentLives = maxLives;
        hudManager.updateLives(currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.WasPressedThisFrame() && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true; 
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            currentLives--;
            hudManager.updateLives(currentLives);
            if(currentLives == 0)
            {
                GameOver();
            }
        }     
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        gameOver = true;
        playerAnim.SetInteger("DeathType_int", 1);
        playerAnim.SetBool("Death_b", true);
        dirtParticle.Stop();
        explosionParticle.Play();
    }

    public bool isGameOver()
    {
        return gameOver;
    }
}
