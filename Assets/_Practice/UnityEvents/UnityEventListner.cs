using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventListner : MonoBehaviour
{
    [SerializeField] UnityEventPractice m_subject;

    private void Start()
    {
        m_subject.m_event.AddListener(EventCallback);
    }

    private void EventCallback()
    {
        Debug.Log("Event Called back");
    }
}
