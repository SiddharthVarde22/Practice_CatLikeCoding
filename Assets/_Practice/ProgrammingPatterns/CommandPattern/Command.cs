using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    public Command()
    {
        Debug.LogError("Creating Command Object");
    }
    ~Command()
    {
        Debug.LogError("Destroying Command Object");
    }
    public abstract void Execute(IActor actor);
}
