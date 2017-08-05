using UnityEngine;

public class Trap : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(7, 0, 0);
    }
}
