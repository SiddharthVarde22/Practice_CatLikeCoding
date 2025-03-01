using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wapons_Input : MonoBehaviour
{
    private static Wapons_Input s_instance;

    Action m_attack, m_shoot, m_reload;

    private void Awake()
    {
        s_instance = this;
    }
    private void OnDestroy()
    {
        s_instance = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_attack?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            m_reload?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            m_shoot?.Invoke();
        }
    }
    public static void RegisterForAttack(Action a_attackFuntion)
    {
        s_instance.m_attack += a_attackFuntion;
    }
    public static void UnregisterFromAttack(Action a_attackFuntion)
    {
        s_instance.m_attack -= a_attackFuntion;
    }
    public static void RegisterForReload(Action a_attackFuntion)
    {
        s_instance.m_reload += a_attackFuntion;
    }
    public static void UnregisterFromReload(Action a_attackFuntion)
    {
        s_instance.m_reload -= a_attackFuntion;
    }
    public static void RegisterForShoot(Action a_attackFuntion)
    {
        s_instance.m_shoot += a_attackFuntion;
    }
    public static void UnregisterFromShoot(Action a_attackFuntion)
    {
        s_instance.m_shoot -= a_attackFuntion;
    }
}
