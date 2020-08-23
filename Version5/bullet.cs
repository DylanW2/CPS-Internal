using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    Vector2 mousePos, target;
    private float timer;
    public float maxTimer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer = timer - Time.deltaTime;
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(rb.position, mousePos, speed * Time.deltaTime);
        if (timer <= 0 || mousePos == rb.position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Destroy(collision);
            Destroy(gameObject);
        }
    }
}
