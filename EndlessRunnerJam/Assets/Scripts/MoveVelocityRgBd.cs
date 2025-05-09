using Assets.Scripts.Characters;
using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using Unity.VisualScripting;
using UnityEngine;
namespace Assets.Scripts
{
    public class MoveVelocityRgBd : MonoBehaviour, IMoveVelocity, IJump
    {
        [SerializeField] private CharacterBase character;

        [SerializeField] private Vector3 currentVelocityVector;
        [SerializeField] private Vector3 maxVelocity;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        private Rigidbody2D rigidbody2;


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
            Debug.Log($"Pulando! Força = {new Vector2(0, jumpForce * direction.y)}");
            rigidbody2.AddForce(new Vector2(0, jumpForce * direction.y), ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            rigidbody2.linearVelocity = currentVelocityVector;   
        }

        private void Awake()
        {
            // Ensure rigidbody reference is set
            if (rigidbody2 == null)
                rigidbody2 = character.GetComponent<Rigidbody2D>();

        }
    }
}
