using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Transform picturePlace;
    public Button coffeeButton;
    public GameObject victoryPanel;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    private Color color;
    public static bool locked;


    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if(!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);

            float rndX = Random.Range(this.transform.position.x, this.transform.position.x + 0.5f);
            float rndY = Random.Range(this.transform.position.y, this.transform.position.y + 0.5f);
            transform.position = new Vector2(rndX, rndY);
        }
    }

    private void OnMouseUp()
    {
        if(Mathf.Abs(transform.position.x - picturePlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - picturePlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(picturePlace.position.x, picturePlace.position.y);
            locked = true;
            coffeeButton.onClick.AddListener(CoffeeButtonOn);
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    private void CoffeeButtonOn()
    {
        coffeeButton.image.color = Color.green;
        victoryPanel.SetActive(true);
    }

}


