using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHandler
{
    void RegisterForAttack(IAttacker a_attakerWeapon);
    void RegisterForReload(IRealoader a_realoaderWeapon);
    void RegisterForShoot(IShooter a_shooter);
    void UnregisterFromAttack(IAttacker a_attacker);
    void UnregisterFromReload(IRealoader a_realoader);
    void UnregisterFromShoot(IShooter a_shooter);
}
public interface IWeapon
{
    void Initialize(IWeaponHandler a_weaponHandler);
    void Deinitialize(IWeaponHandler a_weaponHandler);
}
public interface IAttacker
{
    void Attack();
}
public interface IRealoader
{
    void Reload();
}
public interface IShooter
{
    void Shoot();
}
