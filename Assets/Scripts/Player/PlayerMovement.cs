using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float minimumVerticalAngle = -80.0f;
    public float maximumVerticalAngle = 80.0f;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;

    private float rotationX = 0;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Karakterin sadece yürüme yönlendirmesini sağlar.
    }

    void Update()
    {
        MoveCharacter();
        RotateCamera();

        // Zıplama kontrolü
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection = Quaternion.Euler(0, transform.eulerAngles.y, 0) * moveDirection;
        moveDirection.Normalize();

        // Yatay hareket
        Vector3 horizontalMovement = moveDirection * speed * Time.deltaTime;
        rb.MovePosition(rb.position + horizontalMovement);

        // İleri-geri hareket
        Vector3 forwardMovement = new Vector3(0, 0, moveDirection.z) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.TransformDirection(forwardMovement));
    }

    void RotateCamera()
    {
        float rotationY = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, rotationY, 0);

        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minimumVerticalAngle, maximumVerticalAngle);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
