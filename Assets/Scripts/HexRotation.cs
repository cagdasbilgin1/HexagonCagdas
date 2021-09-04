using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class HexRotation : MonoBehaviour
{
    public static HexRotation Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public bool isRotating;

    Sequence mySequence;
    public void Rotate(Vector3 vec)
    {
        isRotating = true;
        if (transform.eulerAngles.z >= 59)
        {
            if (vec.z < 0)
            {
                mySequence = DOTween.Sequence();
                mySequence.Append(transform.DORotate(new Vector3(0, 0, -60), .3f, RotateMode.Fast).OnStepComplete(ControlMatch).SetLoops(3, LoopType.Incremental));
            }
            else
            {
                mySequence = DOTween.Sequence();
                mySequence.Append(transform.DORotate(new Vector3(0, 0, 180), .3f, RotateMode.Fast).OnStepComplete(ControlMatch).SetLoops(3, LoopType.Incremental));
            }
        }
        else if (transform.eulerAngles.z <= 5)
        {
            mySequence = DOTween.Sequence();
            mySequence.Append(transform.DORotate(vec, .3f, RotateMode.Fast).OnStepComplete(ControlMatch).SetLoops(3, LoopType.Incremental));
        }
        Invoke("SetBoolBack", 1);
    }

    private int hex1X, hex1Y, hex2X, hex2Y, hex3X, hex3Y;
    private int offset;
    private void ControlMatch()
    {
        string[] subs;
        var hex1 = transform.GetChild(0);
        var hex2 = transform.GetChild(1);
        var hex3 = transform.GetChild(2);
        subs = hex1.name.Split(',');
        hex1X = Int32.Parse(subs[0]);
        hex1Y = Int32.Parse(subs[1]);
        subs = hex2.name.Split(',');
        hex2X = Int32.Parse(subs[0]);
        hex2Y = Int32.Parse(subs[1]);
        subs = hex3.name.Split(',');
        hex3X = Int32.Parse(subs[0]);
        hex3Y = Int32.Parse(subs[1]);

        float _hex1posX = hex1.transform.localPosition.x;
        float _hex1posY = hex1.transform.localPosition.y;
        float _hex1posZ = hex1.transform.localPosition.z;
        float _hex2posX = hex2.transform.localPosition.x;
        float _hex2posY = hex2.transform.localPosition.y;
        float _hex2posZ = hex2.transform.localPosition.z;
        float _hex3posX = hex3.transform.localPosition.x;
        float _hex3posY = hex3.transform.localPosition.y;
        float _hex3posZ = hex3.transform.localPosition.z;

        GameObject otherHex1, otherHex2, otherHex3, otherHex4, otherHex5, otherHex6, otherHex7, otherHex8, otherHex9;

        if (transform.eulerAngles.z <= 5)
        {
            if (hex1X % 2 == 0)
            {
                otherHex1 = GameObject.Find(hex1X - 1 + "," + (hex1Y - 1));
                otherHex2 = GameObject.Find(hex1X - 2 + "," + (hex1Y - 1));
                otherHex3 = GameObject.Find(hex1X - 2 + "," + (hex1Y));
                otherHex4 = GameObject.Find(hex1X - 1 + "," + (hex1Y + 1));
                otherHex5 = GameObject.Find(hex1X + "," + (hex1Y + 1));
                otherHex6 = GameObject.Find(hex1X + 1 + "," + (hex1Y + 1));
                otherHex7 = GameObject.Find(hex1X + 1 + "," + (hex1Y));
                otherHex8 = GameObject.Find(hex1X + 1 + "," + (hex1Y - 1));
                otherHex9 = GameObject.Find(hex1X + "," + (hex1Y - 2));
            }
            else
            {
                otherHex1 = GameObject.Find(hex1X - 1 + "," + (hex1Y - 2));
                otherHex2 = GameObject.Find(hex1X - 2 + "," + (hex1Y - 1));
                otherHex3 = GameObject.Find(hex1X - 2 + "," + (hex1Y));
                otherHex4 = GameObject.Find(hex1X - 1 + "," + (hex1Y));
                otherHex5 = GameObject.Find(hex1X + "," + (hex1Y + 1));
                otherHex6 = GameObject.Find(hex1X + 1 + "," + (hex1Y));
                otherHex7 = GameObject.Find(hex1X + 1 + "," + (hex1Y - 1));
                otherHex8 = GameObject.Find(hex1X + 1 + "," + (hex1Y - 2));
                otherHex9 = GameObject.Find(hex1X + "," + (hex1Y - 2));
            }
        }
        else if (transform.eulerAngles.z >= 59)
        {
            if (hex1X % 2 == 0)
            {
                otherHex1 = GameObject.Find(hex1X + "," + (hex1Y - 1));
                otherHex2 = GameObject.Find(hex1X - 1 + "," + (hex1Y - 1));
                otherHex3 = GameObject.Find(hex1X - 2 + "," + (hex1Y - 1));
                otherHex4 = GameObject.Find(hex1X - 2 + "," + (hex1Y));
                otherHex5 = GameObject.Find(hex1X - 2 + "," + (hex1Y + 1));
                otherHex6 = GameObject.Find(hex1X - 1 + "," + (hex1Y + 2));
                otherHex7 = GameObject.Find(hex1X + "," + (hex1Y + 1));
                otherHex8 = GameObject.Find(hex1X + 1 + "," + (hex1Y + 1));
                otherHex9 = GameObject.Find(hex1X + 1 + "," + (hex1Y));
            }
            else
            {
                otherHex1 = GameObject.Find(hex1X + "," + (hex1Y - 1));
                otherHex2 = GameObject.Find(hex1X - 1 + "," + (hex1Y - 2));
                otherHex3 = GameObject.Find(hex2X - 1 + "," + (hex2Y));
                otherHex4 = GameObject.Find(hex2X - 1 + "," + (hex2Y + 1));
                otherHex5 = GameObject.Find(hex2X - 1 + "," + (hex2Y + 2));
                otherHex6 = GameObject.Find(hex2X + "," + (hex2Y + 2));
                otherHex7 = GameObject.Find(hex2X + 1 + "," + (hex2Y + 2));
                otherHex8 = GameObject.Find(hex1X + 1 + "," + (hex1Y));
                otherHex9 = GameObject.Find(hex1X + 1 + "," + (hex1Y - 1));
            }
        }
        else
        {
            otherHex1 = null;
            otherHex2 = null;
            otherHex3 = null;
            otherHex4 = null;
            otherHex5 = null;
            otherHex6 = null;
            otherHex7 = null;
            otherHex8 = null;
            otherHex9 = null;
        }

        if (hex1.GetComponent<Renderer>().material.color == otherHex2.GetComponent<Renderer>().material.color)
        {
            if (hex1.GetComponent<Renderer>().material.color == otherHex3.GetComponent<Renderer>().material.color)
            {
                offset = -1;

                mySequence.Kill();

                transform.rotation = Quaternion.Euler(0, 0, 60);

                hex1.transform.localPosition = new Vector3(_hex2posX, _hex2posY, _hex2posZ);
                hex2.transform.localPosition = new Vector3(_hex3posX, _hex3posY, _hex3posZ);
                hex3.transform.localPosition = new Vector3(_hex1posX, _hex1posY, _hex1posZ);

                hex1.name = (hex2X) + "," + hex2Y;
                hex2.name = (hex3X) + "," + (hex3Y);
                hex3.name = (hex1X) + "," + (hex1Y);

                hex1.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                hex3.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

                hex1.transform.parent = transform.parent;
                hex2.transform.parent = transform.parent;
                hex3.transform.parent = transform.parent;

                FillBlankHexes(otherHex2, otherHex3);

                var newHex1 = GameObject.Find(hex1X + "," + (hex1Y));
                var newHex2 = GameObject.Find(hex2X + "," + (hex2Y));
                var newHex3 = GameObject.Find(hex3X + "," + (hex3Y));

                newHex1.transform.parent = transform;
                newHex2.transform.parent = transform;
                newHex3.transform.parent = transform;

                newHex1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex2.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex3.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
        else if (hex1.GetComponent<Renderer>().material.color == otherHex5.GetComponent<Renderer>().material.color)
        {
            if (hex1.GetComponent<Renderer>().material.color == otherHex6.GetComponent<Renderer>().material.color)
            {
                offset = 1;

                mySequence.Kill();
                transform.rotation = Quaternion.Euler(0, 0, 60);

                hex1.transform.localPosition = new Vector3(_hex3posX, _hex3posY, _hex3posZ);
                hex2.transform.localPosition = new Vector3(_hex1posX, _hex1posY, _hex1posZ);
                hex3.transform.localPosition = new Vector3(_hex2posX, _hex2posY, _hex2posZ);

                hex1.name = (hex3X) + "," + hex3Y;
                hex2.name = (hex1X) + "," + hex1Y;
                hex3.name = (hex2X) + "," + hex2Y;

                hex1.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                hex2.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

                hex1.transform.parent = transform.parent;
                hex2.transform.parent = transform.parent;
                hex3.transform.parent = transform.parent;

                FillBlankHexes(downHex(otherHex6), otherHex5);

                var newHex1 = GameObject.Find(hex1X + "," + (hex1Y));
                var newHex2 = GameObject.Find(hex2X + "," + (hex2Y));
                var newHex3 = GameObject.Find(hex3X + "," + (hex3Y));

                newHex1.transform.parent = transform;
                newHex2.transform.parent = transform;
                newHex3.transform.parent = transform;

                newHex1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex2.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex3.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
        else if (hex2.GetComponent<Renderer>().material.color == otherHex5.GetComponent<Renderer>().material.color)
        {
            if (hex2.GetComponent<Renderer>().material.color == otherHex6.GetComponent<Renderer>().material.color)
            {
                offset = 1;

                mySequence.Kill();
                transform.rotation = Quaternion.Euler(0, 0, 60);

                hex1.transform.localPosition = new Vector3(_hex3posX, _hex3posY, _hex3posZ);
                hex2.transform.localPosition = new Vector3(_hex1posX, _hex1posY, _hex1posZ);
                hex3.transform.localPosition = new Vector3(_hex2posX, _hex2posY, _hex2posZ);

                hex1.name = (hex3X) + "," + hex3Y;
                hex2.name = (hex1X) + "," + hex1Y;
                hex3.name = (hex2X) + "," + hex2Y;

                hex1.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                hex2.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

                hex1.transform.parent = transform.parent;
                hex2.transform.parent = transform.parent;
                hex3.transform.parent = transform.parent;

                FillBlankHexes(downHex(otherHex6), otherHex5);

                var newHex1 = GameObject.Find(hex1X + "," + (hex1Y));
                var newHex2 = GameObject.Find(hex2X + "," + (hex2Y));
                var newHex3 = GameObject.Find(hex3X + "," + (hex3Y));

                newHex1.transform.parent = transform;
                newHex2.transform.parent = transform;
                newHex3.transform.parent = transform;

                newHex1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex2.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex3.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
        else if (hex2.GetComponent<Renderer>().material.color == otherHex6.GetComponent<Renderer>().material.color)
        {
            if (hex2.GetComponent<Renderer>().material.color == otherHex7.GetComponent<Renderer>().material.color)
            {
                offset = 1;

                mySequence.Kill();
                transform.rotation = Quaternion.Euler(0, 0, 60);

                hex1.transform.localPosition = new Vector3(_hex3posX, _hex3posY, _hex3posZ);
                hex2.transform.localPosition = new Vector3(_hex1posX, _hex1posY, _hex1posZ);
                hex3.transform.localPosition = new Vector3(_hex2posX, _hex2posY, _hex2posZ);

                hex1.name = (hex3X) + "," + hex3Y;
                hex2.name = (hex1X) + "," + hex1Y;
                hex3.name = (hex2X) + "," + hex2Y;

                hex1.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                hex2.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

                hex1.transform.parent = transform.parent;
                hex2.transform.parent = transform.parent;
                hex3.transform.parent = transform.parent;

                FillBlankHexes(otherHex6, otherHex7);

                var newHex1 = GameObject.Find(hex1X + "," + (hex1Y));
                var newHex2 = GameObject.Find(hex2X + "," + (hex2Y));
                var newHex3 = GameObject.Find(hex3X + "," + (hex3Y));

                newHex1.transform.parent = transform;
                newHex2.transform.parent = transform;
                newHex3.transform.parent = transform;

                newHex1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex2.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newHex3.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
    }

    void FillBlankHexes(GameObject go1, GameObject go2)
    {
        isRotating = true;
        string topLeft = ((hex1X - 2) + "," + (HexTileMapGenerator.Instance.mapHeight - 1));
        string topRight = ((hex1X - 1) + "," + (HexTileMapGenerator.Instance.mapHeight - 1));

        Transform topLeftGO = GameObject.Find(topLeft).transform;
        Transform topRightGO = GameObject.Find(topRight).transform;

        GameObject hexLeft, hexRight;
        for (int i = 0; i < HexTileMapGenerator.Instance.mapHeight; i++)
        {

            hexLeft = GameObject.Find(hex1X - 2 + "," + (hex1Y + offset + i));
            if (hex1X % 2 == 0)
            {
                hexRight = GameObject.Find(hex1X - 1 + "," + (hex1Y + offset + i));
            }
            else
            {
                hexRight = GameObject.Find(hex1X - 1 + "," + (hex1Y + offset - 1 + i));
            }

            if (hexLeft)
            {
                var tempPos = hexLeft.transform.position;
                var tempName = hexLeft.name;

                if (hexLeft != go2)
                {
                    hexLeft.transform.DOMove(go2.transform.position, .3f);
                    hexLeft.name = go2.name;
                }

                go2.name = tempName;
                go2.transform.position = tempPos;
            }

            if (hexRight)
            {
                var tempPos = hexRight.transform.position;
                var tempName = hexRight.name;

                if (hexRight != go1)
                {
                    hexRight.transform.DOMove(go1.transform.position, .3f);
                    hexRight.name = go1.name;
                }

                go1.name = tempName;
                go1.transform.position = tempPos;

            }
        }

        SetFallingHexesColor(go1, go2);

        go1.SetActive(true);
        go2.SetActive(true);

        go1.transform.position = new Vector3(go1.transform.position.x, 20, go1.transform.position.z);
        go2.transform.position = new Vector3(go2.transform.position.x, 20, go2.transform.position.z);

        go1.transform.DOMove(topRightGO.transform.position, .3f);
        go2.transform.DOMove(topLeftGO.transform.position, .3f);

    }

    GameObject downHex(GameObject hex)
    {
        var subs = hex.name.Split(',');
        var hexX = Int32.Parse(subs[0]);
        var hexY = Int32.Parse(subs[1]);
        return GameObject.Find(hexX + "," + (hexY - 1));
    }

    private void SetFallingHexesColor(GameObject go1, GameObject go2)
    {
        string topLeft = ((hex1X - 2) + "," + (HexTileMapGenerator.Instance.mapHeight - 2));
        string topRight = ((hex1X - 1) + "," + (HexTileMapGenerator.Instance.mapHeight - 2));

        GameObject topLeftGO = GameObject.Find(topLeft);
        GameObject topRightGO = GameObject.Find(topRight);

        do
        {
            int rnd = UnityEngine.Random.Range(0, HexTileMapGenerator.Instance.colorList.Count);
            Color newColor = HexTileMapGenerator.Instance.colorList[rnd];
            go1.GetComponent<Renderer>().material.color = newColor;
        } while (go1.GetComponent<Renderer>().material.color == topRightGO.GetComponent<Renderer>().material.color);
        do
        {
            int rnd = UnityEngine.Random.Range(0, HexTileMapGenerator.Instance.colorList.Count);
            Color newColor = HexTileMapGenerator.Instance.colorList[rnd];
            go2.GetComponent<Renderer>().material.color = newColor;
        } while (go2.GetComponent<Renderer>().material.color == topLeftGO.GetComponent<Renderer>().material.color);
    }

    private void SetBoolBack()
    {
        isRotating = false;
    }

}
