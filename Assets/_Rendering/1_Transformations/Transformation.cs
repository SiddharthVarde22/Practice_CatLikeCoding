using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformation : MonoBehaviour
{
    public abstract void ApplyTransformation(float a_x, float a_y, float a_z);
}
