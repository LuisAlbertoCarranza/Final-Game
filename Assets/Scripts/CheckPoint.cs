using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer  theSR;

    public Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            theSR.sprite = cpOn;

            CheckPointController.instance.SetSpawnPoint(transform.position);
        }
    }
}
