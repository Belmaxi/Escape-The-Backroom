using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridsGenerator : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public Material blackGridMaterial;
    public Material whiteGridMaterial;
    public Material redGridMaterial;

    private GameObject[,] grids;
    void Start()
    {
        grids = new GameObject[height, width];
        for (int i = 0; i < height; i++)
        {
            for(int j = 0;j < width; j++)
            {
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.SetParent(gameObject.transform);
                obj.transform.localPosition = new Vector3(i, 0, j);
                obj.GetComponent<MeshRenderer>().material = (i + j) % 2 == 0 ? blackGridMaterial: whiteGridMaterial;
                grids[i, j] = obj;
            }
        }

        int randX = Random.Range(0, height);
        int randY = Random.Range(0, width);
        while(randX == 0 && randY == 0)
        {
            randX = Random.Range(0, height);
            randY = Random.Range(0, width);
        }
        grids[randX, randY].GetComponent<MeshRenderer>().material = redGridMaterial;

        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
