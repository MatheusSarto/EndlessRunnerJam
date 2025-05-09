using Assets.Scripts.Events;
using System;
using UnityEngine;


namespace Assets.Scripts.Characters.Enemies
{
    internal class StandStillEnemy : EnemyBase
    {
        private void Awake()
        {
            ScoreMultiplier = 1.5f;
            EnemyPoints = 200;
            StylePoints = 1.1f;
        }
        protected override ScoreEventData EnemyPointsReward()
        {
            Debug.Log($"Throwing ScoreEventData");
            float score = ScoreMultiplier * EnemyPoints * StylePoints;
            Debug.Log($"Score {score} Points");

            return new ScoreEventData(score, false);
        }
    }
}
