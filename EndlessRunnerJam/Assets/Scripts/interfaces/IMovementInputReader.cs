using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.interfaces
{
    internal interface IMovementInputReader
    {
        /// <summary>
        /// Sets the direction that the pressed input represents
        /// </summary>
        /// <returns></returns>
        Vector3 SetDirection();
    }
}
