using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsInventory : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    [SerializeField] WeaponHandler m_weaponHandler;
    Weapon m_currentWeapon = null;
    int m_currentWeaponIndex = -1;

    private void Update()
    {
        if (weapons.Count == 0) return;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectNextWeapon();
        }
    }

    void SelectNextWeapon()
    {
        if (m_currentWeaponIndex != -1)
        {
            m_currentWeapon.Deinitialize(m_weaponHandler);
        }

        m_currentWeaponIndex++;
        if(m_currentWeaponIndex >= weapons.Count)
        {
            m_currentWeaponIndex = 0;
        }

        m_currentWeapon = weapons[m_currentWeaponIndex];
        m_currentWeapon.Initialize(m_weaponHandler);
    }
}
