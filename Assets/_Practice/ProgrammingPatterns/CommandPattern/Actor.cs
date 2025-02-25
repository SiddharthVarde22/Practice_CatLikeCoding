using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IActor
{
    public void Fire()
    {
        Debug.Log("Actor Firing");
    }

    public void Jump()
    {
        Debug.Log("Actor jumping");
    }
}
