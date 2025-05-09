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
    internal class MovementControllerInputReader : MonoBehaviour, ISetVeloctiy
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

        public Vector3 SetVelocity()
        {
            float dirY = 0.0f;
            if (Input.GetKeyDown(movementControllerConfig.MoveYpos))
            {
                dirY = 1.0f;
            }

            return new Vector3(1, dirY);
        }
    }
}
