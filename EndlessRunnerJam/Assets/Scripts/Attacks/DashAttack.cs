using Assets.Scripts.interfaces;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    internal class DashAttack : MonoBehaviour, ISpecialAttack
    {
        [SerializeField] private Vector2 direction;
        [SerializeField] private IDash dash;
        [SerializeField] private float attackVelocity;
        [SerializeField]  public float Duration => duration;
        [SerializeField]  private float duration = 0.7f;

        private void Start()
        {
            dash = GetComponent<IDash>();
            Debug.Log($"IDash component found: {dash != null}");
        }
        public void Special()
        {
            dash.Dash(direction, attackVelocity, Duration);
        }

    }
}
