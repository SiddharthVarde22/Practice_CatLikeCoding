using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : Weapon, IAttacker, IShooter, IRealoader
{
    public override void Initialize(IWeaponHandler a_weaponHandler)
    {
        a_weaponHandler.RegisterForAttack(this);
        a_weaponHandler.RegisterForReload(this);
        a_weaponHandler.RegisterForShoot(this);
    }
    public override void Deinitialize(IWeaponHandler a_weaponHandler)
    {
        a_weaponHandler.UnregisterFromAttack(this);
        a_weaponHandler.UnregisterFromReload(this);
        a_weaponHandler.UnregisterFromShoot(this);
    }
    public virtual void Attack()
    {
        Debug.Log("Attacking with Shooting weapon");
    }
    public virtual void Shoot()
    {
        Debug.Log("Shooting from Shooting Weapon");
    }
    public virtual void Reload()
    {
        Debug.Log("Realoading the shooting weapon");
    }
}
