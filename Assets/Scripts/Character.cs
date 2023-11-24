using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float airSpeed;
    [SerializeField] float jump;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayerMask;
    float inputx;

    [ShowOnly][SerializeField] bool grounded = false;
    [ShowOnly][SerializeField] bool jumping = false;
    [ShowOnly][SerializeField] bool falling = false;


    bool facingRight = true;

    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator animator;

    Vector3 velocity = Vector3.zero;

    AudioSource audioSource;
    [SerializeField] AudioClip run;

    [SerializeField] GameObject GameManager;
    PauseMenu pauseMenu;

    public GameObject Room;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        pauseMenu = GameManager.GetComponent<PauseMenu>();
    }

    public void SetRoom(GameObject room)
        => Room = room;

    void Update()
    {
        if (pauseMenu.isPaused())
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            return;
        }

        CheckGround();
        AnimateRun();

        inputx = Input.GetAxisRaw("Horizontal");
        if (inputx > 0 && !facingRight)
            Flip();
        else if (inputx < 0 && facingRight)
            Flip();

        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
                Jump();
            else
            {
                jumping = false;
                animator.SetBool("Jump", jumping);
            }
            if (falling)
                Land();

            if (Mathf.Abs(rb.velocity.x) > .5f)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = run;
                    audioSource.Play();
                }
            }
            else
                audioSource.Stop();
        }
        else if (rb.velocity.y < 0)
            Fall();
        else if (audioSource.isPlaying)
            audioSource.Stop();
    }

    void Jump()
    {
        jumping = true;
        grounded = false;
        rb.AddForce(new Vector2(0, jump));

        animator.SetBool("Jump", jumping);
    }

    void Fall()
    {
        if(falling && rb.velocity.y > -10f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.01f);
        }
        else
        {
            jumping = false;
            falling = true;

            animator.SetBool("Jump", jumping);
            animator.SetBool("Fall", falling);
        }
    }

    void Land()
    {
        falling = false;
        jumping = false;

        animator.SetBool("Jump", jumping);
        animator.SetBool("Fall", falling);
    }

    void AnimateRun()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void CheckGround()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(coll.bounds.size.x, .05f), 0, groundLayerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(coll != null)
            Gizmos.DrawCube(groundCheck.position, new Vector3(coll.bounds.size.x, .05f, 0));
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(inputx * (Mathf.Abs(rb.velocity.x) >= 2.5 ? runSpeed : walkSpeed), rb.velocity.y, 0), ref velocity, .1f);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
