using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontallInput;
    float verticalInput;

    public float drag = 1f;


    Vector3 moveDirection;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput()
    {
        horizontallInput = Input.GetAxisRaw(
            "Horizontal"
        );
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontallInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, drag * Time.deltaTime);

    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        MyInput();
    }
}
