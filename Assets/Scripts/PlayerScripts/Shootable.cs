using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shootable : MonoBehaviour
{
    [SerializeField] private float shootableSurviveTime = .5f;
    private float _damagePerHit = 10;

    public void Init(float damagePerHit)
    {
        _damagePerHit = damagePerHit;
        Invoke(nameof(DestroyShootable), .6f);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Damageable"))
        {
            var damageable = collision.transform.GetComponentInChildren<IDamageable>();

            collision.GetComponentInChildren<Renderer>().material.DOColor(Color.gray, .5f).
                OnComplete(() => collision.GetComponentInChildren<Renderer>().material.DOColor(Color.red, .5f));

            

            damageable.Damage(_damagePerHit);
            DestroyShootable();
        }

        if (collision.transform.CompareTag("FinalTrigger"))
        {
            Destroy(this.gameObject);
        }
    }

    // original codes is here
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Damageable"))
    //    {
    //        var damageable = collision.transform.GetComponentInChildren<IDamageable>();
    //        damageable.Damage(_damagePerHit);
    //        DestroyShootable();
    //    }
    //}

    private void DestroyShootable()
    {
        Destroy(gameObject);
    }
}