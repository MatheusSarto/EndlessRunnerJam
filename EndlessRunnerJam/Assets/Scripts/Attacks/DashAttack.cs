using Assets.Scripts.Characters;
using Assets.Scripts.interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    internal class DashAttack : MonoBehaviour, ISpecialAttack
    {
        [SerializeField] private CharacterBase character;
        [SerializeField] private Vector2 direction;
        [SerializeField] private IDash dash;
        [SerializeField] private float attackVelocity;
        [SerializeField]  private float duration = 0.7f;

        private void Start()
        {
            dash = GetComponent<IDash>();
            Debug.Log($"IDash component found: {dash != null}");
            character = GetComponent<CharacterBase>();

        }
        public void Special()
        {
            dash.Dash(direction, attackVelocity, duration);
            StartCoroutine(StopSpecialAttack(duration));
        }

        private IEnumerator StopSpecialAttack(float duration)
        {
            yield return new WaitForSeconds(duration);
            character.isSpecialAttacking = false;
        }

    }
}
