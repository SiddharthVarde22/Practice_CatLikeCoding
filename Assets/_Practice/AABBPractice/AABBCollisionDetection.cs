using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBCollisionDetection : MonoBehaviour
{
    [SerializeField] Vector3 m_size;
    [SerializeField] AABBCollisionDetection m_otherObject;
    [SerializeField]
    bool m_shouldUpdate = false;

    Transform m_selfTransform;
    public Vector3 Size { get { return m_size; } }
    public Transform SelfTransform { get { return m_selfTransform; } }

    private void Start()
    {
        m_selfTransform = transform;
    }

    private void Update()
    {
        if (m_shouldUpdate)
        {
            DetectCollision();
            DetectCollisionThroughDistance();
        }
    }

    float l_selfRight, l_selfLeft, l_selfUp, l_selfDown, l_otherRight, l_otherLeft, l_otherUp, l_otherDown;
    private void DetectCollision()
    {
        l_selfRight = (m_selfTransform.position.x + (m_size.x / 2)); l_selfLeft = (m_selfTransform.position.x - (m_size.x / 2));
        l_selfUp = m_selfTransform.position.y + (m_size.y / 2); l_selfDown = m_selfTransform.position.y - (m_size.y / 2);

        l_otherRight = m_otherObject.SelfTransform.position.x + (m_otherObject.Size.x / 2);
        l_otherLeft = m_otherObject.SelfTransform.position.x - (m_otherObject.Size.x / 2);
        l_otherUp = m_otherObject.SelfTransform.position.y + (m_otherObject.Size.y / 2);
        l_otherDown = m_otherObject.SelfTransform.position.y - (m_otherObject.Size.y / 2);


        if(
            ((l_selfRight <= l_otherRight && l_selfRight >= l_otherLeft) || (l_selfLeft <= l_otherRight && l_selfLeft >= l_otherLeft))
            && ((l_selfUp <= l_otherUp && l_selfUp >= l_otherDown) || (l_selfDown >= l_otherDown && l_selfDown <= l_otherUp))
            )
        {
            Debug.Log("Collision Detected");
        }
    }

    private void DetectCollisionThroughDistance()
    {
        float l_xDistance = (m_size.x / 2) + (m_otherObject.m_size.x / 2), l_yDistance = (m_size.y / 2) + (m_otherObject.Size.y / 2);

        Vector3 l_direction = m_otherObject.m_selfTransform.position - m_selfTransform.position;

        if(Mathf.Abs(l_direction.x) <= l_xDistance && Mathf.Abs(l_direction.y) <= l_yDistance)
        {
            Debug.Log("Detecting Collision through distance");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, m_size);
    }
}
