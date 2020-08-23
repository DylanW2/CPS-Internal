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
        Vector2 dif = mousePos - rb.position;
        target = new Vector2((dif.x * 999), ((dif.x * 999) * (dif.y / dif.x)));

    }

    // Update is called once per frame
    private void Update()
    {
        timer = timer - Time.deltaTime;
    }
    void FixedUpdate()
    {
        
        rb.position = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Destroy(collision);
            //gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }

        if (collision.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
