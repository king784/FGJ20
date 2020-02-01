using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Transform picturePlace;
    RectTransform rt;
    public Button coffeeButton;
    public GameObject victoryPanel;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    private Color color;
    public static bool locked;

    public Transform wirePointPlug;
    public Transform wirePointMachine;
    LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        initialPosition = transform.position;
        rt = GetComponent<RectTransform>();
    }

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position);
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
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            //transform.position = new Vector3(mousePosition.x - deltaX, mousePosition.y - deltaY, 0);
            rt.position = new Vector3(mousePosition.x - deltaX, mousePosition.y - deltaY, 2);

            float rndX = Random.Range(this.transform.position.x, this.transform.position.x + 1f);
            float rndY = Random.Range(this.transform.position.y, this.transform.position.y + 1f);
            rt.position = new Vector3(mousePosition.x - deltaX, mousePosition.y - deltaY, 2);
            transform.position = new Vector3(rndX, rndY, 2);
        }
    }

    private void OnMouseUp()
    {
        if(Mathf.Abs(transform.position.x - picturePlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - picturePlace.position.y) <= 0.5f)
        {
            transform.position = new Vector3(picturePlace.position.x - 0.2f, picturePlace.position.y, 2);
            locked = true;
            coffeeButton.onClick.AddListener(CoffeeButtonOn);
        }
        else
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y, 2);
        }
    }

    private void CoffeeButtonOn()
    {
        coffeeButton.image.color = Color.green;
        victoryPanel.SetActive(true);
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, wirePointPlug.position);
        lineRenderer.SetPosition(1, wirePointMachine.position);
    }

}


