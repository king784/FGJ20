using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeManager : MonoBehaviour
{
    [SerializeField]
    int width;
    [SerializeField]
    int height;
    [SerializeField]
    GameObject gridObj;
    [SerializeField]
    Transform gridT;
    [SerializeField]
    Transform nextT;
    [SerializeField]
    Sprite[] pipes;
    List<GameObject> gridObjs = new List<GameObject>();

    void Start()
    {
        SpawnGrid();
        SpawnNextColumn();
    }

    void SpawnGrid()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                GameObject newGridObj = Instantiate(gridObj, gridT);
                gridObjs.Add(newGridObj);
                newGridObj.GetComponent<RectTransform>().localPosition += Vector3.right * newGridObj.GetComponent<RectTransform>().rect.width * i
                + Vector3.down * newGridObj.GetComponent<RectTransform>().rect.height * j;
                if(i == 0 && j == height - 1)
                {
                    int random = Random.Range(0, 2);
                    newGridObj.GetComponent<Image>().sprite = pipes[random];
                    newGridObj.GetComponent<SingleGrid>().SetLogic(random);
                }
                if(i == width - 1 && j == 0)
                {
                    int random = Random.Range(0, 2);
                    newGridObj.GetComponent<Image>().sprite = pipes[random];
                    newGridObj.GetComponent<SingleGrid>().SetLogic(random);
                    if(random == 0)
                    {
                        newGridObj.GetComponent<SingleGrid>().RotatePipe();
                    }
                }
            }
        }
    }

    void SpawnNextColumn()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject newGridObj = Instantiate(gridObj, nextT);
            int random = Random.Range(0, 3);
            newGridObj.GetComponent<Image>().sprite = pipes[random];
            newGridObj.GetComponent<SingleGrid>().SetLogic(random);
            for(int j = 0; j < random; j++)
            {
                newGridObj.GetComponent<SingleGrid>().RotatePipe();
            }
        }
    }
}
