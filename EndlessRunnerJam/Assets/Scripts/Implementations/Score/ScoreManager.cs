using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal class ScoreManager : MonoBehaviour, IScore
    {
        private static ScoreManager Instance;
        [SerializeField] private double Score;
        [SerializeField] private float ScoreMultiplier;

        public static ScoreManager GetInstance() { return Instance; }  
        public float GetScoreMultiplier() { return ScoreMultiplier; }  
        public double GetTotalScore()
        {
            return Score;
        }

        private void Update()
        {
            // listen to events of IScoreable and add it to score
            
        }

    }
}
