using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stella_controller : Unit
{
    [SerializeField]
    private int lives = 5;//HP
    [SerializeField] //атрибут для відображення цьої настройкі скрипта в найстройках персонажа
   private float speed =  3.0F;
    [SerializeField]
    private float jumpForce = 15.0F; //сила прижка
    
    public int Lives
    {
        get { return lives; }
        set
            {
            if (value < 5) lives = value;
            livesBar.Refresh();
            }
    }
    private LivesBar livesBar;


    private Bullet bullet; //ссилка на пулю

    //дзя зміни анамації
    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

        // ссилкі на компоненти
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite; //ССИЛКА  на компонент, щоб первонаж смыг повретитись в рызны сторони
    
    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        bullet = Resources.Load<Bullet>("Bullet");
    }

    private void Update() //буде вся логыка, оброблювач подій
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
        State = CharState.idle;
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void Run()
    {
        //задаємо векторний напрямок вправ і вліво
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0F;

        State = CharState.walk;
    }

    private void Jump()
    {
        State = CharState.stellaJump;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 1.5F; position.x += 1.35F; //позиція виліту пулі
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);//напрямок
    }

    public override void ReceiveDamage()
    {
        Lives--;

        //відкидання при зіькненні:
        //змінення шкидкості в 0
        rigidbody.velocity = Vector3.zero;
        //відкидання в верх
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

        Debug.Log(lives);

        if(lives<=0) //смерть
        {
            
            Invoke("ReloadScene", 0);
        }

        
    }

    ///Метод, який загружає сфену ФІНІШ при заткенні Стелли з колайдером замку
   private void OnTriggerEnter2D(Collider2D finish)
    {
        if (finish.gameObject.tag == "Finish")
        {
            Application.LoadLevel("Finish");
        }
    }


    private void ReloadScene()//перезагрузка сцени (уровня)
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

public enum CharState //клас з можливими станами персонажа
{
    idle, //0
    walk,  //1
    stellaJump  //2
}

