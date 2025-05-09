using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    //internal class PlayerMovementKey : MonoBehaviour

    //{
    //    [SerializeField]  private MoveVelocityRgBd moveVelocityRgBd; // Direct reference for checking CanJump

    //    public void Move(System.Numerics.Vector3 direction)
    //    {
    //        float forceX = 1f;
    //        float forceY = 0;
    //        IMoveVelocity move = GetComponent<IMoveVelocity>();
    //        Vector3 forceVector = new Vector3(forceX, forceY).normalized;

    //        // Handle jumping when D key is pressed AND player is grounded
    //        if (Input.GetKeyDown(KeyCode.Space) && moveVelocityRgBd != null && moveVelocityRgBd.CanJump)
    //        {
    //            forceVector.y = 1f;
    //            move.Move(forceVector);
    //            Debug.Log("Jump initiated!");
    //        }
    //        Debug.Log($"[PlayerMovementKey] SetMovePosition: Generated move vector: {forceVector}");
    //        move.Move(forceVector);
    //        Debug.Log($"[PlayerMovementKey] SetMovePosition: Sending velocity");
    //    }

    //    private void Start()
    //    {
    //        moveVelocityRgBd = GetComponent<MoveVelocityRgBd>();
    //    }
    //}
}
