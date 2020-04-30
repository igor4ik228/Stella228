using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Demogorgon : Unit
{
    [SerializeField]
    private float speed = 2.0F;//швидкість

    private Vector3 direction;

    

    private SpriteRenderer sprite;//силка на компонент

    protected private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    protected private void Start()
    {
        direction = transform.right; //рух
    }
    protected private void Update()
    {
        Move();
    }

    protected private void OnTriggerEnter2D(Collider2D collider) //метод для дамага выд пулі (смерті від пулі)
    {
        Bullet bullet = collider.GetComponent<Bullet>();//провірка зіткнення колайдерів

        if (bullet)//якщо зіткнення з пульою - то викликажться метод РесівДемедж
        {
            ReceiveDamage();
        }
    }

    private void Move()//ходьба
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x *0.6F, 0.1F);//провірка зітнкнення калайдерів на відстані

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<Stella_controller>())) direction *= -1.0F;//якщо колайдери зіткнулись - то розворот

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); //швидкість преміщення 
    }
}
