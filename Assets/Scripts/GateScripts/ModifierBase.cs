using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierBase : MonoBehaviour
{
    public abstract void Modify(PlayerController playerController);
}