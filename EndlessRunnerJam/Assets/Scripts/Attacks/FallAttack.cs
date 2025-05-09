using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    internal class FallAttack : ISpecialAttack
    {
        [SerializeField] private Vector3 dashDistance;
        [SerializeField] private IMoveVelocity moveable;
        [SerializeField] private float attackSpeed;


        public void Special()
        {
            moveable.Move(new Vector3(dashDistance.x, dashDistance.y * attackSpeed * -1));
        }
    }
}
