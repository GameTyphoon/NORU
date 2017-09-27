using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    MapsGenerator mapsGenerator;
    GameObject[] gameObjects;

    public GameObject emptyGameObject;

    public GameObject[] tiles;

    public int Height;
    public int Width;
    public int RoomCount;

    public int Start_Y;
    public int Start_X;
    public int Size;
    
    void Start()
    {
        gameObjects = new GameObject[1000];
        for (int i = 0; i < 1000; i++)
            gameObjects[i] = Instantiate(emptyGameObject, new Vector3(-1, -1, -1), Quaternion.identity, transform);

        mapsGenerator = new MapsGenerator();
        mapsGenerator.Start(Height, Width, RoomCount);  //전체 방 크기와 룸의 개수
        mapsGenerator.Generate_Maps(Start_Y, Start_X, Size);  //룸을 만들기 시작할 점과, 각 룸의 랜덤 Size 변수
        
        Room temp = mapsGenerator.generated_Rooms[0];
        temp.RoomGenerate(gameObjects, tiles);
    }
}
