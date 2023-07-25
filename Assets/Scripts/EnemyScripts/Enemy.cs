using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator animator;
    [SerializeField] private float hitPoints = 100f;
    private float _currentHitPoints;
    public GameObject hitPlayer;

    private void Start()
    {
        _currentHitPoints = hitPoints;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitPlayer = collision.gameObject;
            collision.gameObject.GetComponentInChildren<Renderer>().material.DOColor(Color.gray, .5f);
            collision.gameObject.GetComponent<PlayerShooter>().hasLive = false;
            collision.gameObject.GetComponent<Animator>().Play("Dead1");
            collision.transform.parent = null;
            Invoke(nameof(HidePlayer), 1.5f);

            GameManager.instance.isPlayerDead = true;
            GameManager.instance.InvokeGameOver();

        }

        if (collision.gameObject.CompareTag("Player1"))
        {
            hitPlayer = collision.gameObject;
            collision.gameObject.GetComponentInChildren<Renderer>().material.DOColor(Color.gray, .5f);
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

    public void Damage(float damage)
    {
        _currentHitPoints -= damage;
        if (_currentHitPoints <= 0f)
        {
            animator.SetBool("isDead", true);
            GetComponent<Collider>().enabled = false;
            //GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.gray);
            GetComponentInChildren<Renderer>().material.DOColor(Color.gray, .5f).SetDelay(.8f);
        }
    }

    public void HidePlayer()
    {
        hitPlayer.SetActive(false);
    }
}