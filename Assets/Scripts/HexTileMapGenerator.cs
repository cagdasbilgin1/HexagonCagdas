using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public static HexTileMapGenerator Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public GameObject hexTilePrefab;
    public GameObject hexBorder;

    [SerializeField] public int mapWidth = 8;
    [SerializeField] public int mapHeight = 9;
    [SerializeField] float tileXOffset = 0.65f;
    [SerializeField] float tileYOffset = 0.74f;
    [SerializeField] float boardXOffset = -2.27f;
    [SerializeField] float boardYOffset = -3.71f;
    GameObject hex;

    public List<Color> colorList = new List<Color>();

    void Start()
    {
        CreateHexTileMap();
    }

    public List<Transform> dots = new List<Transform>();

    void CreateHexTileMap()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                hex = Instantiate(hexTilePrefab);

                SetRandomColor();

                if (i == 0 || (j == 0 && i % 2 != 0))
                {
                    dots.Add(hex.transform.GetChild(0));
                    dots.Add(hex.transform.GetChild(1));

                    hex.transform.GetChild(0).gameObject.SetActive(false);
                    hex.transform.GetChild(1).gameObject.SetActive(false);
                }
                else if (j == 0)
                {
                    hex.transform.GetChild(1).gameObject.SetActive(false);
                    dots.Add(hex.transform.GetChild(0));
                }
                else if (j == mapHeight - 1 && i % 2 == 0)
                {
                    hex.transform.GetChild(0).gameObject.SetActive(false);
                    dots.Add(hex.transform.GetChild(1));
                }
                else
                {
                    dots.Add(hex.transform.GetChild(0));
                    dots.Add(hex.transform.GetChild(1));
                }

                if (i % 2 == 0)
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
        GO.name = x.ToString() + "," + y.ToString();

        var upHex = GameObject.Find(x.ToString() + "," + (y - 1).ToString());

        if (upHex)
        {
            while (upHex.GetComponent<Renderer>().material.color == GO.GetComponent<Renderer>().material.color)
            {
                GO.GetComponent<Renderer>().material.color = colorList[Random.Range(0, colorList.Count)];
            }
        }
    }

    void SetRandomColor()
    {
        var renderer = hex.GetComponent<Renderer>();
        renderer.material.color = colorList[Random.Range(0, colorList.Count)];
    }
}
