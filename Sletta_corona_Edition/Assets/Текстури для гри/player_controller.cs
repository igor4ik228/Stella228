using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_going : MonoBehaviour
{
	Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    	//метод для прижка, який перевіряє чи кнопка пробєл нажата і тоді виконує метод ПриЖок
        if(Input.GetKeyDown(KeyCode.Space)) {
        	strybok();
        }
    }
//метод для керування Стеллою (ВПРАВО\ВЛІВО)
   void FixedUpdate(){
    	rb.velocity = new Vector2 (Input.GetAxis ("Horizontal")* 12f, rb.velocity.y);
}
// метод"прижок" для Стелли
void strybok(){
	rb.AddForce (transform.up *15f, ForceMode2D.Impulse);
}
}
