using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : PoolObject
{
    /// <summary>
    /// 이동 속도
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// 체력
    /// </summary>
    private int health;

    public int Health
    {
        get => health;
        protected set
        {
            if (health != value)
            {
                health = value;
                if (health <= 0)
                {
                    Die();
                }
            }
        }
    }

    /// <summary>
    /// 최대 체력
    /// </summary>
    public int maxHealth;

    /// <summary>
    /// 죽으면 얻게 될 점수
    /// </summary>
    public int score;

    /// <summary>
    /// health가 0이하로 내려가면 실행할 델리게이트 (파라메터 : 점수)
    /// </summary>
    public System.Action<int> onDie;

    protected virtual void OnEnable()
    {
        Health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health--;
        }
    }

    /// <summary>
    /// 죽었을 때 실행할 함수
    /// </summary>
    protected virtual void Die()
    {
        // 터지는 이펙트 생성

        onDie?.Invoke(score);

        gameObject.SetActive(false);
    }
}