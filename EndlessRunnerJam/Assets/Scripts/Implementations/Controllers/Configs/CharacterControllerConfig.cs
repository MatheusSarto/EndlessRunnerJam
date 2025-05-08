using Assets.Scripts.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations.Controllers
{
    internal class MovementControllerConfig
    {
        [SerializeField] public KeyCode MoveXpos; 
        [SerializeField] public KeyCode MoveXneg; 
        [SerializeField] public KeyCode MoveYpos; 
        [SerializeField] public KeyCode MoveYneg;
    }


}
