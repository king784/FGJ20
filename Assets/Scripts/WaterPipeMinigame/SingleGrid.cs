using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pipe {Straight, Curve, Cross}

public class SingleGrid : MonoBehaviour
{
    // Left, Up, Right, Down
    public bool[] sides = new bool[4];
    public void SetLogic(int p)
    {
        if(p == (int)Pipe.Straight)
        {
            sides[0] = true;
            sides[1] = false;
            sides[2] = true;
            sides[3] = false;
        }
        else if(p == (int)Pipe.Curve)
        {
            sides[0] = true;
            sides[1] = true;
            sides[2] = false;
            sides[3] = false;
        }
        else if(p == (int)Pipe.Cross)
        {
            sides[0] = true;
            sides[1] = true;
            sides[2] = true;
            sides[3] = true;
        }
    }

    public void RotatePipe()
    {
        GetComponent<RectTransform>().eulerAngles = new Vector3(0.0f, 0.0f, 
        GetComponent<RectTransform>().eulerAngles.z + 90.0f);

        bool start = sides[0];
        for(int i = 0; i < 3; i++)
        {
            sides[i] = sides[i + 1];
        }
        sides[3] = start;
    }
}
