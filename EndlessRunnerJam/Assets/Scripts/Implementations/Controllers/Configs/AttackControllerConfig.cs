using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations.Controllers
{
    internal class AttackControllerConfig
    {
        [SerializeField] public KeyCode AttackKey;

        [SerializeField] public KeyCode Special1key;
        [SerializeField] public KeyCode Special2key;
        [SerializeField] public KeyCode Special3key;
    }
}
