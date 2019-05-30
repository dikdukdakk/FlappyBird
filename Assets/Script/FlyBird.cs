using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyBird : MonoBehaviour
{
    public GameManager current;     //GameManager Object
    bool isAlive;

    public float tabForce = 250;    //Tap to jump
    public float tiltSmooth = 2f;   //smooth jump
    public Vector3 startPos;

    Rigidbody2D rb;
    Quaternion downRotation;
    Quaternion forwardRotation;

    void Start()
    {
        //Getcomponent & flix rotation of bird
        rb = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -45);
        forwardRotation = Quaternion.Euler(0, 0, 35);

        //Bird is alive
        isAlive = true;
        
    }

    void Update()
    {
        //Bird is alive
        if (isAlive == false)
            return;
        
        //Bird is dead
        else
        {
            //input click scene for control (tap to fly)
            if (Input.GetMouseButtonDown(0))
            {
                //Control
                transform.rotation = forwardRotation;
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * tabForce, ForceMode2D.Force);

                //Audio
                FindObjectOfType<SoundManager>().PlaySound("TapControl");
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
    }


    //Collision
    void OnCollisionEnter2D(Collision2D col)
    {
        //Off active CircleCollider2D
        GetComponent<CircleCollider2D>().enabled = false;

        //When Bird Dead. Active GameOver UI
        current.GameOver();

        //Audio
        FindObjectOfType<SoundManager>().PlaySound("Collision_PIPE");

        //Bird is dead
        isAlive = false;

    }

    //Trigger
    void OnTriggerEnter2D(Collider2D colTri)
    {
        //ถ้านกชน object อื่นที่ไม่ได้ชื่อ GetScore ให้ออกจากฟังก์ชัน 
        //GetScore = ช่องระหว่าง PIPE
        if (colTri.gameObject.name != "GetScore")
            return;

        //When bird pass one PIPE get 1 point
        Score.score++;

        //Audio
        FindObjectOfType<SoundManager>().PlaySound("GetPoint");
    }

}
