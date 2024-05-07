using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static Action<Enemy> OnEnemyKilled;
    public static Action<Enemy> OnEnemyHit;

    [SerializeField] private GameObject HealthBarPrefab;
    [SerializeField] private Transform barPosition;

    [SerializeField] private float initialHealth =10f;
    [SerializeField] private float maxHealth = 10f;

    public float CurrentHealth { get; set; }

    private Image _healthBar;
    private Enemy enemy;

    private void Start()
    {
        CreateHealthBar();
        enemy = GetComponent<Enemy>();
        CurrentHealth = initialHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
        }
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, 
            CurrentHealth / maxHealth, Time.deltaTime * 10f);
    }
    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(HealthBarPrefab,barPosition.position,Quaternion.identity);
        newBar.transform.SetParent(transform);

        EnemyHealthConteiner conteiner = newBar.GetComponent<EnemyHealthConteiner>();
        _healthBar = conteiner.FillAmountImage;
    }

    public void DealDamage(float DamageRevieved)
    {
        CurrentHealth -= DamageRevieved;
        if(CurrentHealth <= 0 ) 
        {
            CurrentHealth = 0;
            Die();
        }
        else
        {
            OnEnemyHit?.Invoke(enemy);
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = initialHealth;
        _healthBar.fillAmount = 1f;
    }
    private void Die()
    {
        OnEnemyKilled?.Invoke(enemy);
    }
}
