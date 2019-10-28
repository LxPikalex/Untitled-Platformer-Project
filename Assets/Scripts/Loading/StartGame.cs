using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    LevelManager lm;
    // Start is called before the first frame update
    void Start()
    {
        lm = Toolbox.getInstance().levelManager;
        lm.nextScene = "Level1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            lm.loadNextScene();
        }
    }
}
