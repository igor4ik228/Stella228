using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPlus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colider)
    {
        Stella_controller stella_controller = colider.GetComponent<Stella_controller>();
        if (stella_controller)
        {
            stella_controller.Lives++;
            Destroy(gameObject);
        }
    }
}
