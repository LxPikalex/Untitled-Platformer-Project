using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public StatTracker statTracker;
    public LevelManager levelManager;

    private static Toolbox inst = null;
    public static Toolbox getInstance()
    {
        if (inst == null)
        {
            GameObject nO = new GameObject("Toolbox");
            inst = nO.AddComponent<Toolbox>();
        }

        return inst;
    }

    private void Awake()
    {
        if (inst != null)
        {
            Destroy(this);
            return;
        }
        statTracker = gameObject.AddComponent<StatTracker>();
        levelManager = gameObject.AddComponent<LevelManager>();
        DontDestroyOnLoad(gameObject);
    }

}
