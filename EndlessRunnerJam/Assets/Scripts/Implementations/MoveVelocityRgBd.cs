using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using UnityEngine;

public class MoveVelocityRgBd : MonoBehaviour, IMoveVelocity
{
    [SerializeField] private Rigidbody2D rigidbody2;
    [SerializeField] private float MoveSeed;
    [SerializeField] private float ForceMutiplier;
    [SerializeField] private CharacterBase CharacterBase;
    [SerializeField] private Vector3 velocityVector;
    [SerializeField] private Vector3 forceVector;

  
    private void FixedUpdate()
    {
        rigidbody2.linearVelocity = this.velocityVector;
        if(Vector3.zero != forceVector)
        {
            rigidbody2.AddForce(forceVector, ForceMode2D.Impulse);
            forceVector = Vector3.zero;
        }

        Debug.Log($"jumping with force: {forceVector}");
    }

    public void SetVelocity(Vector3 velocityVector)
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

    public void SetApplyForce(Vector3 force)
    {
        forceVector = new Vector3(force.x, force.y * ForceMutiplier);
    }
}
