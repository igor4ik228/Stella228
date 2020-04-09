using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demogorgon : Unit
{
    [SerializeField]
    private float speed = 2.0F;

    private Vector3 direction;

    private Bullet bullet;

    private SpriteRenderer sprite;

    protected private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected private void Start()
    {
        direction = transform.right;
    }
    protected private void Update()
    {
        Move();
    }

    protected private void OnTriggerEnter2D(Collider2D collider) //метод для дамага выд пулі (смерті від пулі)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if(bullet)
        {
            ReceiveDamage();
        }
    }

    private void Move()//ходьба
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x *0.6F, 0.1F);

        if (colliders.Length > 0) direction *= -1.0F;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
