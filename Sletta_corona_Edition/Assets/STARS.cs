using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STARS : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colider)//при зіткненні колайдерів Стіли і Серця - Сетелі буде +1ХР
    {
        Stella_controller stella_controller = colider.GetComponent<Stella_controller>();
        if (stella_controller)
        {
            stella_controller.Stars++;//більшення на 1 ХР
            Destroy(gameObject);//видалення серця з сцени
           
        }
    }
}
