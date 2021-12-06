using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pins_interaction : MonoBehaviour
{
    GameObject pin1, pin2, pin3, pin4;
    TextMesh textbox;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        pin1 = GameObject.Find("pin1");
        pin2 = GameObject.Find("pin2");
        pin3 = GameObject.Find("pin3");
        pin4 = GameObject.Find("pin4");
        textbox = GameObject.Find("pin_score").GetComponent<TextMesh>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }


    bool isDown(GameObject pin)
    {
        float orx = pin.transform.rotation.x;
        float ory = pin.transform.rotation.y;
        float orz = pin.transform.rotation.z;
        textbox.text = "p:" + Math.Round(orx, 2) + ", " + Math.Round(ory, 2) + ", " + Math.Round(orz
            , 2);

        if (Math.Abs(orx) > 45 || Math.Abs(ory) > 45 || Math.Abs(orz) > 45)
        {
            return true;
        }
        return false;
    }


    void updateScore()
    {
        score = 0;
        if (isDown(pin1)){
            score += 1;
        }
        /*
        if (isDown(pin2))
        {
            score += 1;
        }
        if (isDown(pin3))
        {
            score += 1;
        }
        if (isDown(pin4))
        {
            score += 1;
        }
        
        textbox.text = "Pins Score: " + score + "/4";
        */
    }
}
