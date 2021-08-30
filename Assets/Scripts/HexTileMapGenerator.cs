using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTilePrefab;

    [SerializeField] int mapWidth = 8;
    [SerializeField] int mapHeight = 9;
    [SerializeField] float tileXOffset = 0.65f;
    [SerializeField] float tileYOffset = 0.74f;
    [SerializeField] float boardXOffset = -2.27f;
    [SerializeField] float boardYOffset = -3.71f;

    void Start()
    {
        CreateHexTileMap();
    }


    void CreateHexTileMap()
    {
        for(int i = 0; i < mapWidth; i++)
        {
            for(int j = 0; j < mapHeight; j++)
            {
                GameObject hex = Instantiate(hexTilePrefab);

                if( i % 2 == 0)
                {
                    hex.transform.position = new Vector2(i * tileXOffset, j * tileYOffset + tileYOffset * 0.5f);
                }
                else
                {
                    hex.transform.position = new Vector2(i * tileXOffset, j * tileYOffset);
                }
                
                SetTileInfo(hex, i, j);
            }
        }
    }
    void SetTileInfo(GameObject GO, int x, int y)
    {
        GO.transform.parent = transform;
        GO.transform.Translate(boardXOffset, boardYOffset, 0);
        GO.name = x.ToString() + ", " + y.ToString();
    }
}
