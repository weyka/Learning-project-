using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Invetory inventory; // указываем наш инвентарь
    public GameObject slotButton; // объект предмета который будет лежать в слоте
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invetory>(); // мы получаем компонент инвентарь у нашего игрока
    }
}
