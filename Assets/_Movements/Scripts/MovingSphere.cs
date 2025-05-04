using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    float m_maxSpeed = 10;
    [SerializeField, Range(0, 100)]
    float m_maxAcceleration = 10;
    [SerializeField, Range(0, 1)]
    float m_bounciness = 0.5f;
    [SerializeField]
    Rect m_allowedArea = new Rect(-5, -5, 10, 10);

    Vector3 m_velocity;

    private void Update()
    {
        Vector2 l_playerInput;
        l_playerInput.x = Input.GetAxis("Horizontal");
        l_playerInput.y = Input.GetAxis("Vertical");
        l_playerInput = Vector2.ClampMagnitude(l_playerInput, 1f);
        Vector3 l_desiredVelocity = new Vector3(l_playerInput.x, 0, l_playerInput.y) * m_maxSpeed;
        float l_maxSpeedChange = m_maxAcceleration * Time.deltaTime;
        //if(m_velocity.x <= l_desiredVelocity.x)
        //{
        //    m_velocity.x = Mathf.Min(m_velocity.x + l_maxSpeedChange, l_desiredVelocity.x);
        //}
        //else if(m_velocity.x > l_desiredVelocity.x)
        //{
        //    m_velocity.x = Mathf.Max(m_velocity.x - l_maxSpeedChange, l_desiredVelocity.x);
        //}
        m_velocity.x = Mathf.MoveTowards(m_velocity.x, l_desiredVelocity.x, l_maxSpeedChange);
        m_velocity.z = Mathf.MoveTowards(m_velocity.z, l_desiredVelocity.z, l_maxSpeedChange);
        //Vector3 l_acceleration = new Vector3(l_playerInput.x, 0, l_playerInput.y) * m_maxSpeed;
        //m_velocity += l_acceleration * Time.deltaTime;
        Vector3 l_displacement = m_velocity * Time.deltaTime;
        Vector3 l_newPosition = transform.localPosition + l_displacement;
        //if(!m_allowedArea.Contains(new Vector2(l_newPosition.x, l_newPosition.z)))
        //{
        //    l_newPosition.x = Mathf.Clamp(l_newPosition.x, m_allowedArea.xMin, m_allowedArea.xMax);
        //    l_newPosition.z = Mathf.Clamp(l_newPosition.z, m_allowedArea.yMin, m_allowedArea.yMax);
        //}
        if(l_newPosition.x < m_allowedArea.xMin)
        {
            l_newPosition.x = m_allowedArea.xMin;
            m_velocity.x *= -m_bounciness;
        }
        else if(l_newPosition.x > m_allowedArea.xMax)
        {
            l_newPosition.x = m_allowedArea.xMax;
            m_velocity.x *= -m_bounciness;
        }
        if (l_newPosition.z < m_allowedArea.yMin)
        {
            l_newPosition.z = m_allowedArea.yMin;
            m_velocity.z *= -m_bounciness;
        }
        else if(l_newPosition.z > m_allowedArea.yMax)
        {
            l_newPosition.z = m_allowedArea.yMax;
            m_velocity.z *= -m_bounciness;
        }

        transform.localPosition = l_newPosition;
    }
}
