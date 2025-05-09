using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;
using Assets.Scripts.Configs;

namespace Assets.Scripts.Controllers.Attack
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
                character.specialAttack[0]?.Special();
            }
            if (Input.GetKeyDown(attackControllerConfig.Special2key))
            {
                character.specialAttack[1]?.Special();
            }
            if (Input.GetKeyDown(attackControllerConfig.Special3key))
            {
                character.specialAttack[2]?.Special();
            }

        }
    }
}
