using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsGenerator : MonoBehaviour {

    public int room_Count;
    public int width, height;
    public int[,] map_Info, check;
    List<Vector2> select_Rooms;
    List<Vector2> generated_Rooms;

    void Start () {
        Init();
        Generate_Maps(height / 2, width / 2);
        //맵 중앙부터 생성
    }

    //변수 초기화, (배열, 리스트 초기화)
    void Init()
    {
        map_Info = new int[height, width];
        check = new int[height, width];
        select_Rooms = new List<Vector2>();
        generated_Rooms = new List<Vector2>();
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

        //DFS코드
        while (count < room_Count && 0 < select_Rooms.Count)    //방 개수가 목표치까지 생기거나, 리스트가 빌때까지(경우 없음)
        {
            random = Random.Range(0, select_Rooms.Count);   //생성 가능한 방을 뽑고 제거.
            generated_Rooms.Add(select_Rooms[random]);      //생성된 방은 다른 리스트에 저장
            temp_Y = (int)select_Rooms[random][0];
            temp_X = (int)select_Rooms[random][1];
            select_Rooms.RemoveAt(random);

            map_Info[temp_Y, temp_X] = (count + 1);

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

        for(int i = 0; i < generated_Rooms.Count; i++)
        {
            print(generated_Rooms[i]);
        }
        //제대로 됐는지 확인.
        return true;
    }
}