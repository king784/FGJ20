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
    public Material waterPipeMat;
    GameObject startTile;
    List<SingleGrid> gridBlocks = new List<SingleGrid>();
    public GameObject victoryCanvas;

    // Water flowing variables
    int currentX;
    int currentY;
    public int winX, winY;
    float speedMult = 1.0f;

    void Start()
    {
        SpawnGrid();
        SpawnNextColumn();
        StartCoroutine(WaterFlowLoop());
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            speedMult = 40.0f;
        }
        if(Input.GetButtonUp("Fire2"))
        {
            speedMult = 1.0f;
        }
    }

    void SpawnGrid()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                GameObject newGridObj = Instantiate(gridObj, gridT);
                gridObjs.Add(newGridObj);
                gridBlocks.Add(newGridObj.GetComponent<SingleGrid>());
                newGridObj.GetComponent<SingleGrid>().SetPos(i, j);
                newGridObj.GetComponent<RectTransform>().localPosition += Vector3.right * newGridObj.GetComponent<RectTransform>().rect.width * i
                + Vector3.down * newGridObj.GetComponent<RectTransform>().rect.height * j;
                if(i == 0 && j == height - 1)
                {
                    int random = Random.Range(0, pipes.Length);
                    newGridObj.GetComponent<Image>().sprite = pipes[random];
                    newGridObj.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[random]);
                    newGridObj.GetComponent<SingleGrid>().SetLogic(random);
                    if(random == 0)
                    {
                        newGridObj.GetComponent<SingleGrid>().flowingTo = 2;
                    }
                    else
                    {
                        newGridObj.GetComponent<SingleGrid>().flowingTo = 1;
                    }
                    currentX = i;
                    currentY = j;
                    startTile = newGridObj;
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
                    newGridObj.GetComponent<SingleGrid>().flowingTo = 1;
                }
            }
        }
    }

    void SpawnNextColumn()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject newGridObj = Instantiate(gridObj, nextT);
            gridBlocks.Add(newGridObj.GetComponent<SingleGrid>());
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
        g.SetLogic((int)nextT.GetChild(nextT.childCount-1).GetComponent<SingleGrid>().currentPipe);
        for(int i = 0; i < nextT.GetChild(nextT.childCount-1).GetComponent<SingleGrid>().numOfRotations; i++)
        {
            g.RotatePipe();
        }
        Destroy(nextT.GetChild(nextT.childCount-1).gameObject);
        // nextObjs.RemoveAt(nextObjs.Count - 1);
        
        // Add one to end, change it to start and change rest to +1
        GameObject newGridObj = Instantiate(gridObj, nextT);
        gridBlocks.Add(newGridObj.GetComponent<SingleGrid>());
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
        yield return new WaitForSeconds(0.1f);
        bool firstTime = false;
        bool playing = true;
        SingleGrid nextGrid = null;
        Material newPipeMat = Instantiate(waterPipeMat);
        startTile.GetComponent<Image>().material = newPipeMat;
        startTile.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[1]);
        startTile.GetComponent<Image>().material.SetFloat("_WaterValue", 1);
        nextGrid = startTile.GetComponent<SingleGrid>();
        float lerp = 0.0f;
        while(playing)
        {
            lerp = 0.0f;
            nextGrid.activity = GridActivity.HasWater;
            while(lerp < 1.0f)
            {
                nextGrid.gameObject.GetComponent<Image>().material.SetFloat("_WaterValue", 1.0f-lerp);
                lerp += Time.deltaTime * 0.2f * speedMult;
                yield return null;
            }
            nextGrid.gameObject.GetComponent<Image>().material.SetFloat("_WaterValue", 0.0f);
            if(firstTime)
            {
                if(startTile.GetComponent<SingleGrid>().flowingTo == 1)
                {
                    nextGrid = GetCorrectGrid(startTile.GetComponent<SingleGrid>().x, startTile.GetComponent<SingleGrid>().y-1);
                }
                else if(startTile.GetComponent<SingleGrid>().flowingTo == 2)
                {
                    nextGrid = GetCorrectGrid(startTile.GetComponent<SingleGrid>().x+1, startTile.GetComponent<SingleGrid>().y);
                }
                startTile = nextGrid.gameObject;
                Material newPipeMat2 = Instantiate(waterPipeMat);
                Texture t = nextGrid.gameObject.GetComponent<Image>().material.GetTexture("_GradientTex");
                nextGrid.gameObject.GetComponent<Image>().material = newPipeMat2;
                nextGrid.gameObject.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[(int)nextGrid.currentPipe]);
                nextGrid.gameObject.GetComponent<Image>().material.SetFloat("_WaterValue", 1);
                firstTime = false;
            }
            else
            {
                startTile = nextGrid.gameObject;

                if(nextGrid.x == winX && nextGrid.y-1 == winY)
                {
                    Debug.Log("Win!");
                    victoryCanvas.SetActive(true);
                    playing = false;
                    break;
                }
                if(playing)
                {
                    if(nextGrid.GetComponent<SingleGrid>().flowingTo == 0)
                {
                    nextGrid = GetCorrectGrid(nextGrid.GetComponent<SingleGrid>().x-1, nextGrid.GetComponent<SingleGrid>().y);
                }
                else if(nextGrid.GetComponent<SingleGrid>().flowingTo == 1)
                {
                    nextGrid = GetCorrectGrid(nextGrid.GetComponent<SingleGrid>().x, nextGrid.GetComponent<SingleGrid>().y-1);
                }
                else if(nextGrid.GetComponent<SingleGrid>().flowingTo == 2)
                {
                    nextGrid = GetCorrectGrid(nextGrid.GetComponent<SingleGrid>().x+1, nextGrid.GetComponent<SingleGrid>().y);
                }
                else if(nextGrid.GetComponent<SingleGrid>().flowingTo == 3)
                {
                    nextGrid = GetCorrectGrid(nextGrid.GetComponent<SingleGrid>().x, nextGrid.GetComponent<SingleGrid>().y+1);
                }

                if(nextGrid.x < 0 || nextGrid.x > width-1 || nextGrid.y < 0 || nextGrid.y > height-1)
                {
                    Debug.Log("Game over!");
                    LevelManager.LevelMaster.AddToGrade(-0.5f);
                    playing = false;
                    break;
                }

                Material newPipeMat2 = Instantiate(waterPipeMat);
                nextGrid.gameObject.GetComponent<Image>().material = newPipeMat2;
                nextGrid.gameObject.GetComponent<Image>().material.SetTexture("_GradientTex", pipeGradients[(int)nextGrid.currentPipe]);
                nextGrid.gameObject.GetComponent<Image>().material.SetFloat("_WaterValue", 1);
            }

            if((nextGrid.sides[3] > 0 && startTile.GetComponent<SingleGrid>().sides[1] > 0))
            {
                for(int i = 0; i < 4; i++)
                {
                    if(i != 3)
                    {
                        if(nextGrid.sides[i] > 0)
                        {
                            nextGrid.flowingTo = i;
                            if(nextGrid.flowingTo == 2 && nextGrid.currentPipe == Pipe.Straight && nextGrid.GetComponent<RectTransform>().eulerAngles.z > 170.0f && nextGrid.GetComponent<RectTransform>().eulerAngles.z < 190.0f)
                            {
                                nextGrid.gameObject.GetComponent<Image>().material.SetInt("_Direction", 1);
                            }
                            if(nextGrid.flowingTo == 2 && nextGrid.currentPipe == Pipe.Curve)
                            {
                                nextGrid.gameObject.GetComponent<Image>().material.SetInt("_Direction", 1);
                            }
                        }
                    }
                }
            }
            else if(nextGrid.sides[0] > 0 && startTile.GetComponent<SingleGrid>().sides[2] > 0)
            {
                for(int i = 0; i < 4; i++)
                {
                    if(i != 0)
                    {
                        if(nextGrid.sides[i] > 0)
                        {
                            nextGrid.flowingTo = i;
                            if(nextGrid.flowingTo == 3 && nextGrid.currentPipe == Pipe.Curve)
                            {
                                nextGrid.gameObject.GetComponent<Image>().material.SetInt("_Direction", 1);
                            }
                        }
                    }
                }
            }
            else if(nextGrid.sides[1] > 0 && startTile.GetComponent<SingleGrid>().sides[3] > 0)
            {
                for(int i = 0; i < 4; i++)
                {
                    if(i != 1)
                    {
                        if(nextGrid.sides[i] > 0)
                        {
                            nextGrid.flowingTo = i;
                            if(nextGrid.flowingTo == 0 && nextGrid.currentPipe == Pipe.Curve)
                            {
                                nextGrid.gameObject.GetComponent<Image>().material.SetInt("_Direction", 1);
                            }
                        }
                    }
                }
            }
            else if(nextGrid.sides[2] > 0 && startTile.GetComponent<SingleGrid>().sides[0] > 0)
            {
                for(int i = 0; i < 4; i++)
                {
                    if(i != 2)
                    {
                        if(nextGrid.sides[i] > 0)
                        {
                            nextGrid.flowingTo = i;
                            if(nextGrid.flowingTo == 1 && nextGrid.currentPipe == Pipe.Straight && nextGrid.GetComponent<RectTransform>().eulerAngles.z > -80.0f && nextGrid.GetComponent<RectTransform>().eulerAngles.z < -100.0f)
                            {
                                nextGrid.gameObject.GetComponent<Image>().material.SetInt("_Direction", 1);
                            }
                            if(nextGrid.flowingTo == 1 && nextGrid.currentPipe == Pipe.Curve)
                            {
                                nextGrid.gameObject.GetComponent<Image>().material.SetInt("_Direction", 1);
                            }
                        }
                    }
                }
            }
            else
            {
                playing = false;
                LevelManager.LevelMaster.AddToGrade(-0.5f);
            }
        }    
        }
        
    }

    SingleGrid GetCorrectGrid(int x, int y)
    {
        for(int i = 0; i < gridBlocks.Count-1; i++)
        {
            if(gridBlocks[i].x == x && gridBlocks[i].y == y)
            {
                return gridBlocks[i];
            }
        }
        return null;
    }
}
