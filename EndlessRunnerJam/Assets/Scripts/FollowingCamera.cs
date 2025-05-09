using UnityEngine;
namespace Assets.Scripts
{ 
    public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;
    [SerializeField] private Transform followerObject;

    [SerializeField] private Vector3 offset;

   
    [SerializeField] private Transform finalPosition;
    [SerializeField] private Vector3 startAnimantionOffset;
    [SerializeField] private bool isOnAnimation;
    [SerializeField] private Vector2 animationVelocity;


    private void Awake()
    {

        //followerObject.position = new Vector3(
        //    ObjectToFollow.position.x + startAnimantionOffset.x,
        //    ObjectToFollow.position.y + startAnimantionOffset.y,
        //    followerObject.position.z + startAnimantionOffset.z);
    }
    private void Update()
    {
        followerObject.position = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y, followerObject.position.z);
        //if(isOnAnimation)
        //{
        //    BeginGameCameraAnimation();
        //}
        //else
        //{
        //    FollowPlayer();
        //}

    }

    private void FollowPlayer()
    {
        followerObject.position = new Vector3(ObjectToFollow.position.x + offset.x, ObjectToFollow.position.y + offset.y, followerObject.position.z + offset.z);
    }

    private void BeginGameCameraAnimation()
    {
        if(followerObject.position.x < finalPosition.position.x + offset.x ||
            followerObject.position.y < finalPosition.position.y + offset.y)
        {
            float posX = followerObject.position.x < finalPosition.position.x 
                ? followerObject.position.normalized.x * finalPosition.position.x  : finalPosition.position.x;

            float posY = followerObject.position.y < finalPosition.position.y
                ? followerObject.position.normalized.y * finalPosition.position.y : finalPosition.position.y;
            
            
            followerObject.position = new Vector3(posX, posY, followerObject.position.z);
        }
        else 
        {
            followerObject.position = new Vector3(finalPosition.position.x, finalPosition.position.y, followerObject.position.z);
            isOnAnimation = false; 
        }
    }

}
}
