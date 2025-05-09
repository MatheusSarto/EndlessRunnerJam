using Assets.Scripts.Enums;
using Assets.Scripts.Events;
using Assets.Scripts.interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    internal abstract class CharacterBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected float Life;
        [SerializeField] protected IMoveVelocity moveable; 
        [SerializeField] protected IJump jump;

        [SerializeField] protected IAttack attack;
        [SerializeField] protected ISpecialAttack[] specialAttack = new ISpecialAttack[3];


        [SerializeField] protected Collider2D walkBoxCollider;
        [SerializeField] protected LayerMask groundLayer;

        [SerializeField] protected Vector3 currentVelocityVector;
        [SerializeField] protected Vector3 maxVelocity;

        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float jumpForce;

        protected bool isGrounded;
        protected abstract bool CanJump { get; }
        protected abstract bool CanWalk { get; }
        protected bool canWalk;

        public abstract void TakeDamage(float damage);

        public void Jump(Vector3 direction)
        {
            if (CanJump)
            {
                jump?.Jump(direction);
            }
        }

        public void Move(Vector3 direction)
        {
            if(CanWalk)
            {
                moveable?.Move(direction);
            }
        }

        public void Attack()
        {
            attack?.Attack();
        }
        public void SpecialAttack(SpecialAttack special)
        {
            specialAttack[(int)special]?.Special();
        }

        private void Awake()
        {
            moveable = GetComponent<IMoveVelocity>();
            jump = GetComponent<IJump>();
            Debug.Log($"Moveable é null? {moveable == null}");

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

        protected void CheckGrounded()
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
