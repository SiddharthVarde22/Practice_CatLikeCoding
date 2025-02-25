using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JumpCommand : Command
{
    public override void Execute(IActor actor)
    {
        Debug.LogError("Jumping Command");
        actor.Jump();
    }
}
