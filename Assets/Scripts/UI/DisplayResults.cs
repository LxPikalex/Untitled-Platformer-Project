using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResults : MonoBehaviour
{
    StatTracker st;
    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        st = Toolbox.getInstance().statTracker;
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text =
            "Results: " + "\n" +
            "Total coins collected: " + st.coinCollected + "/25" + "\n" +
            "Total Deaths: " + st.totalDeathCount;
    }
}
