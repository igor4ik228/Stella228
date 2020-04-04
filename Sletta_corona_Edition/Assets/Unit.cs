using System.Collections;

using UnityEngine;

public class Unit : MonoBehaviour
{
    //метод, який викликає смерть
    public virtual void ReceiveDamage()
    {
        Die();
    }

    protected virtual void Die()//метод, який забрає героя з карти
    {
        Destroy(gameObject);
    }
}
