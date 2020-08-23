using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpawner : MonoBehaviour
{
    GameObject room;
    public GameObject roomPrefab;
    mapGenerator mG;
    int arrayIndex = 0;
    public int side, oSide;
    public float minWidth, maxWidth, minLength, maxLength, length, width, testx, testy;
    public GameObject[] rooms;
    // Start is called before the first frame update
    void Awake()
    {
        room = GameObject.Find("Room");
        mG = room.GetComponent<mapGenerator>();
        length = Random.Range(minLength, maxLength);
        width = Random.Range(minWidth, maxWidth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newMap()
    {
        Transform rT = room.GetComponent<Transform>();
        float posx = rT.position.x;
        float posy = rT.position.y;
        mG = room.GetComponent<mapGenerator>();
        length = Random.Range(minLength, maxLength);
        width = Random.Range(minWidth, maxWidth);
        side = mG.secSide;
        oSide = Random.Range(0, 4);
        if (side == 0)
        {
            posy = rT.position.y + (((mG.width / 2) * testy) + ((width / 2) * testy));
        }
        else if (side == 1)
        {
            posy = rT.position.y - (((mG.width / 2) * testy) + ((width / 2) * testy));
        }
        else if (side == 2)
        {
            posx = rT.position.x - (((mG.length / 2) * testx) + ((length / 2) * testx));
        }
        else
        {
            posx = rT.position.x + ((mG.length / 2) * testx) + ((length / 2) * testx);
        }
        GameObject clone = Instantiate(roomPrefab, new Vector2(posx, posy), Quaternion.identity);
        rooms[arrayIndex] = clone;
        room = clone;
        arrayIndex++;
        if (arrayIndex > 3) arrayIndex = 0;
    }
}
