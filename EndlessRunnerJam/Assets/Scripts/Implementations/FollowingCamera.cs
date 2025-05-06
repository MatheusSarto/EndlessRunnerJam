using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;
    [SerializeField] private Transform followerObject;

    [SerializeField] private Vector3 offset;

   

    private void Update()
    {

        followerObject.position = new Vector3(ObjectToFollow.position.x + offset.x, ObjectToFollow.position.y + offset.y, followerObject.position.z + offset.z);  
        
    }


}
