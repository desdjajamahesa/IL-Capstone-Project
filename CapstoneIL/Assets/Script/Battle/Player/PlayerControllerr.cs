using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerControllerr Instance;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private LayerMask solidObjectsLayer; // Tambahkan LayerMask untuk solid objects
    [SerializeField] private LayerMask interactableLayer; // Tambahkan LayerMask untuk interactable objects

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private Knockback knockback;
    private SpriteRenderer mySpriteRender;

    private bool facingLeft = false;

    private void Awake()
    {
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        if (knockback.gettingKnockedBack) { return; }

        Vector2 targetPos = rb.position + movement * (moveSpeed * Time.fixedDeltaTime);

        if (IsWalkable(targetPos))
        {
            rb.MovePosition(targetPos);
        }
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
            FacingLeft = true;
        }
        else
        {
            mySpriteRender.flipX = false;
            FacingLeft = false;
        }
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // Memeriksa tabrakan dengan solidObjectsLayer atau interactableLayer
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }

        return true;
    }
}
