using Assets.Scripts.Characters;
using Assets.Scripts.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class DashRgBd2 : MonoBehaviour, IDash
    {
        [SerializeField] private Rigidbody2D characterRbd2;
        [SerializeField] private bool isDashing;

        public void Dash(Vector3 direction, float dashVelocity, float duration)
        {
            if (!isDashing)
            {
                isDashing = true;
                characterRbd2.linearVelocity = direction.normalized * dashVelocity;
                StopSpecialAttack(duration);
            }
        }

        private IEnumerator StopSpecialAttack(float duration)
        {
            yield return new WaitForSeconds(duration);
            isDashing = false;
        }


        private void Awake()
        {
            characterRbd2 = GetComponent<Rigidbody2D>();
        }
    }
}
