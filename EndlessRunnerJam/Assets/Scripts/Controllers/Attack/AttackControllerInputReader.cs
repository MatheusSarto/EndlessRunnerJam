using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;
using Assets.Scripts.Configs;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Controllers.Attack
{
    internal class AttackControllerInputReader : MyCharacterController
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
                Debug.Log("Normal Attack Pressed");
                character.Attack();
            }
            if (Input.GetKeyDown(attackControllerConfig.Special1key))
            {
                Debug.Log("Special Attack 1 Pressed");
                character.SpecialAttack(SpecialAttack.Special1);
            }
            if (Input.GetKeyDown(attackControllerConfig.Special2key))
            {
                Debug.Log("Special Attack 2 Pressed");
                character.SpecialAttack(SpecialAttack.Special2);
            }
            if (Input.GetKeyDown(attackControllerConfig.Special3key))
            {
                Debug.Log("Special Attack 3 Pressed");
                character.SpecialAttack(SpecialAttack.Special3);
            }

        }
    }
}
