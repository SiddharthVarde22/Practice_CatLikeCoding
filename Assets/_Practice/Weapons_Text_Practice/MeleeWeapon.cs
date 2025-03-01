using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon, IAttacker
{
    public override void Initialize(IWeaponHandler a_weaponHandler)
    {
        a_weaponHandler.RegisterForAttack(this);
    }
    public override void Deinitialize(IWeaponHandler a_weaponHandler)
    {
        a_weaponHandler.UnregisterFromAttack(this);
    }
    public virtual void Attack()
    {
        Debug.Log("Performing an Melee attack");
    }
}
