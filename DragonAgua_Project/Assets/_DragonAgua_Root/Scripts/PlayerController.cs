using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Jump Configuration")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isFacingRight; //Define la orientación del personaje
    [SerializeField] Transform groundCheck; //Posición del detector del suelo
    [SerializeField] float groundCheckRadius; //Define el radio del círculo detector de suelo
    [SerializeField] LayerMask groundLayer; //Define la capa que puede tocar el detector de suelo


    //Referencias generales
    Rigidbody2D playerRb;
    Animator anim;
    PlayerInput input;
    Vector2 moveinput;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();   
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
        //detectar el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Animaciones logica

        //Flip del personaje
        if (moveinput.x > 0 && !isFacingRight) Flip();
        if (moveinput.x > 0 && !isFacingRight) Flip();

    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //Mover la aceoeracion del rigidbody
        playerRb.linearVelocity = new Vector2(moveinput.x * speed, playerRb.linearVelocity.y);
    }
    
    void Flip()
    {
        Vector2 currectScale = transform.localScale;
        currectScale.x *= -1;
        transform.localScale = currectScale;
        isFacingRight = !isFacingRight; //cambiar al valor contrario



    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }


    void AnimationManagement()
    {
        //Accón para cambios de animacion



    }



}
