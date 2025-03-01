using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public abstract void Initialize(IWeaponHandler a_weaponHandler);
    public abstract void Deinitialize(IWeaponHandler a_weaponHandler);
}
