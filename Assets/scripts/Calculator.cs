using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{

    public TMP_InputField InputField1;
    public TMP_InputField InputField2;
    public TMP_InputField ResultField;
    private float _number1 = 0;
    private float _number2 = 0;
    public float Result;



    public void ReadIputField1(string s)
    {
        s = InputField1.text; 
        if (float.TryParse(s, out float value)) // проверяем является введенное значение числом
        {
            //_number1 = float.Parse(s);
            _number1 = value;
        }
        else 
        {
            _number1 = 0;       // если поле пустое или введено не число приравниваем число к нулю 
        }
         //Debug.Log(_number1);
    }

    public void ReadIputField2(string s2)
    {
        s2 = InputField2.text;
        if (float.TryParse(s2, out float value2))
        {
            _number2 = value2;
        }
        else
        {
            _number2 = 0;
        }
    }

    public void Multiply()
    {
        Result = _number1 * _number2;
        Debug.Log(Result);
        ResultField.text = Result.ToString();

    }

    public void Minus ()
    {
        Result = _number1 - _number2;
        Debug.Log(Result);
        ResultField.text = Result.ToString();
    }

    public void Plus()
    {
        Result = _number1 + _number2;
        Debug.Log(Result);
        ResultField.text = Result.ToString();
    }

    public void Divide() 
    {
        if (_number2 != 0)
        {
            Result = _number1 / _number2;
            Debug.Log(Result);
            ResultField.text = Result.ToString();
        }
        else 
        {
            ResultField.text = "You can't divide by zero";
        }
    }

    public void Minimum()
    {
        if (_number1 > _number2)
        {
            Result = _number2;
        }
        else 
        {
            Result = _number1;
        }
        ResultField.text = Result.ToString();
    }
    public void Maximum()
    {
        if (_number1 < _number2)
        {
            Result = _number2;
        }
        else
        {
            Result = _number1;
        }
        ResultField.text = Result.ToString();
    }

    public void Exponentiation() 
    {
        Result = Mathf.Pow(_number1, _number2);
        ResultField.text = Result.ToString();
    }
}
