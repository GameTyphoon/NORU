using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//코드 전체에서 x가 높이 축, y가 너비 축

public class MapsGenerator : MonoBehaviour {

    public int room_Count;
    public int width, height;
    int[,] check;
    List<Vector2> select_Rooms;

    public List<Room> generated_Rooms;
    public Room[,] map_Info;

    void Start () {
        Init();
        Generate_Maps(height / 2, width / 2);
        //맵 중앙부터 생성
    }

    //변수 초기화, (배열, 리스트 초기화)
    void Init()
    {
        check = new int[height, width];
        select_Rooms = new List<Vector2>();

        generated_Rooms = new List<Room>();
        map_Info = new Room[height, width];
    }

    //맵 생성 코어 함수
    bool Generate_Maps(int start_Y, int start_X)
    {
        if (start_Y >= height || start_X >= width || start_X < 0 || start_Y < 0 || room_Count > width * height)
            return false;
        //해당 조건으로 맵을 생성 할수 있는지 체크

        select_Rooms.Add(new Vector2(start_Y, start_X));
        check[start_Y, start_X] = 1;
        //맵 중심을 리스트에 삽입

        int temp_Y, temp_X;
        int random;
        int count = 0;

        while (count < room_Count && 0 < select_Rooms.Count)  //방 개수가 목표치까지 생기거나, 리스트가 빌때까지(경우 없음)
        {   
            random = Random.Range(0, select_Rooms.Count);  //생성 가능한 방을 뽑고 제거.
            temp_Y = (int)select_Rooms[random][0];
            temp_X = (int)select_Rooms[random][1];

            generated_Rooms.Add(new Room(temp_Y, temp_X));  //생성된 방은 다른 리스트에 저장
            map_Info[temp_Y, temp_X] = generated_Rooms[generated_Rooms.Count - 1];  //찾기 쉽게 이차원 배열에 등록

            select_Rooms.RemoveAt(random);
            if (temp_Y + 1 < height && check[temp_Y + 1, temp_X] != 1)
            {
                select_Rooms.Add(new Vector2(temp_Y + 1, temp_X));
                check[temp_Y + 1, temp_X] = 1;
            }
            if (temp_X + 1 < width && check[temp_Y, temp_X + 1] != 1)
            {
                select_Rooms.Add(new Vector2(temp_Y, temp_X + 1));
                check[temp_Y, temp_X + 1] = 1;
            }
            if (temp_Y - 1 >= 0 && check[temp_Y - 1, temp_X] != 1)
            {
                select_Rooms.Add(new Vector2(temp_Y - 1, temp_X));
                check[temp_Y - 1, temp_X] = 1;
            }
            if (temp_X - 1 >= 0 && check[temp_Y, temp_X - 1] != 1)
            {
                select_Rooms.Add(new Vector2(temp_Y, temp_X - 1));
                check[temp_Y, temp_X - 1] = 1;
            }
            count++;
        }
        
        return true;
    }
}
public class Room
{
    private int x;  //x가 높이 축 전체 맵에서
    private int y;  //y가 너비 축 전체 맵에서

    private int width;
    private int height;

    private int[,] cell_Info;

    private Room()
    {
        width = 16;
        height = 10;
    }

    public Room(int v1, int v2) : this()
    {
        SetRoomPos(v1, v2);
        SetRoomSize(0);
    }

    public Room(int v1, int v2, int v3) : this()
    {
        SetRoomPos(v1, v2);
        SetRoomSize(v3);
    }

    void SetRoomPos(int v1, int v2)
    {
        x = v1;
        y = v2;
    }

    void SetRoomSize(int size)
    {
        float w = 1.6f;
        float h = 1.0f;

        int minWidth = width - (int)(w * size);
        int maxWidth = width + (int)(w * size);

        int minHeight = height - (int)(h * size);
        int maxHeight = height + (int)(h * size);

        width = Random.Range(minWidth, maxWidth);
        height = Random.Range(minHeight, maxHeight);

        if (width < 8)
            width = 8;
        if (height < 5)
            height = 5;

        cell_Info = new int[height, width];
    }
}