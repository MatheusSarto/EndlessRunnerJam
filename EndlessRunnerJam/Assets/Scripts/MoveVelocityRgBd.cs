using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using Unity.VisualScripting;
using UnityEngine;
namespace Assets.Scripts
{
    public class MoveVelocityRgBd : MonoBehaviour, IMoveVelocity, IJump
    {
        [SerializeField] private Rigidbody2D rigidbody2;
        [SerializeField] private CircleCollider2D walkBoxCollider;
        [SerializeField] private LayerMask groundLayer;

        [SerializeField] private Vector3 currentVelocityVector;
        [SerializeField] private Vector3 maxVelocity;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        private bool isGrounded; // Renamed for clarity - true when on ground
        public bool CanJump => isGrounded; // Public property for checking if jump is allowed

        public void Move(Vector3 direction)
        {

            if (rigidbody2 != null)
            {
                Vector2 newVelocity = new(direction.x * moveSpeed, rigidbody2.linearVelocityY);

                this.currentVelocityVector = newVelocity;
            }
     
        }

        public void Jump(Vector3 direction)
        {
            Debug.Log($"Pode Pular? {CanJump}");
            if(CanJump)
            {
                Debug.Log($"Pulando! Força = {new Vector2(0, jumpForce * direction.y)}");
                rigidbody2.AddForce(new Vector2(0, jumpForce * direction.y), ForceMode2D.Impulse);
            }
            Debug.Log($"Pode Pular? {CanJump}");
        }

        private void FixedUpdate()
        {
            rigidbody2.linearVelocity = currentVelocityVector;   
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

    }
}
