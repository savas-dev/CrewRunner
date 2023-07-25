using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Modifier"))
        {
            var modifier = other.GetComponent<ModifierBase>();
            if (modifier)
            {
                modifier.Modify(this);
                Destroy(other.gameObject, .5f);
            }
        }

        if (other.CompareTag("FinalTrigger"))
        {
            GameManager.instance.isGameEnd = true;
            PlayerAnimator.instance.PlayAnim("Dance1");
            GameManager.instance.InvokeWin(7);
            

            
            int finalPointIndex = 0;
            for (int i = 0; i < PlayerCrowd.instance._shooters.Count; i++)
            {
                PlayerCrowd.instance._shooters[i].GetComponent<Rigidbody>().isKinematic = true;

                PlayerCrowd.instance._shooters[i].transform.DOMove(PlayerCrowd.instance.finalPoints[finalPointIndex].transform.position, finalPointIndex / 3.4f);
                PlayerCrowd.instance._shooters[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerCrowd.instance._shooters[i].GetComponent<PlayerAnimator>().PlayAnim("Dance2");

                if(finalPointIndex <= PlayerCrowd.instance._shooters.Count)
                {
                    finalPointIndex++;
                }
            }

            int count = PlayerCrowd.instance._shooters.Count;

            if (PlayerCrowd.instance._shooters.Count == count)
            {
                
                GameObject.Find("Final Point " + "("+count+")").transform.GetChild(1).GetComponent<Light>().DOIntensity(25, .5f).
                    OnComplete(() => GameObject.Find("Final Point " + "(" + count + ")").transform.GetChild(1).GetComponent<Light>().DOIntensity(0, 1f)).SetLoops(-1);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FinalTrigger"))
        {
            CameraController.instance.FinalCam();
        }

        
    }
}