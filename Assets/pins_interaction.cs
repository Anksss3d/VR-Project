using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pins_interaction : MonoBehaviour
{
    GameObject pin1, pin2, pin3, pin4;
    TextMesh textbox;
    private int score;
    private bool bowling_flag;
    public AudioClip wallSound;
    public AudioClip pinSound;
    bool sflag_pin1, sflag_pin2, sflag_pin3, sflag_pin4;
    // Start is called before the first frame update
    void Start()
    {
        pin1 = GameObject.Find("pin1");
        pin2 = GameObject.Find("pin2");
        pin3 = GameObject.Find("pin3");
        pin4 = GameObject.Find("pin4");
        textbox = GameObject.Find("pin_score").GetComponent<TextMesh>();
        bowling_flag = true;

        sflag_pin1 = true;
        sflag_pin2 = true;
        sflag_pin3 = true;
        sflag_pin4 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (bowling_flag)
        {
            updateScore();
        }
        
    }


    bool isDown(GameObject pin)
    {
        float orx = pin.transform.rotation.eulerAngles.x;
        float ory = pin.transform.rotation.eulerAngles.y;
        float orz = pin.transform.rotation.eulerAngles.z;
        textbox.text = "p:" + Math.Round(orx, 2) + ", " + Math.Round(ory, 2) + ", " + Math.Round(orz, 2);

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
            if (sflag_pin1)
            {
                AudioSource.PlayClipAtPoint(pinSound, gameObject.transform.position, 1);
                sflag_pin1 = false;
            }
            score += 1;
        }
        
        if (isDown(pin2))
        {
            if (sflag_pin2)
            {
                AudioSource.PlayClipAtPoint(pinSound, gameObject.transform.position, 1);
                sflag_pin2 = false;
            }
            score += 1;
        }
        if (isDown(pin3))
        {
            if (sflag_pin3)
            {
                AudioSource.PlayClipAtPoint(pinSound, gameObject.transform.position, 1);
                sflag_pin3 = false;
            }
            score += 1;
        }
        if (isDown(pin4))
        {
            if (sflag_pin4)
            {
                AudioSource.PlayClipAtPoint(pinSound, gameObject.transform.position, 1);
                sflag_pin4 = false;
            }
            score += 1;
        }
        
        textbox.text = "Pins Score: " + score + "/4";
        
        if (score == 4)
        {
            bowling_flag = false;
            removeObjects();
        }

    }

    void removeObjects()
    {
        
        //Destroy(wall, 5.0f);
        for (int i = 1; i < 21; i++)
        {
            GameObject ball = GameObject.Find("Ball"+i);
            //ball.transform.position = Vector3.Lerp(ball.transform.position, new Vector3(ball.transform.position.x, ball.transform.position.y+2.0f, ball.transform.position.z), Time.deltaTime);
            Destroy(ball, 2.0f);
        }


        AudioSource.PlayClipAtPoint(wallSound, transform.position, 1);

        GameObject wall = GameObject.Find("glass_door");
        Destroy(wall, 2.0f);
        //wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x, wall.transform.position.y + 2.0f, wall.transform.position.z), Time.deltaTime);
    }
}
