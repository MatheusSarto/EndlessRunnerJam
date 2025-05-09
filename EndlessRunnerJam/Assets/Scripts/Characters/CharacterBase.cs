using Assets.Scripts.Events;
using Assets.Scripts.interfaces;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    internal abstract class CharacterBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected float Life;
        [SerializeField] public IMoveVelocity moveable {  get; protected set; }   
        [SerializeField] public IJump jump { get; protected set; }

        [SerializeField] public IAttack attack { get; protected set; }
        [SerializeField] public ISpecialAttack[] specialAttack { get; protected set; } = new ISpecialAttack[3]; 

        public abstract void TakeDamage(float damage);


        private void Awake()
        {
            moveable = GetComponent<IMoveVelocity>();
            jump = GetComponent<IJump>();
            Debug.Log($"Moveable é null? {moveable == null}");
        }
    }
}
