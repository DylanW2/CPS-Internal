using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public float length, width;
    public float timer, doorSlideSpeed;
    private mapSpawner mS;
    public int mySide, secSide;
    GameObject clone;
    public bool isTouching = false, focus = false;
    private spawner spawnScript;
    // Start is called before the first frame update

    private void Awake()
    {
        mS = GameObject.Find("MapSpawner").GetComponent<mapSpawner>();
        /*spawnScript = GameObject.Find("Spawner").GetComponent<spawner>();
        spawnScript.minX = minLength + 0.2f;
        spawnScript.maxX = maxLength - 0.2f;
        spawnScript.minX = minWidth + 0.2f;
        spawnScript.maxX = maxWidth - 0.2f;*/
    }
    void Start()
    {
        generateMap();
    }

    // Update is called once per frame
    void Update()
    {
        //OpenDoor(mySide);
        //OpenDoor(secSide);
    }

    void generateMap()
    {
        length = mS.length;
        width = mS.width;
        transform.localScale = new Vector2(length, width);
        mySide = mS.side;
        secSide = mS.oSide;
        //Transform door = gameObject.transform.GetChild(mySide);
    }

    void OpenDoor(int doorSide)
    {
        Transform doorObject = gameObject.transform.GetChild(doorSide);
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
            Transform door = gameObject.transform.GetChild(doorSide);
            Transform doorPos1 = door.transform.GetChild(0).GetComponent<Transform>();
            Transform doorPos2 = door.transform.GetChild(1).GetComponent<Transform>();
            if (doorSide == 0 || doorSide == 1)
            {
                doorPos1.position = new Vector2(doorPos1.position.x - Time.deltaTime / doorSlideSpeed, doorPos1.position.y);
                doorPos2.position = new Vector2(doorPos2.position.x + Time.deltaTime / doorSlideSpeed, doorPos2.position.y);
            }
            else
            {
                doorPos1.position = new Vector2(doorPos1.position.x, doorPos1.position.y + Time.deltaTime / doorSlideSpeed);
                doorPos2.position = new Vector2(doorPos2.position.x, doorPos2.position.y - Time.deltaTime / doorSlideSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!focus)
        //{
            //Destroy(gameObject);
        //}
    }
}
