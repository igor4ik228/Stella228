using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demoboar : Monster
{
    [SerializeField]
    private float rate = 0.1F; //частота стрільби
    [SerializeField]
    private Color bulletColor = Color.white;

    private Bullet bullet;
    
    protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 1.5F; position.x += 0.5F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.Color = bulletColor;
    }


    protected private void OnTriggerEnter2D(Collider2D collider) //метод для дамага выд пулі (смерті від пулі)
    {
        Unit unit = collider.GetComponent<Unit>();
        
        if (unit && unit is Stella_controller)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }
}
