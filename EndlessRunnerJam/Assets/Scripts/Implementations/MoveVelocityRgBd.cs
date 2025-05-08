using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class MoveVelocityRgBd : MonoBehaviour, IMoveVelocity
{
    [SerializeField] private Rigidbody2D rigidbody2;
    [SerializeField] private float MoveSeed;
    [SerializeField] private float ForceMutiplier;
    [SerializeField] private CircleCollider2D walkBoxCollider;
    [SerializeField] private Vector3 velocityVector;
    [SerializeField] private Vector3 forceVector;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded; // Renamed for clarity - true when on ground
    public bool CanJump => isGrounded; // Public property for checking if jump is allowed


    private void FixedUpdate()
    {
        if(rigidbody2.linearVelocityX  < MoveSeed)
        {
            rigidbody2.AddForce(velocityVector);
            if(rigidbody2.linearVelocityX > MoveSeed)
            {
                rigidbody2.linearVelocityX = MoveSeed;
            }
        }
    }

    private void Awake()
    {
        // Ensure rigidbody reference is set
        if (rigidbody2 == null)
            rigidbody2 = GetComponent<Rigidbody2D>();

        // Initial ground check
        CheckGrounded();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if we're leaving contact with a ground object
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            // Only set to false if we're not touching any other ground objects
            CheckGrounded();
        }
    }

    private void CheckGrounded()
    {
        // Only run if walkBoxCollider is assigned
        if (walkBoxCollider == null)
            return;

        Collider2D[] contacts = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(groundLayer);

        int contactCount = walkBoxCollider.Overlap(filter, contacts);
        isGrounded = contactCount > 0;
    }

    public void Move(Vector3 velocityVector)
    {
        Debug.Log($"[MoveVelocityRgBd] SetVelocity: Received velocity vector: {velocityVector}");

        if (rigidbody2 != null)
        {
            // Note: This actually fixes a bug - should be using velocity, not linearVelocity
            Vector2 newVelocity = new(velocityVector.x * MoveSeed, this.velocityVector.y);

            Debug.Log($"[MoveVelocityRgBd] SetVelocity: Setting rigidbody2 velocity to {newVelocity} (raw vector * moveSeed {MoveSeed})");
            this.velocityVector = newVelocity;
        }
        else
        {
            Debug.LogError("[MoveVelocityRgBd] SetVelocity: rigidbody2 is null, cannot set velocity!");
        }
    }
}
