using Assets.Scripts.interfaces;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    internal class DashAttack : ISpecialAttack
    {
        [SerializeField] private Vector3 dashDistance;
        [SerializeField] private IMoveVelocity moveable;
        [SerializeField] private float attackSpeed;

        public void Special()
        {
            
            moveable.Move(new Vector3(dashDistance.x * attackSpeed, dashDistance.y));
        }
    }
}
