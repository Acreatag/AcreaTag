using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    bool CanJump;
    public float Speed;
    public float JumpForce;
    Rigidbody2D rb;
    int where;
    float Yangle;
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
    public void Update()
    {
       transform.rotation = Quaternion.Euler(new Vector3(0, Yangle, 0));
    }
    public void Go(int where)
    {
        Yangle = 90 * (where - 1);
        Debug.Log(Yangle);
        rb.AddForce(Vector2.right * Speed *where);
    }
    
    public void jump()
    {
        if(CanJump)
        rb.AddForce(Vector2.up * JumpForce);
    }

}
