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
    [SerializeField, Range(1, 360)]
    float m_rotationSpeed = 90f;
    [SerializeField, Range(-89f,89f)]
    float m_minVerticalAngle = -30f, m_maxVerticalAngle = 60f;
    [SerializeField, Min(0f)]
    float m_alignDelay = 5f;

    Vector3 m_focusPoint, m_previousFocusPoint;
    Vector2 m_orbitAngles = new Vector2(45f, 0);
    float m_lastManualRotationChangeTime;

    private void Awake()
    {
        m_focusPoint = m_objectToFocus.position;
        transform.localRotation = Quaternion.Euler(m_orbitAngles);
    }

    private void LateUpdate()
    {
        UpdateFocusPoint();
        Quaternion l_lookRotation;
        if (MannualRotation() || AutomaticRotation())
        {
            ConstraintAngles();
            l_lookRotation = Quaternion.Euler(m_orbitAngles);
        }
        else
        {
            l_lookRotation = transform.localRotation;
        }
        Vector3 l_lookDirection = l_lookRotation * Vector3.forward;
        Vector3 l_lookPosition = m_focusPoint - (l_lookDirection * m_distance);
        transform.SetLocalPositionAndRotation(l_lookPosition, l_lookRotation);
    }

    void UpdateFocusPoint()
    {
        m_previousFocusPoint = m_focusPoint;
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

    bool MannualRotation()
    {
        Vector2 l_input = new Vector2(Input.GetAxis("Vertical Camera"), Input.GetAxis("Horizontal Camera"));
        const float l_e = 0.001f;
        if(l_input.x < -l_e || l_input.x > l_e || l_input.y < -l_e || l_input.y > l_e)
        {
            m_orbitAngles += l_input * m_rotationSpeed * Time.unscaledDeltaTime;
            m_lastManualRotationChangeTime = Time.unscaledTime;
            return true;
        }
        return false;
    }
    bool AutomaticRotation()
    {
        if(Time.unscaledTime - m_lastManualRotationChangeTime < m_alignDelay)
        {
            return false;
        }
        return true;
    }
    void ConstraintAngles()
    {
        m_orbitAngles.x = Mathf.Clamp(m_orbitAngles.x, m_minVerticalAngle, m_maxVerticalAngle);
    }
    private void OnValidate()
    {
        if(m_maxVerticalAngle < m_minVerticalAngle)
        {
            m_maxVerticalAngle = m_minVerticalAngle;
        }

        if (m_orbitAngles.y < 0f)
        {
            m_orbitAngles.y += 360f;
        }
        else if(m_orbitAngles.y >= 360f)
        {
            m_orbitAngles.y -= 360f;
        }
    }
}
