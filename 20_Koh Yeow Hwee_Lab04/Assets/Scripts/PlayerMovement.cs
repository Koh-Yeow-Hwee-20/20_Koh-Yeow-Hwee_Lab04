﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //PlayerMovement
    public float speed;
    Rigidbody PlayerRigidbody;

    //Coins Collected
    public GameObject Coins;
    private int coinCount;
    int Totalcoin = 4;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);

        if (coinCount == Totalcoin)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++;
            Coins.GetComponent<Text>().text = "Coins Collected = " + coinCount;

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    /*
    // Update is called once per frame
    void Update()
    {

    }
    */
}
