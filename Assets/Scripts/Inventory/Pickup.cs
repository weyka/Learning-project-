using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Invetory inventory; // ��������� ��� ���������
    public GameObject slotButton; // ������ �������� ������� ����� ������ � �����
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Invetory>(); // �� �������� ��������� ��������� � ������ ������
    }
}
