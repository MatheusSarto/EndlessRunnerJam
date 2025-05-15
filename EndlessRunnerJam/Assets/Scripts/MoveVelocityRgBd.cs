using Assets.Scripts.Characters;
using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using Unity.VisualScripting;
using UnityEngine;
namespace Assets.Scripts
{
    public class MoveVelocityRgBd : MonoBehaviour, IMoveVelocity, IJump
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private Vector3 velocity;


        [SerializeField]  private Rigidbody2D rigidbody2;


        public void Move(Vector3 direction)
        {

            if (rigidbody2 != null)
            {
                Debug.Log($"Direção de movimento ={direction.ToString()}");
                Vector2 newVelocity = new(direction.x * moveSpeed, rigidbody2.linearVelocity.y);
                Debug.Log($"Nova Velocidade ={newVelocity.ToString()}");

                this.velocity = newVelocity;

                Debug.Log($"Esta mais devagar que o minimo? {rigidbody2.linearVelocity.x < moveSpeed}");
                Debug.Log($"CurrentVelocity.x ={rigidbody2.linearVelocity.x}");
                if (rigidbody2.linearVelocity.x != moveSpeed)
                {
                    Debug.Log($"MoveVelocityRgBd - changing character velocity");
                    rigidbody2.linearVelocity = velocity;
                }
            }
     
        }

        public void Jump(Vector3 direction)
        {
            Debug.Log($"Pulando! Força = {new Vector2(0, jumpForce * direction.y)}");
            rigidbody2.AddForce(new Vector2(0, jumpForce * direction.y), ForceMode2D.Impulse);
        }

        private void Update()
        {

        }

        private void Start()
        {
            CharacterBase character = GetComponent<CharacterBase>();
            // Ensure rigidbody reference is set
            if (rigidbody2 == null)
                rigidbody2 = GetComponent<Rigidbody2D>();
                // In Start() or Awake() of your player controller
                rigidbody2.collisionDetectionMode = CollisionDetectionMode2D.Continuous;


            moveSpeed = character.MoveSpeed;
            jumpForce = character.JumpForce;
            Debug.Log($"Character MoveSpeed: {moveSpeed}");
            Debug.Log($"Character jumpForce: {jumpForce}");
        }
    }
}
