using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using UnityEngine;

public class MoveVelocityRgBd : MonoBehaviour, IMoveVelocity
{
    [SerializeField] private Rigidbody2D rigidbody2;
    [SerializeField] private float MoveSeed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private CharacterBase CharacterBase;
    [SerializeField] private Vector3 velocityVector;

    public void Awake()
    {
        Debug.Log("Getting rgbd2");
        rigidbody2 = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        rigidbody2.linearVelocity = this.velocityVector;
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        Debug.Log($"[MoveVelocityRgBd] SetVelocity: Received velocity vector: {velocityVector}");

        if (rigidbody2 != null)
        {
            // Note: This actually fixes a bug - should be using velocity, not linearVelocity
            Vector2 newVelocity = new Vector2(velocityVector.x * MoveSeed, velocityVector.y * JumpHeight) ;
            Debug.Log($"[MoveVelocityRgBd] SetVelocity: Setting rigidbody2 velocity to {newVelocity} (raw vector * moveSeed {MoveSeed})");
            this.velocityVector = newVelocity;
        }
        else
        {
            Debug.LogError("[MoveVelocityRgBd] SetVelocity: rigidbody2 is null, cannot set velocity!");
        }
    }
}
