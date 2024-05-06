using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontalInput;
    float verticalInput;
    float speed = 10f;
    [SerializeField]
    float health = 100;

    bool isGrounded;
    Vector3 velocity;
    float gravity = -9.81f;
    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    float jumpHeight = 2f;

    Vector3 movement;
    CharacterController controller;
    public Text healthText;
    public GameManager gameManager;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movement = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        healthText.text = health.ToString() + " Health";
        if (health <= 0)
        {
            Time.timeScale = 0;
            gameManager.EndScreen();
        }
    }
}
