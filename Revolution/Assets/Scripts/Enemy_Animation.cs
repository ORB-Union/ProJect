using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Enemy_Animation : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        private Animator enemyAnimator;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableAnimator;
            enemyMaster.EventEnemyWalking += SetAnimationToWalk;
            enemyMaster.EventEnemyReachedNavTarget += SetAnimationToAttack;
            enemyMaster.EventEnemyAttack += SetAnimationToAttack;
            enemyMaster.EventEnemyDeductHealth += SetAnimationToStruct;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableAnimator;
            enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
            enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToAttack;
            enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
            enemyMaster.EventEnemyDeductHealth -= SetAnimationToStruct;
        }

        // Update is called once per frame
        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();

            if (GetComponent<Animator>() != null)
            {
                enemyAnimator = GetComponent<Animator>();
            }
        }

        void SetAnimationToWalk()
        {
            if (enemyAnimator != null)
            {
                if (enemyAnimator.enabled)
                {
                    enemyAnimator.SetBool("Cyborg_Walking", true);
                }
            }
        }

        void SetAnimationToIdle()
        {
            if (enemyAnimator != null)
            {
                if (enemyAnimator.enabled)
                {
                    enemyAnimator.SetBool("Cyborg_Idle", true);
                }
            }
        }


        void SetAnimationToAttack()
        {
            if (enemyAnimator != null)
            {
                if (enemyAnimator.enabled)
                {
                    enemyAnimator.SetBool("Cyborg_Attacking", false);
                }
            }
        }

        void SetAnimationToStruct(int dummy)
        {
            if (enemyAnimator != null)
            {
                if (enemyAnimator.enabled)
                {

                }
            }
        }

        void DisableAnimator()
        {
            if (enemyAnimator != null)
            {
                enemyAnimator.enabled = false;
            }
        }
    }
}
