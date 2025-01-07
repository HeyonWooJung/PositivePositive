using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    public bool isJump = false;

    public ThrowHook throwHook;

    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!throwHook.IsHookEnabled())
            {
                rigid.velocity = new Vector2(-5, rigid.velocity.y);
            }
                rigid.AddForce(new Vector2(-1, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!throwHook.IsHookEnabled())
            {
                rigid.velocity = new Vector2(5, rigid.velocity.y);
            }
                rigid.AddForce(new Vector2(1, 0));
        }


        if (Input.GetKeyUp(KeyCode.A))
        {
            if (!throwHook.IsHookEnabled() && !isJump)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            if (!throwHook.IsHookEnabled() && !isJump)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground") && isJump == true)
        {
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }
}
