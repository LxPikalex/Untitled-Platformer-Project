using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{

    public int coinCollected;
    public int totalDeathCount;


    LevelManager lm;

    private void Start()
    {
        lm = Toolbox.getInstance().levelManager;
    }

    private void Update()
    {

    }


}
