using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;

    private Enemy _enemy;

    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();  
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void PlayHurtAnimation() 
    {
        animator.SetTrigger("Hurt");
    }
    private void PlayDieAnimation() 
    {
        animator.SetTrigger("Die");
    }

    private float GetCurrentAnimatoinLength()
    {
        float animationlength = animator.GetCurrentAnimatorStateInfo(0).length;
        return animationlength;
    }
    private IEnumerator PlayHurt()
    {
         _enemy.StopMoving();
        PlayHurtAnimation();
        yield return new WaitForSeconds(GetCurrentAnimatoinLength() + 0.3f );
        _enemy.ResumeMoving();
    }

    private IEnumerator PlayDead()
    {
        _enemy.StopMoving();
        PlayDieAnimation();
        yield return new WaitForSeconds(GetCurrentAnimatoinLength() + 0.3f );
        _enemy.ResumeMoving();
        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(_enemy.gameObject);
        
        
    }
    private void EnemyHit(Enemy enemy)
    {
        if (_enemy == enemy)
        {
            StartCoroutine(PlayHurt());
        }
    }

    private void EnemyDead(Enemy enemy)
    {
        if (_enemy == enemy)
        {
            StartCoroutine(PlayDead());
        }
    }
    private void OnEnable()
    {
        EnemyHealth.OnEnemyHit += EnemyHit;
        EnemyHealth.OnEnemyKilled += EnemyDead;
    }
    private void OnDisable()
    {
        EnemyHealth.OnEnemyHit -= EnemyHit;
        EnemyHealth.OnEnemyKilled -= EnemyDead;
    }
}
