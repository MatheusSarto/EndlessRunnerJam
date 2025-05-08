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
        [SerializeField] public IMoveVelocity moveable {  get; protected set; }   
        [SerializeField] public IJump jump { get; protected set; }

        [SerializeField] public IAttack attack { get; protected set; }
        [SerializeField] public ISpecialAttack1 specialAttack1 { get; protected set; }
        [SerializeField] public ISpecialAttack2 specialAttack2 { get; protected set; }
        [SerializeField] public ISpecialAttack3 specialAttack3 { get; protected set; }

        public abstract void TakeDamage(float damage);


        private void Awake()
        {
            moveable = GetComponent<IMoveVelocity>();
            Debug.Log($"Moveable é null? {moveable == null}");
        }
    }
}
