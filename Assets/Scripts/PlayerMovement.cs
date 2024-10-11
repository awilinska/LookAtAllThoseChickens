using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private CharacterController controller;
    private float speed;
    private Vector3 previousPosition;
    public Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
                Vector3 currentPosition = this.transform.position;
        Vector3 positionChange = currentPosition - previousPosition;
        speed = positionChange.magnitude / Time.deltaTime;
        animator.SetFloat("Speed", speed);

        previousPosition = currentPosition;

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        controller.SimpleMove(movement * movementSpeed);
    }
}