using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demoboar : Monster
{
    [SerializeField]
    private float rate = 0.1F; //частота стрільби
    [SerializeField]
    private Color bulletColor = Color.white;

    private Bullet bullet;//силка на компонент
    
    protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");//силка на ресурс (пулю), а іменно на префаб пулі, яким буде Демобоар стріляти
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 1.5F; position.x += 0.5F; //позиція виліту пулі
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = -newBullet.transform.right; //напрямок польоту пулі
        newBullet.Color = bulletColor;//зміна кольору пулі
    }


    protected private void OnTriggerEnter2D(Collider2D collider) //метод для смерті від Задавлення Стелою
    {
        Unit unit = collider.GetComponent<Unit>();//силка на Юніт з класа юніт
        
        if (unit && unit is Stella_controller)//Якщо зіткнення Юніта (Демооара) з Юнітом(Стеллою)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();//Коли координати Х (Стели) віднявши координати Х Демобоара бдуть меньше 0.3 - то визвати метод РесівДемендж 
            else unit.ReceiveDamage();// запистити метод РесівДемедж у Стелли (відняти 1 ХР)
        }
    }
}
