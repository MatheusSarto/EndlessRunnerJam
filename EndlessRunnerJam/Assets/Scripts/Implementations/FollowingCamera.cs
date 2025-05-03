using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;

    [Header("Bounce Effect Settings")]
    [SerializeField] private bool enableBounceEffect = true;

    [Tooltip("Higher values make camera follow more quickly")]
    [Range(1f, 8f)]
    [SerializeField] private float springStrength = 5f;

    [Tooltip("Higher values reduce oscillation")]
    [Range(0.5f, 6f)]
    [SerializeField] private float dampingStrength = 4f;

    [Tooltip("Overall intensity of the bounce")]
    [Range(0f, 0.5f)]
    [SerializeField] private float bounceAmplitude = 0.1f;

    [Tooltip("Anticipate player movement (good for runners)")]
    [Range(0f, 3f)]
    [SerializeField] private float lookAheadFactor = 1.5f;

    [Tooltip("How much to smooth vertical motion")]
    [Range(0.1f, 5f)]
    [SerializeField] private float verticalSmoothFactor = 2f;

    // Variables for bounce physics
    private Vector3 velocity = Vector3.zero;
    private Vector3 previousTargetPos;
    private Vector3 targetVelocity = Vector3.zero;
    private Vector3 targetPosition;
    private Vector3 currentPosition;

    private void Awake()
    {
        // Initialize positions
        if (ObjectToFollow != null)
        {
            targetPosition = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y, transform.position.z);
            currentPosition = targetPosition;
            previousTargetPos = targetPosition;
        }
    }

    private void LateUpdate()
    {
        if (ObjectToFollow == null)
            return;

        // Calculate target velocity for look-ahead effect
        Vector3 currentTargetPos = ObjectToFollow.position;
        targetVelocity = (currentTargetPos - previousTargetPos) / Time.deltaTime;
        previousTargetPos = currentTargetPos;

        // Look ahead based on target velocity (mostly in X direction for runners)
        Vector3 lookAheadPos = currentTargetPos + new Vector3(targetVelocity.x * lookAheadFactor, 0, 0);

        // Update target position with look-ahead and z-preservation
        targetPosition = new Vector3(
            lookAheadPos.x,
            Mathf.Lerp(transform.position.y, lookAheadPos.y, Time.deltaTime * verticalSmoothFactor),
            transform.position.z
        );

        if (enableBounceEffect)
            ApplySmoothBounceEffect();
        else
            transform.position = targetPosition;
    }

    private void ApplySmoothBounceEffect()
    {
        // Get current position
        currentPosition = transform.position;

        // Calculate spring force - smoother by decreasing the spring strength
        Vector3 displacement = targetPosition - currentPosition;
        Vector3 springForce = displacement * springStrength;

        // Apply increased damping for smoother endless runner camera
        Vector3 dampingForce = -velocity * dampingStrength;

        // Calculate acceleration with reduced amplitude for subtlety
        Vector3 acceleration = (springForce + dampingForce) * bounceAmplitude;

        // Apply more smoothing to vertical axis
        acceleration.y *= 0.8f;

        // Update velocity with deltaTime squared for more stability
        velocity += acceleration * Time.deltaTime;

        // Limit maximum velocity to prevent overshooting
        float maxVelocity = 20f;
        if (velocity.magnitude > maxVelocity)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
        }

        // Update position
        currentPosition += velocity * Time.deltaTime;

        // Apply the new position
        transform.position = currentPosition;
    }
}
