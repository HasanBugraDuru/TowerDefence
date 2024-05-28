using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private float DelayBtwAccakts=2f;
    [SerializeField] protected float damage =2f;

    public  float Damage { get; set; }
    public float DelayPerShoot { get; set; }

    private float nextAttackTime;
    private ObjectPooler _pooler;
    public Turret turret;

    private Projectile _currentProjectileLoaded;
    private void Start()
    {
        Damage = damage;
        DelayPerShoot = DelayBtwAccakts;
        turret = GetComponent<Turret>();    
        _pooler = GetComponent<ObjectPooler>();
        LoadProjectile();
    }
    private void Update()
    {
        if(IsTurretEmpty()) 
        {
            LoadProjectile();
        }
        if(Time.time > nextAttackTime)
        {
            if (turret.CurrentTargetEnemy != null && _currentProjectileLoaded != null
        && turret.CurrentTargetEnemy.EnemyHealth.CurrentHealth >= 0f)
            {
                _currentProjectileLoaded.transform.parent = null;
                _currentProjectileLoaded.SetEnemy(turret.CurrentTargetEnemy);
            }
            nextAttackTime = Time.time + DelayPerShoot;
        }
       
    }
    private void LoadProjectile()
    {
        GameObject newIntance = _pooler.GerInstanceFromPool();
        newIntance.transform.localPosition = projectileSpawnPosition.position;
        newIntance.transform.SetParent(projectileSpawnPosition);
        _currentProjectileLoaded = newIntance.GetComponent<Projectile>();
        _currentProjectileLoaded.TurretOwner = this;
        _currentProjectileLoaded.ResetProjectile();
        _currentProjectileLoaded.Damage = Damage;
        newIntance.SetActive(true);
    }
    private bool IsTurretEmpty()
    {
        return _currentProjectileLoaded == null;
    }
    public void ResetTurretProjectile()
    {
        _currentProjectileLoaded = null;
    }
}
