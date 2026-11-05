
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.5f;
    [SerializeField] private float groundDistance = 0.65f;

    private Rigidbody rb;
    private bool jumpRequested;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;
    }

    private void FixedUpdate()
    {
        if (!jumpRequested) return;

        jumpRequested = false;

        bool grounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            groundDistance,
            ~0,
            QueryTriggerInteraction.Ignore
        );

        if (grounded)
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.VelocityChange
            );
        }
    }
}

