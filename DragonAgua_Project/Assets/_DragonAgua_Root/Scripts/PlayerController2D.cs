using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Jump Configuration")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isFacingRight; //Orientación del personaje
    [SerializeField] Transform groundCheck; //Posición del detector del suelo
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;

    //Variables de referencia general
    Rigidbody2D playerRb;
    Animator anim;
    PlayerInput input;
    Vector2 moveInput;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>(); //Autoreferenciar un componente propio
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Lógica de detección del suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Lógica de las animaciones
        AnimationManagement();
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
    }

    private void FixedUpdate()
    {
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
        if (moveInput.x != 0) anim.SetBool("Run", true);
        else anim.SetBool("Run", false);
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

    #endregion
}
