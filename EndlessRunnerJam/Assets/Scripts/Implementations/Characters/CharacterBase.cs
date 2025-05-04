using Assets.Scripts.Events;
using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal abstract class CharacterBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected float Life;

        public abstract void TakeDamage(float damage);
    }
}
