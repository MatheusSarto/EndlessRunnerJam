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

        private bool IsJumping;

        private void Update()
        {
            float forceX = 1f;
            float forceY = 0;
            IMoveVelocity move =  GetComponent<IMoveVelocity>();
            Vector3 forceVector = new Vector3(forceX, forceY).normalized;

            Debug.Log("[PlayerMovementKey] SetMovePosition: Space key pressed, setting forceY to 1");
            Debug.Log($"[PlayerMovementKey] IsJumping {IsJumping}");
            if (Input.GetKeyDown(KeyCode.D))
            {
                forceVector.y = +1f;
                move.SetApplyForce(forceVector);
                Debug.Log("[PlayerMovementKey] SetMovePosition: Space key pressed, setting forceY to 1");
            }
            else 
            {
                IsJumping = false;
            }

            Debug.Log($"[PlayerMovementKey] SetMovePosition: Generated move vector: {forceVector}");
            move.SetVelocity(forceVector);
            Debug.Log($"[PlayerMovementKey] SetMovePosition: Sending velocity");
        }
    }
}
