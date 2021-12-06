using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class objects_interaction : MonoBehaviour
{
    TextMesh textbox;
    GameObject grid_red, grid_blue, grid_green, cube_red, cube_blue, cube_green, door;
    bool flag_red, flag_green, flag_blue;
    Vector3 ini_red, ini_blue, ini_green;


    // Start is called before the first frame update
    void Start()
    {
        
        //textbox = GameObject.Find("score_text");
        cube_blue = GameObject.Find("cube_blue");
        cube_green = GameObject.Find("cube_green");
        cube_red = GameObject.Find("cube_red");

        grid_blue = GameObject.Find("grid_blue");
        grid_green = GameObject.Find("grid_green");
        grid_red = GameObject.Find("grid_red");

        door = GameObject.Find("glass_panel_1");

        textbox = GameObject.Find("score_text").GetComponent<TextMesh>();

        flag_red = false;
        flag_blue = false;
        flag_green = false;

        ini_red = cube_red.transform.position;
        ini_blue = cube_blue.transform.position;
        ini_green = cube_green.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag_blue)
        {
            if (checkPosition(grid_blue, cube_blue))
            {
                flag_blue = true;
                Destroy(cube_blue, 0.5f);
                Destroy(grid_blue, 0.5f);
                //cube_blue.Destroy();
                //translateGrid(grid_blue);
            }
        }
        if (!flag_green)
        {
            if (checkPosition(grid_green, cube_green))
            {
                flag_green = true;
                Destroy(cube_green, 0.5f);
                Destroy(grid_green, 0.5f);
            }
        }
        if (!flag_red)
        {
            if (checkPosition(grid_red, cube_red))
            {
                flag_red = true;
                Destroy(cube_red, 0.5f);
                Destroy(grid_red, 0.5f);
            }
        }

        checkCubePosition();
        //textbox.text = "p:" + Math.Round(cube_red.transform.position.y, 2);

        updateScore();

    }

    void checkCubePosition()
    {
        if (!flag_red && cube_red.transform.position.y < 0.4)
        {
            cube_red.transform.position = ini_red;
        }
        if (!flag_green && cube_green.transform.position.y < 0.4)
        {
            cube_green.transform.position = ini_green;
        }
        if (!flag_blue && cube_blue.transform.position.y < 0.4)
        {
            cube_blue.transform.position = ini_blue;
        }


    }

    void updateScore()
    {
        int score = 0;
        if (flag_red)
        {
            score += 1;   
        }
        if (flag_blue)
        {
            score += 1;
        }
        if (flag_green)
        {
            score += 1;
        }
        textbox.text = "Score : " + score + "/3";
        if (score == 3)
        {
            float door_new_y = door.transform.position.y+2.0f;
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, door_new_y, door.transform.position.z), 1.0f * Time.deltaTime);
        }
    }

    bool checkPosition(GameObject grid, GameObject cube)
    {
        if (grid.GetComponent<BoxCollider>().bounds.Intersects(cube.GetComponent<BoxCollider>().bounds))
            return true;
        /*
        double minx = grid.transform.position.x - 0.5;
        double maxx = grid.transform.position.x + 0.5;
        double minz = grid.transform.position.z - 0.5;
        double maxz = grid.transform.position.z + 0.5;

        double gridy = grid.transform.position.z;


        double obx = cube.transform.position.x;
        double obz = cube.transform.position.z;

        double oby = cube.transform.position.y;


        if (minx < obx && maxx > obx && minz < obz && maxz > obz)
        {
            if (oby > gridy && gridy-oby < 1.0)
            {
                return true;
            }
        }
        textbox.text = "p:" + Math.Round(minx, 2)  + ", " + Math.Round(obx, 2)  + ", " + Math.Round(maxx
            , 2) ;
        */
        return false;

    }

}
