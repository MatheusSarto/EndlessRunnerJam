using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal class PlayerMovementKey : MonoBehaviour
    {
        [SerializeField]  private MoveVelocityRgBd moveVelocityRgBd; // Direct reference for checking CanJump

        private void Start()
        {
            moveVelocityRgBd = GetComponent<MoveVelocityRgBd>();
        }
        private void Update()
        {
            float forceX = 1f;
            float forceY = 0;
            IMoveVelocity move =  GetComponent<IMoveVelocity>();
            Vector3 forceVector = new Vector3(forceX, forceY).normalized;

            // Handle jumping when D key is pressed AND player is grounded
            if (Input.GetKeyDown(KeyCode.Space) && moveVelocityRgBd != null && moveVelocityRgBd.CanJump)
            {
                forceVector.y = 1f;
                move.SetApplyForce(forceVector);
                Debug.Log("Jump initiated!");
            }
            Debug.Log($"[PlayerMovementKey] SetMovePosition: Generated move vector: {forceVector}");
            move.SetVelocity(forceVector);
            Debug.Log($"[PlayerMovementKey] SetMovePosition: Sending velocity");
        }
    }
}
