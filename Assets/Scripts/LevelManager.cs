using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;
    public string levelToLoad;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
    public void RespawnPlayer()
        {
            StartCoroutine(RespawnCo());
        }

        IEnumerator RespawnCo()
        {
            PlayerController.instance.gameObject.SetActive(false);

            yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));

            UIController.instance.FadeToBlack();

            yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) +.2f);

            UIController.instance.FadeFromBlack();

            PlayerController.instance.gameObject.SetActive(true);

            PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;

            PlayerHealth.instance.currentHealth = PlayerHealth.instance.maxHealth;

            UIController.instance.UpdateHealthDisplay();
             

        }
        

        public void Endlevel()
        {
          StartCoroutine(EndlevelCo());
        }

        public IEnumerator EndlevelCo()
        {

            PlayerController.instance.stopInput = true;
            UIController.instance.levelCompleteText.SetActive(true);

            yield return new WaitForSeconds(0.5f);

           UIController.instance.FadeToBlack();

            yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed)+.25f); 

            SceneManager.LoadScene(levelToLoad);
        }
    
}
