using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField1;
    [SerializeField] private TMP_InputField _inputField2;
    [SerializeField] private TMP_InputField _resultField;
    [SerializeField] private float _result;
    [SerializeField] private bool _comma = false;
    [SerializeField] private bool _screenInputMode = true;
    [SerializeField] private int _operationID;
    [SerializeField] private int _preOperationID;

    public float _number1 = 0;
    public float _number2 = 0;

    public void ChangeFocus()
    {
        _inputField1.ActivateInputField();
    }
    public void ReadInputField1(string rawValue)
    {
        //_number1 = float.Parse(rawValue);

        if (float.TryParse(rawValue, out float value2))
        {
            _number1 = value2;
        }
        else
        {
            _number1 = 0;
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
        _comma = _inputField1.text.Contains(",");

        if (_screenInputMode == false)
        {
            _inputField1.text = "";
            _screenInputMode = true;
        }
        if (_operationID == 3) 
        {

        }

        if (ButtonNumber != 34)  // the number 34 is ID number of _comma button
        {
            _inputField1.text = _inputField1.text + ButtonNumber.ToString();
        }
        else if (ButtonNumber == 34 && _comma == false)
        {
            _inputField1.text = _inputField1.text + ",";
            _comma = true;
        }
    }

    public void OperationOnClick(string operaion)
    {

        Debug.Log(operaion);
        switch (operaion)
        {
            case "clear":
                _result = 0;
                _inputField1.text = "";
                _inputField2.text = "";
                break;

        }


    }
    public void Multiply()
    {
        _result = _number1 * _number2;
        _resultField.text = _result.ToString();
    }

    public void Plus()
    {
        _operationID = 1;
        ReadInputField1(_inputField1.text);
        _result = _result + _number1;
        _inputField2.text = _inputField2.text + _inputField1.text + "+";
        _inputField1.text = _result.ToString();
        _screenInputMode = false;

    }
    public void Minus()
    {
        _operationID = 2;

        ReadInputField1(_inputField1.text);
        if (_result != 0)
        {
            _result = _result - _number1;
            _inputField2.text = _inputField2.text + _inputField1.text + "-";
        }
        else if (_result == 0)
        {
            _result = _number1 - _result;
            _inputField2.text = _inputField2.text + _inputField1.text + "-";
        }
        _inputField1.text = _result.ToString();
        _screenInputMode = false;
        _preOperationID = _operationID;
    }
    public void Divide()
    {
        _operationID = 3;

        if (_number1 == 0 && _number2 == 0) 
        {
            ReadInputField1(_inputField1.text);
        }
        else if (_number1 != 0)
        {
            _number2 = float.Parse(_inputField1.text);
        }

        _inputField2.text = _inputField2.text + _inputField1.text + "/";

        Debug.Log("nimber1 = "+_number1);
        Debug.Log("nimber2 = " + _number2);

        void NewMethod()
        {
            ReadInputField1(_inputField1.text);
            _screenInputMode = false;
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
    public void Polarity ()
    {

    }
    public void EqualButtonOnClick()
    {
        switch (_operationID)
        {
            case 1:
                _inputField2.text = "";
                _result = _result + float.Parse(_inputField1.text);
                _inputField1.text = _result.ToString();
                _screenInputMode = false;
                _number1 = 0;
                _result = 0;
                Debug.Log(_result);
                break;
            case 2:
                _inputField2.text = "";
                _result = _result - float.Parse(_inputField1.text);
                _inputField1.text = _result.ToString();
                _screenInputMode = false;
                _number1 = 0;
                _result = 0;
                Debug.Log(_result);
                break;
            case 3:
                _result = _number1 / float.Parse(_inputField1.text);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _result = 0;
                break;
        }
    }

}
