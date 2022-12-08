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
    [SerializeField] private float _result;
    [SerializeField] private bool _ñomma = false;
    [SerializeField] private bool _screenInputMode = true;
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
    public void InputNumberOnClick(int ButtonNumber)
    {
        _ñomma = _inputField1.text.Contains(",");
        
        if (_screenInputMode == false) 
        {
            _inputField1.text = "";
            _screenInputMode = true;
        }

        if (ButtonNumber != 34)  // the number 34 is ID number of _ñomma button
        {
            _inputField1.text = _inputField1.text + ButtonNumber.ToString();
        }
        else if (ButtonNumber == 34 && _ñomma == false)
        {
            _inputField1.text = _inputField1.text + ",";
            _ñomma = true;
        }
    }

    public void OperationOnClick (string operaion)
    {
        
        Debug.Log(operaion);
        switch (operaion)
        {
            case "clear":
                _result = 0;
                _inputField1.text = "";
                _inputField2.text = "";
                break;
            case "-1":
                _result = float.Parse(_inputField1.text)* (-1);
                _inputField1.text = _result.ToString();
                break;

            case "+":
                    if (_result == 0)
                {
                    _result = float.Parse(_inputField1.text);
                    _inputField2.text = _result.ToString() + "+";
                    _screenInputMode = false;
                }
                    else
                {
                    _result = _result + float.Parse(_inputField1.text);
                    _inputField2.text = _inputField2.text  + _inputField1.text + "+";
                    _inputField1.text = _result.ToString();
                    _screenInputMode = false;
                }

                break;
            case "=":
                _inputField1.text = _result.ToString();
                _inputField2.text = "";
                _screenInputMode = false;
                break;
        }


    }
    public void Multiply()
    {
        _result = _number1 * _number2;
        _resultField.text = _result.ToString();
    }
    public void Minus()
    {
        _result = _number1 - _number2;
        _resultField.text = _result.ToString();
    }
    public void Plus()
    {
        _result = _number1 + _number2;
        _resultField.text = _result.ToString();
    }
    public void Divide() 
    {
        if (_number2 != 0)
        {
            _result = _number1 / _number2;
            _resultField.text = _result.ToString();
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
            _result = _number2;
        }
        else 
        {
            _result = _number1;
        }
        _resultField.text = _result.ToString();
    }
    public void Maximum()
    {
        if (_number1 < _number2)
        {
            _result = _number2;
        }
        else
        {
            _result = _number1;
        }
        _resultField.text = _result.ToString();
    }
    public void Exponentiation() 
    {
        _result = Mathf.Pow(_number1, _number2);
        _resultField.text = _result.ToString();
    }
}
