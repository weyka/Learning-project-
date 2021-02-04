using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce; // сила прыжка 
    private float moveInput; // нужно для считывания движения( w a s d )

    private Rigidbody2D rb; // компонент rigidbody

    private bool facingRight = true; // переменная означет, что игрок смотрит вправо

    private bool isGrounded; // эта переменная будет проверять приземлился ли игрок
    public Transform feetPos; // здесь берем позицию ног игрока 
    public float checkRadius; // здесь берем радиус насколько близко игрок должен находиться к земле
    public LayerMask whatIsGround; // тут то, что мы считаем за землю 

    private Animator anim;


    private void Start() // стартовая функция ( работает только  при запуске игры )
    {
        anim = GetComponent<Animator>(); // получаем компонент Animator
        rb = GetComponent<Rigidbody2D>(); // мы получаем наш компонент Rigidbody, т.е знакомим наш скрипт с компонентом игрока.
    }
    private void FixedUpdate() // а эта функция работает каждый кадр 
    {
        moveInput = Input.GetAxis("Horizontal"); // здесь записываем, что наш moveInput равен moveInput по горизонтальной оси ( двигаемся вправо или влево )
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // скорость нашего компонента rigidBody
        if(facingRight == false && moveInput > 0) // наша функция Flix будет вызываться когда facingRight = false, т.е мы смотрим влево и клавиша нажата тоже левая (moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) // здесь наш Flix происходит когда все наоборот, т.е когда смотрим вправо и moveInput < 0
        {
            Flip();
        }
        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround); // сюда записываем, что приземление игрока это Physics2D какой-то круг, а в пареметры другие переменные

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)) // если мы приземлились и нажали клавишу Space, то 
        {
            rb.velocity = Vector2.up * jumpForce; // мы прыгаем
            anim.SetTrigger("takeoff");
        }

        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale; // в эти двух строчках мы берем оригинальное положение нашего игрока 
        Scaler.x *= -1; // и умножаем его по x на -1
        transform.localScale = Scaler; // применяет наше изменения
        if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // при input < 0 разворачивает на 180
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // при > 0 возвращает в обычное положение
        }
    }
}
