using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Pipe {Straight, Curve, Cross}
public enum GridActivity{Empty, HasPipe}

public class SingleGrid : MonoBehaviour
{
    // Left, Up, Right, Down
    public int[] sides = new int[4];
    public Pipe currentPipe;
    public GridActivity activity;
    public int numOfRotations;
    public int x;
    public int y;

    void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => ClickEvent());
    }

    void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

     public void SetLogic(int p)
    {
        if(p == (int)Pipe.Straight)
        {
            sides[0] = 1;
            sides[1] = 0;
            sides[2] = 2;
            sides[3] = 0;
        }
        else if(p == (int)Pipe.Curve)
        {
            sides[0] = 1;
            sides[1] = 2;
            sides[2] = 0;
            sides[3] = 0;
        }
        else if(p == (int)Pipe.Cross)
        {
            sides[0] = 1;
            sides[1] = 2;
            sides[2] = 2;
            sides[3] = 1;
        }
        currentPipe = (Pipe)p;
        activity = GridActivity.HasPipe;
    }

    public void SetPos(int newX, int newY)
    {
        x = newX;
        y = newY;
    }

    public void RotatePipe()
    {
        GetComponent<RectTransform>().eulerAngles = new Vector3(0.0f, 0.0f, 
        GetComponent<RectTransform>().eulerAngles.z + 90.0f);

        int start = sides[0];
        for(int i = 0; i < 3; i++)
        {
            sides[i] = sides[i + 1];
        }
        sides[3] = start;
    }

    void ClickEvent()
    {
        if(activity == GridActivity.Empty)
        {
            FindObjectOfType<PipeManager>().GetNextPipe(x, y, GetComponent<Image>(), this);
        }
        else
        {
            RotatePipe();
        }
    }
}
