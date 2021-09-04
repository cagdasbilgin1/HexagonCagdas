using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] int threshold = 200;
    Vector3 startPos, endPos;

    void Start()
    {
        startPos = endPos;
    }

    void Update()
    {
        if (HexRotation.Instance)
        {
            if (!HexRotation.Instance.isRotating)
            {
#if UNITY_EDITOR
                MoveInput();
#elif UNITY_ANDROID || UNITY_IOS
        TouchInput();
#endif
            }
        }
    }

    void MoveInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            endPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (DecideDirection() != Vector3.zero)
            {
                if (HexRotation.Instance)
                {
                    HexRotation.Instance.Rotate(DecideDirection());
                }
            }
        }
    }

    void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                endPos = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (DecideDirection() != Vector3.zero)
                {
                    if (HexRotation.Instance)
                    {
                        HexRotation.Instance.Rotate(DecideDirection());
                    }
                }
            }
        }
    }

    Vector3 DecideDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Mathf.Abs(endPos.x - startPos.x) > Mathf.Abs(endPos.y - startPos.y))
        {
            if (Mathf.Abs(endPos.x - startPos.x) > threshold)
            {
                if (endPos.x > startPos.x)
                {
                    direction = new Vector3(0, 0, -120);
                }
                else if (endPos.x < startPos.x)
                {
                    direction = new Vector3(0, 0, 120);

                }
            }
        }
        else if (Mathf.Abs(endPos.x - startPos.x) < Mathf.Abs(endPos.y - startPos.y))
        {
            if (Mathf.Abs(endPos.y - startPos.y) > threshold)
            {
                if (endPos.y > startPos.y)
                {
                    direction = new Vector3(0, 0, -120);

                }
                else if (endPos.y < startPos.y)
                {
                    direction = new Vector3(0, 0, 120);
                }
            }
        }
        return direction;
    }
}
