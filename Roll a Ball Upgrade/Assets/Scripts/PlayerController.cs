﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
     }
    
     void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        {
            if (Input.GetKeyDown("space") && GetComponent<Rigidbody>().transform.position.y <= 0.6250001f)
            {
                Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);

                GetComponent<Rigidbody>().AddForce(jump);
            }
        }
        if ((transform.position.x > 10 || transform.position.x < -10 || transform.position.z > 10 || transform.position.z < -10)&&count<12)
        {
            loseText.text = "You Lose!! ";
        }

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!!";
        }
    }
}
