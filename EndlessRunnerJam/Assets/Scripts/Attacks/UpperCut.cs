using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    internal class UpperCut : MonoBehaviour, ISpecialAttack
    {
        [SerializeField] private Vector2 direction;
        [SerializeField] private float attackVelocity;
        [SerializeField] private IDash dash;

        [SerializeField] public float Duration => duration;
        [SerializeField] private float duration = 0.7f;
        public void Special()
        {
            dash.Dash(direction, attackVelocity, Duration);
            Debug.Log($"IDash component found: {dash != null}");
        }

        private void Start()
        {
            dash = GetComponent<IDash>();
        }
    }
}
