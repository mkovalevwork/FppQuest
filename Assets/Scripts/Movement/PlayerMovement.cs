using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;   

    Vector3 velocity;

    private void Start()
    {
        SetupVariables();
    }

    void SetupVariables()
    {
        controller = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
        Gravity();

        Movement();

        Jump();
    }

    void Gravity()
    {               
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime; //x^2 по формуле
        controller.Move(velocity * Time.deltaTime);
    }
}
