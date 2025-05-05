using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    float m_maxSpeed = 10;
    [SerializeField, Range(0, 100)]
    float m_maxAcceleration = 10, m_maxAirAcceleration;
    [SerializeField, Range(0, 10)]
    float m_jumpHeight = 2;
    [SerializeField, Range(0, 5)]
    int m_maxAirJumps = 0;
    [SerializeField, Range(0, 90)]
    float m_maxGroundAngle = 25;
    //[SerializeField, Range(0, 1)]
    //float m_bounciness = 0.5f;
    //[SerializeField]
    //Rect m_allowedArea = new Rect(-5, -5, 10, 10);
    [SerializeField]
    Rigidbody m_rigidBody;

    Vector3 m_velocity, m_desiredVelocity;
    bool m_desiredJump;
    bool m_onGround;
    int m_jumpPhase = 0;
    float m_minimumGroundDorProduct;

    private void Awake()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        m_minimumGroundDorProduct = Mathf.Cos(m_maxGroundAngle * Mathf.Deg2Rad);
    }

    private void Update()
    {
        Vector2 l_playerInput;
        l_playerInput.x = Input.GetAxis("Horizontal");
        l_playerInput.y = Input.GetAxis("Vertical");
        l_playerInput = Vector2.ClampMagnitude(l_playerInput, 1f);
        m_desiredVelocity = new Vector3(l_playerInput.x, 0, l_playerInput.y) * m_maxSpeed;
        m_desiredJump |= Input.GetButtonDown("Jump");
        //if(m_velocity.x <= l_desiredVelocity.x)
        //{
        //    m_velocity.x = Mathf.Min(m_velocity.x + l_maxSpeedChange, l_desiredVelocity.x);
        //}
        //else if(m_velocity.x > l_desiredVelocity.x)
        //{
        //    m_velocity.x = Mathf.Max(m_velocity.x - l_maxSpeedChange, l_desiredVelocity.x);
        //}
        //Vector3 l_acceleration = new Vector3(l_playerInput.x, 0, l_playerInput.y) * m_maxSpeed;
        //m_velocity += l_acceleration * Time.deltaTime;
        //Vector3 l_displacement = m_velocity * Time.deltaTime;
        //Vector3 l_newPosition = transform.localPosition + l_displacement;
        //if(!m_allowedArea.Contains(new Vector2(l_newPosition.x, l_newPosition.z)))
        //{
        //    l_newPosition.x = Mathf.Clamp(l_newPosition.x, m_allowedArea.xMin, m_allowedArea.xMax);
        //    l_newPosition.z = Mathf.Clamp(l_newPosition.z, m_allowedArea.yMin, m_allowedArea.yMax);
        //}
        //if(l_newPosition.x < m_allowedArea.xMin)
        //{
        //    l_newPosition.x = m_allowedArea.xMin;
        //    m_velocity.x *= -m_bounciness;
        //}
        //else if(l_newPosition.x > m_allowedArea.xMax)
        //{
        //    l_newPosition.x = m_allowedArea.xMax;
        //    m_velocity.x *= -m_bounciness;
        //}
        //if (l_newPosition.z < m_allowedArea.yMin)
        //{
        //    l_newPosition.z = m_allowedArea.yMin;
        //    m_velocity.z *= -m_bounciness;
        //}
        //else if(l_newPosition.z > m_allowedArea.yMax)
        //{
        //    l_newPosition.z = m_allowedArea.yMax;
        //    m_velocity.z *= -m_bounciness;
        //}

        //transform.localPosition = l_newPosition;
    }

    private void FixedUpdate()
    {
        m_velocity = m_rigidBody.velocity;
        float l_acceleration = m_onGround ? m_maxAcceleration : m_maxAirAcceleration;
        float l_maxSpeedChange = l_acceleration * Time.deltaTime;
        m_velocity.x = Mathf.MoveTowards(m_velocity.x, m_desiredVelocity.x, l_maxSpeedChange);
        m_velocity.z = Mathf.MoveTowards(m_velocity.z, m_desiredVelocity.z, l_maxSpeedChange);
        if(m_desiredJump)
        {
            m_desiredJump = false;
            Jump();
        }
        UpdateVelocity();
        m_onGround = false;
    }
    private void Jump()
    {
        if (m_onGround || m_jumpPhase < m_maxAirJumps)
        {
            m_jumpPhase++;
            float l_jumpSpeed = Mathf.Sqrt(-2 * Physics.gravity.y * m_jumpHeight);
            if(m_velocity.y > 0)
            {
                l_jumpSpeed = Mathf.Max(l_jumpSpeed - m_velocity.y, 0);
            }
            m_velocity.y += l_jumpSpeed;
        }
    }
    private void UpdateVelocity()
    {
        m_rigidBody.velocity = m_velocity;
        if(m_onGround)
        {
            m_jumpPhase = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //m_onGround = true;
        EvaluateCollision(collision);
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    m_onGround = false;
    
    //}
    private void OnCollisionStay(Collision collision)
    {
        //m_onGround = true;
        EvaluateCollision(collision);
    }
    private void EvaluateCollision(Collision a_collision)
    {
        int l_contactCount = a_collision.contactCount;
        for(int i = 0; i < l_contactCount; i++)
        {
            m_onGround |= a_collision.GetContact(i).normal.y >= m_minimumGroundDorProduct;
        }
    }
}
