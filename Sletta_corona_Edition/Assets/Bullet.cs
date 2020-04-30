using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject parent;
    public GameObject Parent { set { parent = value; } }

    private float speed = 15.0F;

    //по вектору оприділяємо напрямок пулі
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public Color Color
    {
        set { sprite.color = value;  }
    }

    private SpriteRenderer sprite;//силка на компонент
    private void Awake() 
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(gameObject, 1.0F);// час за який буде пропадати пуля
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);//швидкість переміщення пулі
    }

    private void OnTriggerEnter2D(Collider2D collider)//метод, щоб Юніти не вбивали самі себе своїми пулями
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit.gameObject != parent)
        {
            unit.ReceiveDamage();//викликання методу для дамага
            Destroy(gameObject);//при зіткненні видяляти пулю з карти
        }
    }

}
