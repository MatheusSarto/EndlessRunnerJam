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

        private void Update()
        {
            float forceX = 1f;
            float forceY = 0f;

            Debug.Log("[PlayerMovementKey] SetMovePosition: Space key pressed, setting forceY to 1");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                forceY = +1f;
                Debug.Log("[PlayerMovementKey] SetMovePosition: Space key pressed, setting forceY to 1");
            }

            Vector3 moveVector = new Vector3(forceX, forceY).normalized;
            Debug.Log($"[PlayerMovementKey] SetMovePosition: Generated move vector: {moveVector}");

            Debug.Log($"[PlayerMovementKey] SetMovePosition: Sending velocity");
            GetComponent<IMoveVelocity>().SetVelocity(moveVector);
        }
    }
}
