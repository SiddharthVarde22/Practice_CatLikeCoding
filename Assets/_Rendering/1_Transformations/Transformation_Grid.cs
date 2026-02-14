using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation_Grid : MonoBehaviour
{
    [SerializeField] Transform m_pointMesh;
    [SerializeField] int m_gridResolution = 10;

    Transform[] m_grid;
    private void Start()
    {
        m_grid = new Transform[m_gridResolution * m_gridResolution * m_gridResolution];

        for(int i = 0, z = 0; z < m_gridResolution; z++)
        {
            for(int y = 0; y < m_gridResolution; y++)
            {
                for(int x = 0; x < m_gridResolution; x++, i++)
                {
                    m_grid[i] = GeneratePoint(x, y, z);
                }
            }
        }
    }

    private Transform GeneratePoint(int x, int y, int z)
    {
        Transform l_point = Instantiate(m_pointMesh);
        l_point.localPosition = GetGridPointCordinates(x, y, z);

        l_point.GetComponent<MeshRenderer>().material.color = new Color(
            (float)x / m_gridResolution,
            (float)y / m_gridResolution,
            (float)z / m_gridResolution);

        return l_point;
    }

    private Vector3 GetGridPointCordinates(int x, int y, int z)
    {
        float l_offset = (m_gridResolution - 1) * 0.5f;
        return new Vector3(
            x - l_offset,
            y - l_offset,
            z - l_offset);
    }
}
