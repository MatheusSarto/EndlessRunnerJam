using Assets.Scripts.interfaces;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal class MeleeAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private Collider2D HurtBox;
        [SerializeField] private float Duration;
        [SerializeField] private float BaseDamage;
        [SerializeField] private float DamageMultiplier;
        [SerializeField] private Color debugColor = Color.red;

        public bool IsAttacking => _IsAttacking;
        private bool _IsAttacking = false;

        void IAttack.Attack()
        {
            Debug.Log($"HurtBox is Null? {HurtBox == null}");
            if (HurtBox != null)
            {
                StartCoroutine(PerformAttack());
            }
        }

        private IEnumerator PerformAttack()
        {
            _IsAttacking = true;

            HurtBox.enabled = true;

            ContactFilter2D filters = new ContactFilter2D()
            {
                useTriggers = true
            };

            Collider2D[] overlapColliders = new Collider2D[20];
            int collidersCount =  HurtBox.Overlap(filters, overlapColliders);
            Debug.Log($"overlap size: {collidersCount}");
            if(collidersCount > 0)
            {
                Debug.Log($"Damageable Colliders: {string.Join(", ",overlapColliders.Where(c => c != null && c.GetComponent<IDamageable>() != null).Select(x => x.name))}");
                for (int i = 0; i < collidersCount; i++)
                {
                    if (overlapColliders[i] != null && overlapColliders[i].TryGetComponent<IDamageable>(out var damageable))
                    {
                        damageable.TakeDamage(BaseDamage * DamageMultiplier);
                    }
                }
            }
            else
            {
                Debug.Log($"Colliders: 0");

            }
            yield return new WaitForSeconds(Duration);

            HurtBox.enabled = false;
            _IsAttacking = false;
        }


        // Add visualization for the hurtBox in the Scene view
        private void OnDrawGizmos()
        {
            if (HurtBox == null) return;

            // Save the current Gizmos color
            Color originalColor = Gizmos.color;

            // Set the color to red (or debug color if changed in inspector)
            Gizmos.color = debugColor;

            // Draw the collider shape
            if (HurtBox is BoxCollider2D boxCollider)
            {
                // Draw box shape
                Matrix4x4 originalMatrix = Gizmos.matrix;
                Gizmos.matrix = transform.localToWorldMatrix;

                Vector2 center = boxCollider.offset;
                Vector2 size = boxCollider.size;

                // Draw wireframe box
                Gizmos.DrawWireCube(center, size);

                // Restore matrix
                Gizmos.matrix = originalMatrix;
            }
            else if (HurtBox is CircleCollider2D circleCollider)
            {
                // Draw circle shape
                Vector3 center = transform.TransformPoint(circleCollider.offset);
                float radius = circleCollider.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);

                Gizmos.DrawWireSphere(center, radius);
            }
            else if (HurtBox is CapsuleCollider2D capsuleCollider)
            {
                // Draw capsule approximation
                Vector3 center = transform.TransformPoint(capsuleCollider.offset);
                Vector2 size = capsuleCollider.size;

                // Scale by transform scale
                size.x *= transform.lossyScale.x;
                size.y *= transform.lossyScale.y;

                // Draw approximation of capsule using a wire sphere
                Gizmos.DrawWireSphere(center, Mathf.Min(size.x, size.y) * 0.5f);
            }

            // For active colliders, also draw filled version
            if (_IsAttacking || HurtBox.enabled)
            {
                // Make semi-transparent filled version
                Color fillColor = debugColor;
                fillColor.a = 0.2f;
                Gizmos.color = fillColor;

                if (HurtBox is BoxCollider2D boxCollider2)
                {
                    Matrix4x4 originalMatrix = Gizmos.matrix;
                    Gizmos.matrix = transform.localToWorldMatrix;

                    Vector2 center = boxCollider2.offset;
                    Vector2 size = boxCollider2.size;

                    Gizmos.DrawCube(center, size);

                    Gizmos.matrix = originalMatrix;
                }
                else if (HurtBox is CircleCollider2D circleCollider2)
                {
                    Vector3 center = transform.TransformPoint(circleCollider2.offset);
                    float radius = circleCollider2.radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y);

                    Gizmos.DrawSphere(center, radius);
                }
            }

            // Restore the original color
            Gizmos.color = originalColor;
        }
    }
}
