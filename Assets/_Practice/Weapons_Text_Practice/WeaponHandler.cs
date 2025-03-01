using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour, IWeaponHandler
{
    IAttacker m_attackerWeapon;
    IRealoader m_realoderWeapon;
    IShooter m_shooterWeapon;
    public void RegisterForAttack(IAttacker a_attakerWeapon)
    {
        m_attackerWeapon = a_attakerWeapon;
        Wapons_Input.RegisterForAttack(Attack);
    }

    public void RegisterForReload(IRealoader a_realoaderWeapon)
    {
        m_realoderWeapon = a_realoaderWeapon;
        Wapons_Input.RegisterForReload(Reload);
    }

    public void RegisterForShoot(IShooter a_shooter)
    {
        m_shooterWeapon = a_shooter;
        Wapons_Input.RegisterForShoot(Shoot);
    }

    public void UnregisterFromAttack(IAttacker a_attacker)
    {
        m_attackerWeapon = null;
        Wapons_Input.UnregisterFromAttack(Attack);
    }

    public void UnregisterFromReload(IRealoader a_realoader)
    {
        m_realoderWeapon = null;
        Wapons_Input.UnregisterFromReload(Reload);
    }

    public void UnregisterFromShoot(IShooter a_shooter)
    {
        m_shooterWeapon = null;
        Wapons_Input.UnregisterFromShoot(Shoot);
    }

    private void Attack()
    {
        m_attackerWeapon.Attack();
    }
    private void Reload()
    {
        m_realoderWeapon.Reload();
    }
    private void Shoot()
    {
        m_shooterWeapon.Shoot();
    }
}
