using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.interfaces
{

    internal interface IMoveVelocity
    {
        /// <summary>
        /// Sets the velocity of the object - Rigidbody2D ( physics ), Transform ( direct position ), etc.
        /// </summary>
        void SetVelocity(Vector3 velocityVector);
    }
}
