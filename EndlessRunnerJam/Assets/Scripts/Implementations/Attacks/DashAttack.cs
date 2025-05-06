using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations.Attacks
{
    internal class DashAttack : MonoBehaviour, IDashAttack
    {

        [SerializeField] private Rigidbody2D characterRb;
        [SerializeField] private float dashForceUpwards;
        [SerializeField] private float dashForceDownwards;
        [SerializeField] private float dashForceForward;

        public void DashAttackDownwards()
        {
            Vector3 force = new Vector3(1, dashForceDownwards);
            characterRb.AddForce(force, ForceMode2D.Impulse);
        }

        public void DashAttackUpwards()
        {

            Vector3 force = new Vector3(1, dashForceUpwards);
            characterRb.AddForce(force, ForceMode2D.Impulse);
        }

        void IDashAttack.DashAttackForward()
        {
            Vector3 force = new Vector3(dashForceForward, 1);

            characterRb.AddForce(force, ForceMode2D.Impulse);

        }
    }
}
