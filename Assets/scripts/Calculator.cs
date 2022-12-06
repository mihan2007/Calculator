using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField1;
    [SerializeField] private TMP_InputField _inputField2;
    [SerializeField] private TMP_InputField _resultField;
    private float _number1 = 0;
    private float _number2 = 0;
    public float Result;
    public void ReadInputField1(string rawValue)
    {
        rawValue = _inputField1.text; 
        if (float.TryParse(rawValue, out float value))
        {
            _number1 = value;
        }
        else 
        {
            _number1 = 0;
            _inputField1.text = _number1.ToString();
        }
    }
    public void ReadInputField2(string rawValue)
    {
        rawValue = _inputField2.text;
        if (float.TryParse(rawValue, out float value2))
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
        _resultField.text = Result.ToString();
    }
    public void Minus()
    {
        Result = _number1 - _number2;
        Debug.Log(Result);
        _resultField.text = Result.ToString();
    }
    public void Plus()
    {
        Result = _number1 + _number2;
        Debug.Log(Result);
        _resultField.text = Result.ToString();
    }
    public void Divide() 
    {
        if (_number2 != 0)
        {
            Result = _number1 / _number2;
            Debug.Log(Result);
            _resultField.text = Result.ToString();
        }
        else 
        {
            _resultField.text = "You can't divide by zero";
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
        _resultField.text = Result.ToString();
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
        _resultField.text = Result.ToString();
    }
    public void Exponentiation() 
    {
        Result = Mathf.Pow(_number1, _number2);
        _resultField.text = Result.ToString();
    }
}
