using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isitEnd;
    public string myLevel;
    LevelManager lm;
    StatTracker statTracker;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        lm = Toolbox.getInstance().levelManager;
        statTracker = Toolbox.getInstance().statTracker;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); //use those 2 lines to get components from other scripts
        lm.nextScene = myLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" &&
           player.hasKey == true)
        {
            if (isitEnd == false)
            {
                statTracker.coinCollected += player.currentCoins;
                statTracker.totalDeathCount += player.deathCount;

                GetComponent<Collider2D>().enabled = false;
                lm.loadNextScene();
            }
            else //resets Stats Tracker if you take the last door to reset
            {
                statTracker.coinCollected = 0;
                statTracker.totalDeathCount = 0;

                GetComponent<Collider2D>().enabled = false;
                lm.loadNextScene();
            }
        }
     } 

}





