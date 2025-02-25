using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FireCommand : Command
{
    public override void Execute(IActor actor)
    {
        Debug.LogError("Firing Command");
        actor.Fire();
    }
}
