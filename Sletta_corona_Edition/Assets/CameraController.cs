using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target; //за кім буду літати камера

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Stella_controller>().transform;//Слідкування за стелою
    }
    
    private void Update()
    {
        Vector3 position = target.position;     position.z = -20.0F; //вказуємо позицію камери по Z, бо
                                                                     // якщо би цього б небуло то камра була
                                                                     // в тій самій плоскості, що і обєкти
                                                                     // і карта була би програчна
        

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);//Швидкість оновлення позиції камери, яка слідкує за меперміщенням Стелли
    }
    
}
