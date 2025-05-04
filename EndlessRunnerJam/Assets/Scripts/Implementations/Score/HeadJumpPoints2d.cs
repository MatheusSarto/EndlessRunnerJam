using Assets.Scripts.Events;
using Assets.Scripts.interfaces;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal class HeadJumpPoints2d : IScoreable
    {
        [SerializeField] private Collider2D HeadCollider;

        [SerializeField] private float ScoreMultiplier;
        [SerializeField] private float StylePoints;
        [SerializeField] private bool IsCritical;

        public void SetScorePoints(float points)
        {
            new ScoreEvent().Invoke(new ScoreEventData((StylePoints * ScoreMultiplier) * ScoreManager.GetInstance().GetScoreMultiplier(), IsCritical));
        }
    }
}
