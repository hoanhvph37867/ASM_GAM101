using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag  == "mushroom")
        {
            animator.SetBool("running", false);
            animator.SetBool("idle", false);
            animator.SetBool("die", true);
        }
    }

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    float movePrefix = 6;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(Vector2.up * movePrefix, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            rigidbody2D.AddForce(Vector2.left * movePrefix, ForceMode2D.Impulse);

            animator.SetBool("running", true);
            animator.SetBool("idle", false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            rigidbody2D.AddForce(Vector2.right * movePrefix, ForceMode2D.Impulse);

            animator.SetBool("running", true);
            animator.SetBool("idle", false);
        }
    }
}
