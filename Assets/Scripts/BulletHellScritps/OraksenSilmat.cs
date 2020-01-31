using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OraksenSilmat : MonoBehaviour
{

    //void Start()
    //{
    //
    //}
    //
    //
    //void Update()
    //{
    //    eyeFocus();
    //}
    //
    //void eyeFocus()
    //{
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //
    //
    //    Vector2 direction_ = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
    //    transform.up = direction_;
    //    Debug.Log(mousePosition.x + " " + mousePosition.y);
    //}
    public float factor = 0.25f;
    public float limit = 0.08f;

    private Vector3 center;

    void Start()
    {
        //Capture the starting position as a vector3
        center = transform.position;
    }


    void Update()
    {
        //Convert mouse pointer cords into a worldspace vector3
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;

        //Create a dir target based on mouse vector * factor
        Vector3 dir = pos * factor;

        //Clamp the dir target
        dir = Vector3.ClampMagnitude(dir, limit);

        //Update the pupil position
        transform.position = center + dir;
    }
}
