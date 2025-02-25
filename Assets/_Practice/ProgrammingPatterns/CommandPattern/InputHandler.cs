using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class InputHandler : MonoBehaviour
{
    [SerializeField] Command m_jumpCommand;
    [SerializeField] Command m_fireCommand;

    [SerializeField] Actor m_actor;

    private void Update()
    {
        HandleInput();
    }
    public void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_jumpCommand.Execute(m_actor);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            m_fireCommand.Execute(m_actor);
        }
    }
}
