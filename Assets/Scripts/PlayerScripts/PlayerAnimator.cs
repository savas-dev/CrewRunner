using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static PlayerAnimator instance;

    public Animator playerAnim;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {

    }

    public void PlayAnim(string animMode)
    {
        playerAnim.Play(animMode);
    }
}
