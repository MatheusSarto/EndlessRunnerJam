using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts.Implementations.Controllers.Attack
{
    internal class AttackControllerInputReader : CharacterController
    {
        [SerializeField] private AttackControllerConfig attackControllerConfig;

        private void Awake()
        {
            if(attackControllerConfig == null)
            {
                attackControllerConfig = new AttackControllerConfig()
                {
                    AttackKey = KeyCode.A,
                    Special1key = KeyCode.S,
                    Special2key = KeyCode.D,
                    Special3key = KeyCode.F
                };
            }
        }

        private void Update()
        {

            if(Input.GetKeyDown(attackControllerConfig.AttackKey))
            {
                character.attack.Attack();
            }
            if (Input.GetKeyDown(attackControllerConfig.Special1key))
            {
                character.specialAttack1.Special1();
            }
            if (Input.GetKeyDown(attackControllerConfig.Special2key))
            {
                character.specialAttack2.Special2();
            }
            if (Input.GetKeyDown(attackControllerConfig.Special3key))
            {
                character.specialAttack3.Special3();
            }

        }
    }
}
