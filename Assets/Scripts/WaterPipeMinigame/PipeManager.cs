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
    [SerializeField]
    Texture[] pipeGradients;
    public List<GameObject> gridObjs = new List<GameObject>();
    public List<GameObject> nextObjs = new List<GameObject>();

    // Water flowing variables
    int currentX;
    int currentY;

    void Start()
    {
        SpawnGrid();
        SpawnNextColumn();
        StartCoroutine(WaterFlowLoop());
    }

    void SpawnGrid()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                GameObject newGridObj = Instantiate(gridObj, gridT);
                gridObjs.Add(newGridObj);
                newGridObj.GetComponent<SingleGrid>().SetPos(i, j);
                newGridObj.GetComponent<RectTransform>().localPosition += Vector3.right * newGridObj.GetComponent<RectTransform>().rect.width * i
                + Vector3.down * newGridObj.GetComponent<RectTransform>().rect.height * j;
                if(i == 0 && j == height - 1)
                {
                    int random = Random.Range(0, pipes.Length);
                    newGridObj.GetComponent<Image>().sprite = pipes[random];
                    newGridObj.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[random]);
                    newGridObj.GetComponent<SingleGrid>().SetLogic(random);
                    currentX = i;
                    currentY = j;
                }
                if(i == width - 1 && j == 0)
                {
                    int random = Random.Range(0, pipes.Length);
                    newGridObj.GetComponent<Image>().sprite = pipes[random];
                    newGridObj.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[random]);
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
            int random = Random.Range(0, pipes.Length);
            newGridObj.GetComponent<Image>().sprite = pipes[random];
            newGridObj.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[random]);
            newGridObj.GetComponent<SingleGrid>().SetLogic(random);
            int randRot = Random.Range(0, 4);
            for(int j = 0; j < randRot; j++)
            {
                newGridObj.GetComponent<SingleGrid>().RotatePipe();
            }
            newGridObj.GetComponent<SingleGrid>().numOfRotations = randRot;
            nextObjs.Add(newGridObj);
        }
    }

    public void GetNextPipe(int clickedX, int clickedY, Image img, SingleGrid g)
    {
        // ridObjs[clickedX + width*clickedY].GetComponent<Image>().sprite
        img.sprite = nextT.GetChild(nextT.childCount-1).GetComponent<Image>().sprite;
        img.material.SetTexture("_GradientTex", nextT.GetChild(nextT.childCount-1).GetComponent<Image>().material.GetTexture("_GradientTex"));
        for(int i = 0; i < nextT.GetChild(nextT.childCount-1).GetComponent<SingleGrid>().numOfRotations; i++)
        {
            g.RotatePipe();
        }
        g.SetLogic((int)nextT.GetChild(nextT.childCount-1).GetComponent<SingleGrid>().currentPipe);
        Destroy(nextT.GetChild(nextT.childCount-1).gameObject);
        // nextObjs.RemoveAt(nextObjs.Count - 1);
        
        // Add one to end, change it to start and change rest to +1
        GameObject newGridObj = Instantiate(gridObj, nextT);
        // nextObjs.Add(newGridObj);
        int random = Random.Range(0, pipes.Length);
        newGridObj.GetComponent<Image>().sprite = pipes[random];
        newGridObj.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[random]);
        newGridObj.GetComponent<SingleGrid>().SetLogic(random);
        int randRot = Random.Range(0, 4);
        for(int j = 0; j < randRot; j++)
        {
            newGridObj.GetComponent<SingleGrid>().RotatePipe();
        }
        newGridObj.GetComponent<SingleGrid>().numOfRotations = randRot;

        nextT.GetChild(nextT.childCount-1).transform.SetAsFirstSibling();
        // GameObject firstObj = nextObjs[0];
        // // nextObjs[0] = nextObjs[nextObjs.Count-1];
        // for(int i = 0; i < nextObjs.Count-1; i++)
        // {
        //     nextObjs[i] = nextObjs[i+1];
        // }
        // nextObjs[0] = firstObj;
    }

    public IEnumerator WaterFlowLoop()
    {
        yield return new WaitForSeconds(2.0f);
        gridObjs[currentX + width*currentY].GetComponent<Image>().material.SetFloat("_WaterValue", 1);
        float lerp = 0.0f;
        while(lerp < 1.0f)
        {
            gridObjs[currentX + width*currentY].GetComponent<Image>().material.SetFloat("_WaterValue", 1.0f-lerp);
            lerp += Time.deltaTime * 0.2f;
            yield return null;
        }
    }
}
