using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public static MoveForward instance;

    [SerializeField] private float moveSpeed = 10f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (GameManager.instance.isGameStart && !GameManager.instance.isPlayerDead && !GameManager.instance.isGameEnd)
        {
            transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
        }
    }
}