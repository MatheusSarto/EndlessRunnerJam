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
    internal class UpperCut :  ISpecialAttack
    {
        [SerializeField] private Vector3 dashDistance;
        [SerializeField] private float attackSpeed;
        [SerializeField] private IMoveVelocity moveable;

        public void Special()
        {
            moveable.Move(new Vector3(dashDistance.x, dashDistance.y * attackSpeed));
        }
    }
}
