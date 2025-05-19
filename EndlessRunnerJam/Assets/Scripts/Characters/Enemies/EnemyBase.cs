using Assets.Scripts.Events;
using Assets.Scripts.interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.Characters.Enemies
{
    internal abstract class EnemyBase : CharacterBase
    {

        [SerializeField] protected float ScoreMultiplier;
        [SerializeField] protected float StylePoints;
        [SerializeField] protected float EnemyPoints;

        [SerializeField] protected Collider2D HeadCollider;
        [SerializeField] protected Collider2D HitBox;

        public override void TakeDamage(float damage)
        {
            Life -= damage; 
            if (Life <= 0)
            {
                Debug.Log($"Throwing ScoreEvent");
                new ScoreEvent().Invoke(EnemyPointsReward());

                Destroy(this.transform.root.gameObject);
            }
            Debug.Log($"Took {damage} damage; Current Health: {Life}");
            
        }

        protected abstract ScoreEventData EnemyPointsReward();
    }
}
