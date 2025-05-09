using Assets.Scripts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Characters
{
    internal class PlayerCharacter : CharacterBase
    {
        protected override bool CanJump => isGrounded;
        protected override bool CanWalk => true;

        public override void TakeDamage(float damage)
        {
            Life -= damage;
        }
    }
}
