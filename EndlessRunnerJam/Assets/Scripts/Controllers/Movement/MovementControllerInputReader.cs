using Assets.Scripts.Configs;
using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.Movement
{
    internal class MovementControllerInputReader : MonoBehaviour, IMovementInputReader
    {
        [SerializeField] private MovementControllerConfig movementControllerConfig;

        private void Awake()
        {
            if (movementControllerConfig == null)
            {
                movementControllerConfig = new MovementControllerConfig()
                {
                    MoveYpos = KeyCode.Space
                };
            }
        }

        public Vector3 SetDirection()
        {
            float dirY = 0;
            if (Input.GetKeyDown(movementControllerConfig.MoveYpos))
            {
                Debug.Log("Jump Key Pressed");
                dirY = 1f;
            }
       

            return new Vector3(1, dirY);
        }
    }
}
