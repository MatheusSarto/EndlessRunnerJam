using Assets.Scripts.Characters;
using Assets.Scripts.Implementations;
using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts.Controllers
{
    internal class CharacterController : MonoBehaviour
    {
        [SerializeField] protected CharacterBase character;
    }

}
