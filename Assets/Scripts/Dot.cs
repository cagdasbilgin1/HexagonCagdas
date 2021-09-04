using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dot : MonoBehaviour
{
    public static Dot Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    GameObject hexBorder;
    public bool isHexBorder60;
    
    GameObject hex1;
    GameObject hex2;
    GameObject hex3;

    public Transform _hex1;
    public Transform _hex2;
    public Transform _hex3;

    int hex1X;
    int hex1Y;
    int hex2X;
    int hex2Y;
    int hex3X;
    int hex3Y;

    private void OnMouseDown()
    {    
        foreach (Transform dot in HexTileMapGenerator.Instance.dots)
        {
            if (dot.transform.parent.parent)
            {
                dot.transform.parent.parent = HexTileMapGenerator.Instance.transform;
                dot.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }

        foreach (Transform dot in HexTileMapGenerator.Instance.dots)
        {
            dot.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        GetComponent<SpriteRenderer>().enabled = true;

        hexBorder = HexTileMapGenerator.Instance.hexBorder; 
        hexBorder.transform.position = transform.position;
        hexBorder.SetActive(true);

        if (transform.parent.GetChild(1) == transform)
        {
            hexBorder.transform.rotation = Quaternion.identity;
            isHexBorder60 = false;
        }
        else
        {

            hexBorder.transform.rotation = Quaternion.Euler(0, 0, 60);
            isHexBorder60 = true;
        }

        transform.parent.parent = hexBorder.transform;

        hex1 = GetSubHex(0);
        hex2 = GetSubHex(1);
        hex3 = GetSubHex(2);

        _hex1 = hex1.transform;
        _hex2 = hex2.transform;
        _hex3 = hex3.transform;

        hex2.transform.parent = hexBorder.transform;
        hex3.transform.parent = hexBorder.transform;

        if(hex1X % 2 == 0)
        {
            hex1.transform.SetSiblingIndex(0);
            hex2.transform.SetSiblingIndex(1);
            hex3.transform.SetSiblingIndex(2);
        }
        else
        {
            hex1.transform.SetSiblingIndex(0);
            hex2.transform.SetSiblingIndex(2);
            hex3.transform.SetSiblingIndex(1);
        }        

        hex1.GetComponent<SpriteRenderer>().sortingOrder = 1;
        hex2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        hex3.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public GameObject GetSubHex(int i)
    {
        List<GameObject> subHexes = new List<GameObject>();

        string[] subs = transform.parent.name.Split(',');
        hex1X = Int32.Parse(subs[0]);
        hex1Y = Int32.Parse(subs[1]);

        if (hex1X % 2 == 0)
        {
            if (transform.parent.GetChild(1) == transform)
            {
                hex2X = hex1X;
                hex2Y = hex1Y - 1;
                hex3X = hex1X - 1;
                hex3Y = hex1Y;
            }
            else
            {
                hex2X = hex1X - 1;
                hex2Y = hex1Y;
                hex3X = hex1X - 1;
                hex3Y = hex1Y + 1;
            }
        }
        else
        {
            if (transform.parent.GetChild(1) == transform)
            {
                hex2X = hex1X;
                hex2Y = hex1Y - 1;
                hex3X = hex1X - 1;
                hex3Y = hex2Y;
            }
            else
            {
                hex2X = hex1X - 1;
                hex2Y = hex1Y;
                hex3X = hex1X - 1;
                hex3Y = hex1Y - 1;
            }
        }
        hex1 = GameObject.Find(hex1X + "," + hex1Y);
        hex2 = GameObject.Find(hex2X + "," + hex2Y);
        hex3 = GameObject.Find(hex3X + "," + hex3Y);

        hex1.transform.SetSiblingIndex(2);
        hex3.transform.SetSiblingIndex(0);
        hex2.transform.SetSiblingIndex(1);

        subHexes.Add(hex1);
        subHexes.Add(hex2);
        subHexes.Add(hex3);

        return subHexes[i];
    }
}
