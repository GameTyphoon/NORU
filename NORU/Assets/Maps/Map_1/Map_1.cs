using UnityEngine;

public class Map_1 : MonoBehaviour {

    public int width;
    public int height;
    public Vector2 excape;
    public GameObject[] tiles;
    
	// Use this for initialization
	void Start () {
        int pos_x = (int)transform.position.x;
        int pos_y = (int)transform.position.y;
        int i, j;

        for (i = pos_y; i < height + pos_y; i++)
        {
            for (j = pos_x; j < width + pos_x; j++)
            {
                if (i == pos_y || j == pos_x || j == width + pos_x - 1 || i == height + pos_y - 1)
                {
                    if (i == pos_y && j == pos_x) Instantiate(tiles[1], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (i == pos_y && j == width + pos_x - 1) Instantiate(tiles[7], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (i == height + pos_y - 1 && j == pos_x) Instantiate(tiles[3], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (i == height + pos_y - 1 && j == width + pos_x - 1) Instantiate(tiles[9], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (i == pos_y) Instantiate(tiles[4], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (j == pos_x) Instantiate(tiles[2], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (i == height + pos_y - 1) Instantiate(tiles[6], new Vector3(i, j, 0), Quaternion.identity, transform);
                    else if (j == width + pos_x - 1) Instantiate(tiles[8], new Vector3(i, j, 0), Quaternion.identity, transform);
                }
                else
                    Instantiate(tiles[5], new Vector3(i, j, 0), Quaternion.identity, transform);
            }
        }
	}
}
