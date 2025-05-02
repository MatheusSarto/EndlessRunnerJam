using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.interfaces
{
    internal interface IMovePosition
    {
        /// <summary>
        /// Works as the type of input used to control de object - Mouse, Keyboard, AI, etc.
        /// </summary>
        void SetMovePosition();
    }
}
