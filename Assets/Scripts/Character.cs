using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class Character : MonoBehaviour
{
    [SerializeField] float xSpeed = 5;
    [SerializeField] float xairSpeed = 5.5f;
    [SerializeField] float jump = 400;
    [SerializeField] Transform groundCheck;
    [SerializeField] AudioClip move;
    [SerializeField] LayerMask groundLayerMask;

    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator animator;
    AudioSource source;

    Vector3 velocity = Vector3.zero;

    bool facingRight = true;
    float inputx;

    bool grounded = false;
    public UnityEvent OnLandEvent;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckGround();
        inputx = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(inputx));

        if(Mathf.Abs(rb.velocity.x) > 0 && grounded)
        {
            //source.clip = move;
            //source.Play();
        }

        if (inputx > 0 && !facingRight)
            Flip();
        else if (inputx < 0 && facingRight)
            Flip();

        if (grounded && Input.GetButtonDown("Jump"))
        {
            grounded = false;
            rb.AddForce(new Vector2(0, jump));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(inputx * (grounded ? xSpeed : xairSpeed), rb.velocity.y, 0), ref velocity, .05f);
    }

    private void CheckGround()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(coll.size.x, .05f), 0, groundLayerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
