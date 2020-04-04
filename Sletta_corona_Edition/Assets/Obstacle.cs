using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) //перевіряємо чи хтось торкається даного тригера (обєкта)
    {
        Unit unit = collider.GetComponent<Unit>();

        if(unit && unit is Stella_controller)
        {
            unit.ReceiveDamage();
        } 
    }
}
