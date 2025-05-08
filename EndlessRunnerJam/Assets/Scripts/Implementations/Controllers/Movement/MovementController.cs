using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts.Implementations.Controllers
{
    internal class MovementController : CharacterController
    {
        /// <summary>
        /// Character this controller Controlls
        /// </summary>
        [SerializeField] protected ISetVeloctiy inputReader;
        private Vector3 direction;

        private void Awake()
        {
            Debug.Log("Awake MovementController");
            Debug.Log("Movement Controller Character Reference is Null? " + character == null );


            inputReader = GetComponent<ISetVeloctiy>();
            Debug.Log("Movement Controller Input Reader is Null? " + inputReader == null );
        }
        // Leitura dos inputs
        private void Update()
        {
            direction = inputReader.SetVelocity();
        }

        // Chamada dos inputs
        private void FixedUpdate()
        {
            character.moveable.Move(direction);

        }
    }
}
