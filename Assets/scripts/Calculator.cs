using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{

    public TMP_InputField InputField1;
    public TMP_InputField InputField2;
    private float _number1;
    //public string Result;

    

    public void ReadIputField1(string s)
    {
        s = InputField1.text; // ��������� �������� �� ���������� ���� 1 
        if (float.TryParse(s, out float result)) // ��������� �������� ��������� �������� ������
        {
            _number1 = float.Parse(s);      // ���� �� �� ����������� ������ � ����� 
        }
        else 
        {
            _number1 = 0;       // ���� ���� ������ ��� ������� �� ����� ������������ ����� � ���� 
        }

        Debug.Log(s);
    }

    public void ReadIputField2(string s2)
    {
        s2 = InputField2.text;
        Debug.Log(s2);
    }

    public void ClickOperation(string val) 
     {
        Debug.Log(message: $" ClickOperatio val: {val}");
//        input1.text = $"nk";
     }
}
