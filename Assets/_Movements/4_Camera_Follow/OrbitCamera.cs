using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    Transform m_objectToFocus;
    [SerializeField, Range(1, 20)]
    float m_distance = 5;
    [SerializeField, Min(0)]
    float m_focusRadius = 1;
    [SerializeField, Range(0, 1)]
    float m_focusCentering = 0.5f;

    Vector3 m_focusPoint;

    private void Awake()
    {
        m_focusPoint = m_objectToFocus.position;
    }

    private void LateUpdate()
    {
        UpdateFocusPoint();
        Vector3 l_lookDirection = transform.forward;
        transform.position = m_focusPoint - (l_lookDirection * m_distance);
    }

    void UpdateFocusPoint()
    {
        Vector3 l_target = m_objectToFocus.position;
        if(m_focusRadius > 0)
        {
            float l_distance = Vector3.Distance(l_target, m_focusPoint);
            float l_t = 1f;
            if (l_distance > 0.01f && m_focusCentering > 0f)
            {
                l_t = Mathf.Pow(1f - m_focusCentering, Time.unscaledDeltaTime);
            }

            if(l_distance > m_focusRadius)
            {
                l_t = Mathf.Min(l_t, m_focusRadius / l_distance);
            }
            m_focusPoint = Vector3.Lerp(l_target, m_focusPoint, l_t);
        }
        else
        {
            m_focusPoint = l_target;
        }
    }
}
