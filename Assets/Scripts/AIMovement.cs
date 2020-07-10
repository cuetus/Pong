using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public Transform pallo;
    //private float of;

    void Awake()
    {
        pallo = GameObject.Find("pallo").transform;
    }

    void Start()
    {
        if (Settings.difficulty == Difficulty.Normal)
            speed *= 2f;
        else if (Settings.difficulty == Difficulty.Hard)
            speed *= 2f;
    }
    void Update()
    {
        if(!MasterScript.gameEnded && transform.position.y != pallo.position.y)
        {
            float moveAmount = speed * Time.deltaTime;
            if(!CheckIfMovingTooMuch(moveAmount))
            {
                if (transform.position.y < pallo.position.y)
                {
                    transform.Translate(0f, moveAmount, 0f);
                }
                else
                {
                    transform.Translate(0f, -moveAmount, 0f);
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, pallo.position.y);
            }
        }
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.35f, 4.35f), 0);
    }

    bool CheckIfMovingTooMuch(float moveAmount)
    {
        if (Mathf.Abs(transform.position.y - pallo.position.y) < moveAmount)
            return true;
        else
            return false;
    }
}