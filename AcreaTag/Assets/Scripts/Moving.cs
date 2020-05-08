using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public VariableJoystick dj;
    public float AnimationPlaySpeed;

    Rigidbody2D rb;
    Animator anim;
    float Yangle;
    bool IsOnGround;

    void Start()
    {
        AnimationPlaySpeed = 0.1f;
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            IsOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Surface"))
        {
            IsOnGround = false;
        }
    }
    private void Update()
    {
        var x = dj.Horizontal;
        Vector2 move = new Vector2(x * Speed * Time.deltaTime,0);
        rb.AddForce(move, ForceMode2D.Force);
        if (dj.Horizontal != 0)
        {
            var newAngle = dj.Horizontal > 0 ? 0 : 180;
            if (Yangle != newAngle)
            {
                Yangle = newAngle;
                rb.velocity = new Vector2(0,rb.velocity.y);
            }
        }
        var animspeed = Mathf.Abs(rb.velocity.x) * AnimationPlaySpeed;
        anim.speed = IsOnGround ? animspeed : 0;
        transform.rotation = Quaternion.Euler(new Vector3(0, Yangle, 0));
    }
    public void jump()
    {
        if(IsOnGround)
        rb.AddForce(Vector2.up * JumpForce);
    }

}
