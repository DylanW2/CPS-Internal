using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    private GameObject[] bullets;
    public float time;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = time;
        }
    }
}
