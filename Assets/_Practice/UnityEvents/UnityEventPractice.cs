using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventPractice : MonoBehaviour
{
    public UnityEvent m_event;

    private void Awake()
    {
        m_event.Invoke();
    }
}
