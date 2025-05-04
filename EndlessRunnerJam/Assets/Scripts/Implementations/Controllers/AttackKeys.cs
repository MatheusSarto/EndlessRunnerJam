using Assets.Scripts.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal class AttackKeys : MonoBehaviour
    {
        private void Update()
        {
            Debug.Log("Attacking with keyboard");
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Atatcking with Key: A");
                GetComponent<IAttack>().Attack(); 
            }
        }
    }
}
