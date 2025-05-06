using Assets.Scripts.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    internal class AttackKeys : MonoBehaviour
    {
        [SerializeField] private int maxDashAttacks;
        [SerializeField] private int maxUppercuts;
        [SerializeField] private int maxFallAttacks;
        private int currentDashAttacks = 0;
        private int currentUppercuts = 0;
        private int currentFallAttacks = 0;
        private bool canDashAttack => currentDashAttacks < maxDashAttacks;
        private bool canUppercut=> currentUppercuts < maxUppercuts;
        private bool canFallAttack => currentFallAttacks < maxFallAttacks;

        [SerializeField] private MoveVelocityRgBd moveVelocityRgBd; // Direct reference for checking CanJump

        private void Update()
        {
            Debug.Log("Attacking with keyboard");
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Atatcking with Key: A");
                GetComponent<IAttack>().Attack(); 
            }
            
            if(Input.GetKeyDown(KeyCode.D) && canDashAttack)
            {
                Debug.Log("Atatcking with Key: D");
                GetComponent<IDashAttack>().DashAttackForward();
                currentDashAttacks++;
            }

            if (Input.GetKeyDown(KeyCode.W) && canUppercut)
            {
                Debug.Log("Atatcking with Key: W");
                GetComponent<IDashAttack>().DashAttackUpwards();
                currentUppercuts++;
            }

            if (Input.GetKeyDown(KeyCode.S) && canFallAttack)
            {
                Debug.Log("Atatcking with Key: S");
                GetComponent<IDashAttack>().DashAttackDownwards();
                currentFallAttacks++;
            }

            Debug.Log("Can Jump: " + moveVelocityRgBd.CanJump);
            if (moveVelocityRgBd.CanJump)
            {
                currentDashAttacks = 0;
                currentUppercuts = 0;
                currentFallAttacks = 0;
            }
        }
    }
}
