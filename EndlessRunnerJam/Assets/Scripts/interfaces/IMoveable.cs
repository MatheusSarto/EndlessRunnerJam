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
        /// Moves the object setting it's position - Rigidbody2D ( physics - velocity ), Transform ( direct position ), etc.
        /// </summary>
        void Move(Vector3 direction);
    }
}
