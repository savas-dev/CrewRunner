using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierLog : ModifierBase
{
    public override void Modify(PlayerController playerController)
    {
        Debug.Log("Modify player");
    }
}
