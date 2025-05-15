using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.interfaces
{
    internal interface IDash
    {
        void Dash(Vector3 direction, float dashVelocity, float duration);
    }
}
