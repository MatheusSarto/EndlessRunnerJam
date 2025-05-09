using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts.Controllers.Movement
{
    internal class MovementController : Controllers.CharacterController
    {
        [SerializeField] protected IMovementInputReader inputReader;
        private Vector3 movementDirection;

        private void Awake()
        {
            Debug.Log("Awake MovementController");
            Debug.Log("Movement Controller Character Reference is Null? " + character == null );


            inputReader = GetComponent<IMovementInputReader>();
            Debug.Log("Movement Controller Input Reader is Null? " + inputReader == null );
        }
        // Read Inputs
        private void Update()
        {
            movementDirection = inputReader.SetDirection();
        }

        // Execute Movement Based on Inputs Read
        private void FixedUpdate()
        {
            character.Move(movementDirection);
            character.Jump(movementDirection);
        }
    }
}
