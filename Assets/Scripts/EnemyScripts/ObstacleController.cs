using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    public static ObstacleController instance;

    [SerializeField] private float hitPoints = 100f;
    private float _currentHitPoints;
    public GameObject hitPlayer;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            _currentHitPoints = hitPoints;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.DOMoveZ(collision.transform.position.z - .2f, .5f);

            collision.gameObject.GetComponentInChildren<Renderer>().material.DOColor(Color.gray, .5f);
            hitPlayer = collision.gameObject;
            collision.gameObject.GetComponent<PlayerShooter>().hasLive = false;
            collision.gameObject.GetComponent<Animator>().Play("Dead1");
            collision.transform.parent = null;
            Invoke(nameof(HidePlayer), 1.5f);

            GameManager.instance.isPlayerDead = true;
            GameManager.instance.InvokeGameOver();
        }

        if (collision.gameObject.CompareTag("Player1"))
        {
            collision.transform.DOMoveZ(collision.transform.position.z - .2f, .5f);

            collision.gameObject.GetComponentInChildren<Renderer>().material.DOColor(Color.gray, .5f);
            hitPlayer = collision.gameObject;
            collision.gameObject.GetComponent<PlayerShooter>().hasLive = false;
            collision.gameObject.GetComponent<Animator>().Play("Dead1");
            collision.transform.parent = null;
            Invoke(nameof(HidePlayer), 1.5f);

            if (PlayerCrowd.instance.Shooters.Count > 0)
            {
                PlayerCrowd.instance.Shooters.Remove(PlayerCrowd.instance.Shooters[PlayerCrowd.instance.Shooters.Count - 1]);
            }

            if (PlayerCrowd.instance.Shooters.Count == 0)
            {
                GameManager.instance.isPlayerDead = true;
                GameManager.instance.InvokeGameOver();
            }
        }
    }

    public void HidePlayer()
    {
        hitPlayer.SetActive(false);
    }
}
