using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    bool CanJump;
    public float Speed;
    public float JumpForce;
    Rigidbody2D rb;
    float Yangle;
    public VariableJoystick dj;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Surface"))
        {
            CanJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Surface"))
        {
            CanJump = false;
        }
    }
    private void Update()
    {
        var x = dj.Horizontal;
        Vector2 move = new Vector2(x * Speed * Time.deltaTime,0);
        rb.AddForce(move, ForceMode2D.Force);
        if (dj.Horizontal != 0)
        {
            Yangle = dj.Horizontal>0 ? 0 : 180;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, Yangle, 0));
    }
   
    public void jump()
    {
        if(CanJump)
        rb.AddForce(Vector2.up * JumpForce);
    }

}
