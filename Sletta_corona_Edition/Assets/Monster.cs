using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit 
{
    protected virtual void Awake() { }
    protected virtual void Start() { }
    protected virtual void Update() { }

    protected virtual void OnTriggerEnter2D(Collider2D collider) //метод для дамага выд пулі (смерті від пулі)
    {
        Bullet bullet = collider.GetComponent<Bullet>();//провірка зіткнення колайдерів
        
        if(bullet)//якщо зіткнення з пульою - то викликажться метод РесівДемедж
        {
            ReceiveDamage();
        }
    }
}

