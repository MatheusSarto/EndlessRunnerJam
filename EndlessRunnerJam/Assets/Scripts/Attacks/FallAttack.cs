using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;
using Assets.Scripts.Characters;

namespace Assets.Scripts.Attacks
{
    internal class FallAttack : MonoBehaviour, ISpecialAttack
    {
        [SerializeField] private Vector2 direction;
        [SerializeField] private float attackVelocity;
        [SerializeField] private CharacterBase character;
        [SerializeField] private Collider2D hitBox;
        private void Start()
        {
            character = GetComponent<CharacterBase>();
        }
        public void Special()
        {
          
        }
    }
}
