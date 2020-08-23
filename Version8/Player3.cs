using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public TMP_Text winText;
    public int killcount;
    public GameObject cam;
    //public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Instantiate(test, transform.position, Quaternion.identity);
    }
    
    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(x, y);
        rb.position = ((Vector2)rb.position + (movement * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            winText.text = "YOU LOST!";
            Time.timeScale = 0;
        }
    }

    private void LateUpdate()
    {
        cam.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, -20);
    }
}
