using UnityEngine;

public class Move_Chracter : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody;
    Animator anim;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 7.5f;
    }
	
    void PlayAnim(float h_move, float v_move)
    {
        anim.SetFloat("Direction_X", h_move);
        anim.SetFloat("Direction_Y", v_move);
        if (h_move >= 0.1f)
            anim.SetFloat("Flag", 0);
        else if (v_move >= 0.1f)
            anim.SetFloat("Flag", 0.33f);
        else if (v_move <= -0.1f)
            anim.SetFloat("Flag", 0.66f);
        else if (h_move <= -0.1f)
            anim.SetFloat("Flag", 1.0f);

    }

    void MovePlayer(float h_move, float v_move)
    {
        Vector2 movement = new Vector2(h_move, v_move) * speed;
        rigidbody.velocity = Vector2.ClampMagnitude(movement, speed);
    }

    private void FixedUpdate()
    {
        float h_move = Input.GetAxis("Horizontal");
        float v_move = Input.GetAxis("Vertical");

        PlayAnim(h_move, v_move);
        MovePlayer(h_move, v_move);
    }
}