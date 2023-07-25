using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public GameObject playerHolder;
    public float followSpeed = 2f;
    public Vector3 offset;
    public Vector3 finaloffSet;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void LateUpdate()
    {
        if (GameManager.instance.isGameStart && !GameManager.instance.isPlayerDead && !GameManager.instance.isGameEnd)
        {
            transform.position = Vector3.Lerp(transform.position, playerHolder.transform.position
                + offset, followSpeed * Time.deltaTime);
        }

        //if (GameManager.instance.isGameEnd)
        //{
        //    FinalCam();
        //}

    }

    public void FinalCam()
    {
        GameObject lastPerson = PlayerCrowd.instance._shooters[PlayerCrowd.instance._shooters.Count - 1].gameObject;
        transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(
                    0,
                    5.2f,
                    lastPerson.transform.position.z - 4f
                    ),
                1.2f * Time.deltaTime
            );


        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.x, transform.rotation.x + 75, followSpeed * Time.deltaTime),
            Mathf.LerpAngle(transform.rotation.y, 0, followSpeed *  Time.deltaTime),
            Mathf.LerpAngle(transform.rotation.z, 0, followSpeed *  Time.deltaTime));

        transform.eulerAngles = currentAngle;
    }
}
