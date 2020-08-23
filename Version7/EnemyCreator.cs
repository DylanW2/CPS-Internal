using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject[] heads;
    public GameObject[] bodies;
    private Transform player;
    public float rotationSpeed;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 4);
        Create(heads, 0.2f);
        Create(bodies, -0.2f);
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<Transform>().Rotate(new Vector3(0, 0, rotationSpeed));
        GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
    }

    void Create(GameObject[] limbArray, float offset) {
        Vector2 position = new Vector2(transform.position.x, transform.position.y + offset);
        int index = Random.Range(0, limbArray.Length);
        GameObject set = Instantiate(limbArray[index], position, Quaternion.identity);
        set.GetComponent<SpriteRenderer>().color = colour();
        set.transform.parent = gameObject.transform;
    }

    Color32 colour(){
        byte red = (byte)Random.Range(0, 255);
        byte green = (byte)Random.Range(0, 255);
        byte blue = (byte)Random.Range(0, 255);
        Color32 col = new Color32(red, green, blue, 255);
        return col;
    }
}
