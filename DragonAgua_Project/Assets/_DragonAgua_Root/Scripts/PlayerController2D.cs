using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;


    [Header("Movement & Jump Configuration")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isFacingRight; //Orientación del personaje
    [SerializeField] Transform groundCheck; //Posición del detector del suelo
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    float fallMultiplier;
    float lowJumpMultiplier;

    //dash
    [Header("Dash Settings")]
    public bool dashUnlocked = false;
    public float dashForce = 20f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;

    bool isdashing = false;
    float dashCooldownTimer = 0f;
    
    //Coins
    public int coins = 0;
    public int coinsNeededForDash = 4;

   
    public TMP_Text dashText;

    //Variables de referencia general
    Rigidbody2D playerRb;
    Animator anim;
    PlayerInput input;
    Vector2 moveInput;

    private void Awake()
    {
        Instance = this;
        playerRb = GetComponent<Rigidbody2D>(); //Autoreferenciar un componente propio
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
        fallMultiplier = 2.5f;
        lowJumpMultiplier = 2f;

        dashText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Cooldown del dash
        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;
        
        //Lógica de detección del suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Lógica de las animaciones
        AnimationManagement();
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
        if (playerRb.linearVelocity.y < 0)
        {
            playerRb.linearVelocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if(!isdashing)
        Movement();
    }

    void Movement()
    {
        
        //Mover el motor de aceleración del RigidBody
        playerRb.linearVelocity = new Vector2(moveInput.x * speed, playerRb.linearVelocity.y);
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale; //Almacén temporal de la escala del objeto
        currentScale.x *= -1; //Invertir el valor en x
        transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    void AnimationManagement()
    {
        //Acción para gestionar los cambios de animación
        anim.SetBool("Jump", !isGrounded);
        anim.SetBool("OnGround", isGrounded);
        anim.SetFloat("yVelocity", playerRb.linearVelocity.y);
        anim.SetBool("isDashing", isdashing);

        if (moveInput.x != 0) anim.SetBool("Run", true);
        else anim.SetBool("Run", false);
    }

    //Dash
    public void UnlockDash()
    {
        dashUnlocked = true;
        Debug.Log("Dash desbloqueado desde playerController");
    }

    void TryDash()
    {
        if (!dashUnlocked) return;
        if (isdashing) return;
        if (dashCooldownTimer > 0) return;

        StartCoroutine(DoDash());

    }

    public void ShowText()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        dashText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        dashText.gameObject.SetActive(false);   
    }

    System.Collections.IEnumerator DoDash()
    {
        isdashing = true;
        dashCooldownTimer = dashCooldown;

        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0;

        //Direccion del dash
        float direction = isFacingRight ? 1 : -1;
        playerRb.linearVelocity = new Vector2(direction * dashForce, 0);

        yield return new WaitForSeconds(dashDuration);

        playerRb.gravityScale = originalGravity;
        isdashing = false;
    }
    
    public void AddCoin()
    {
        coins++;

        if (coins >= coinsNeededForDash && !dashUnlocked)
        {
            UnlockDash();
          

            ShowText();

            
            
        }

    }

    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Jump();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) anim.SetTrigger("Attack");
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) TryDash();
    }
    #endregion
}
