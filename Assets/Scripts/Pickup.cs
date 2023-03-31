using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{ //Here we define the objects or pickups that we are going to use
    public bool isGem, isHeal;
    private bool isCollected;

  private void OnTriggerEnter2D(Collider2D other)
  { //In this part of the code we put a function to increase the gems when we take one or in the case of the heal a heart
    if(other.CompareTag("Player")&& !isCollected)
    {
        if(isGem)
        {
            LevelManager.instance.gemsCollected ++;
            UIController.instance.UpdateGemCount();
            isCollected = true;
            Destroy(gameObject);
        }
        if(isHeal)
        {
            if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
            {
                PlayerHealth.instance.HealthPlayer();
                
                isCollected = true;
                Destroy(gameObject);
            }
        }
    }
  }

}
