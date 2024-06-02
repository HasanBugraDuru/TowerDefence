using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade : MonoBehaviour
{
    [SerializeField] private int upgradeinitailCost;
    [SerializeField] private int upgradecostIncremental;
    [SerializeField] private float damageIncremental; 
    [SerializeField] private float delayReduce;

    public int UpgradeCost { get; set; }

    private TurretProjectile _turretProjectile;

    private void Start()
    {
        UpgradeCost = upgradeinitailCost;
        _turretProjectile = GetComponent<TurretProjectile>();
    }

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.H)) 
        {
            UpgradeTurret();
        }
    }
    private void UpgradeTurret()
    {
       
        _turretProjectile.Damage += damageIncremental;
        _turretProjectile.DelayPerShoot -= delayReduce;
    }
}
