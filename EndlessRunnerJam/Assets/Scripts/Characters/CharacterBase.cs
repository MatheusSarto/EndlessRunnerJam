using Assets.Scripts.Attacks;
using Assets.Scripts.Enums;
using Assets.Scripts.Events;
using Assets.Scripts.interfaces;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts.Characters
{
    internal abstract class CharacterBase : MonoBehaviour, IDamageable
    {
        [SerializeField] public float JumpForce { get { return jumpForce; } }
        [SerializeField] public float MoveSpeed { get { return moveSpeed; } }

        [SerializeField] protected float Life;
        [SerializeField] protected IMoveVelocity moveable; 
        [SerializeField] protected IJump jump;
        [SerializeField] protected IDash dash;

        [SerializeField] protected IAttack attack;

        protected ISpecialAttack[] specialAttacks = new ISpecialAttack[3];


        [SerializeField] protected Collider2D walkBoxCollider;
        [SerializeField] protected LayerMask groundLayer;


        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float jumpForce;

        protected bool isGrounded;
        protected bool isAttacking;
        protected bool isSpecialAttacking;
        protected abstract bool CanJump { get; }
        protected abstract bool CanWalk { get; }
        protected bool canWalk;

        public abstract void TakeDamage(float damage);

        private void Update()
        {
            CheckGrounded();
        }

        private void Awake()
        {
            moveable = GetComponent<IMoveVelocity>();
            jump = GetComponent<IJump>();
            Debug.Log($"Moveable é null? {moveable == null}");

            // Initial ground check
            CheckGrounded();

            specialAttacks = GetComponents<ISpecialAttack>().Take(3).ToArray();
            attack = GetComponent<IAttack>();
        }

        public void Jump(Vector3 direction)
        {
            Debug.Log($"Can Jump '{CanJump}'");
            Debug.Log($"Directions '{direction.ToString()}'");
            if (CanJump)
            {
                jump?.Jump(direction);
            }
        }

        public void Move(Vector3 direction)
        {
            if(CanWalk && !isSpecialAttacking)
            {
                Debug.Log($"Character Base - Move");
                Debug.Log($"Character Base directions - {direction.ToString()}");
                moveable?.Move(direction);
            }
        }

        public void Attack()
        {
            attack?.Attack();
        }
        public void SpecialAttack(SpecialAttack special)
        {
            if(!isSpecialAttacking)
            {
                isSpecialAttacking = true;
                Debug.Log($"Special Attack {(int)special} is null: {specialAttacks[(int)special] == null}");
                specialAttacks[(int)special]?.Special();

                StartCoroutine(StopSpecialAttack(specialAttacks[(int)special].Duration));
            }
        }

        private IEnumerator StopSpecialAttack(float duration)
        {
            yield return new WaitForSeconds(duration);
            isSpecialAttacking = false;
        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        //    {
        //        isGrounded = true;
        //    }
        //}

        //private void OnCollisionExit2D(Collision2D collision)
        //{
        //    // Check if we're leaving contact with a ground object
        //    if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        //    {
        //        // Only set to false if we're not touching any other ground objects
        //        CheckGrounded();
        //    }
        //}

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
