using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float moveSpeed = -5;

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        //transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
