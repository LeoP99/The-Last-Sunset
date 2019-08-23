using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraTerreno : MonoBehaviour
{
    public int depht = 20;
    public int height = 256;
    public int width = 256;
    public float scale = 20f;
    public float offsetx = 100f;
    public float offsety = 100f;
    public Transform carro;

    private void Start()
    {
        offsetx = Random.Range(0f, 9999f);
        offsety = Random.Range(0f, 9999f);

    }

    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GeraTerra(terrain.terrainData);
        offsetx += Time.deltaTime * 5f;
       // offsety += carro.position.y * Time.deltaTime;

    }


    TerrainData GeraTerra(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depht, height);
        terrainData.SetHeights(0, 0, GeraHeights());
        return terrainData;
    }

    float [,] GeraHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++ )
            {
                heights[x, y] = CalculaHeight(x, y);
            }
        }
        return heights;
    }
   
    float CalculaHeight (int x , int y)
    {
        float xCoord = (float)x / width * scale * offsetx;
        float yCoord = (float)y / height * scale * offsety;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

  
}
