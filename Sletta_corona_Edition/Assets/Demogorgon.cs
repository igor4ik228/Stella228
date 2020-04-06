using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demogorgon : Unit
{
    [SerializeField]
    private float speed = 2.0F;

    private Bullet bullet;

    protected private void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected private void OnTriggerEnter2D(Collider2D collider) //метод для дамага выд пулі (смерті від пулі)
    {
        Bullet bullet = collider.GetComponent<Bullet>();

        if(bullet)
        {
            ReceiveDamage();
        }
    }
}
