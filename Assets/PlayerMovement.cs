using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private bool moveLeft;
    private bool moveRight;

    public int score;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(0,0,1000 * Time.deltaTime);
        
        if(moveLeft)
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
        
        if (moveRight)
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Pumpkin"))
        {
            score++;
            AudioManager.instance.PlayCorrect();
            Destroy(other.gameObject);
        }
        else if (other.collider.CompareTag("FinishLine"))
        {
            Win();
        }
    }

    private void Win()
    {
        GameManager.instance.score = this.score;
        SceneManager.LoadScene("FinalScene");
    }
}
