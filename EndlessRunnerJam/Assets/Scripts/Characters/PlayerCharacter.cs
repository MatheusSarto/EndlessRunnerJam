using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    internal class PlayerCharacter : CharacterBase
    {
        protected override bool CanJump => isGrounded;
        protected override bool CanWalk => true;
        [SerializeField] protected Collider2D CheckGroundCollider;
        [SerializeField] protected LayerMask groundLayer;
        public override void TakeDamage(float damage)
        {
            Life -= damage;
        }

        private void Update()
        {
            CheckGrounded();
        }
        protected override void Awake()
        {
            base.Awake();
            CheckGrounded();
        }
        protected void CheckGrounded()
        {
            // Only run if walkBoxCollider is assigned
            if (CheckGroundCollider == null)
                return;

            Collider2D[] contacts = new Collider2D[10];
            ContactFilter2D filter = new();
            filter.SetLayerMask(groundLayer);

            int contactCount = CheckGroundCollider.Overlap(filter, contacts);
            isGrounded = contactCount > 0;
        }
    }
}
