using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField1;
    [SerializeField] private TMP_InputField _resultField;
    [SerializeField] private float _result;
    [SerializeField] private bool _comma;
    [SerializeField] private bool _screenInputMode = true;
    [SerializeField] private bool _numberOneStatus;
    [SerializeField] private int _operationID;

    private float _number1;
    private float _number2;

    public void Clear()
    {
        _number1 = 0;
        _number2 = 0;
        _inputField1.text = "";
        _resultField.text = "";
    }
    public void ChangeFocus()
    {
        _inputField1.ActivateInputField();
    }
    public void InputNumberOnClick(int ButtonNumber)
    {
        _comma = _inputField1.text.Contains(",");

        if (_screenInputMode == false)
        {
            _inputField1.text = "";
            _screenInputMode = true;
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
    public void Polarity()
    {
        if (_inputField1.text.Contains("-"))
        {
            _inputField1.text = Mathf.Abs(float.Parse(_inputField1.text)).ToString();
        }
        else
        {
            _inputField1.text = "-" + _inputField1.text;
        }
    }
    public void OperationOnClick(int ID)
    {
        if (ID != 0 && ID != _operationID && _numberOneStatus == true)
        {
            OperationOnClick(_operationID);
        }

        if (_numberOneStatus == false)
        {

            if (_inputField1.text != "")
            {
                _number1 = float.Parse(_inputField1.text);
            }
            else
            {
                _number1 = 0;
            }

            if (ID == 1)
            {
                _resultField.text = _number1.ToString() + "+";
            }
            else if (ID == 2)
            {
                _resultField.text = _number1.ToString() + "-";
            }
            else if (ID == 3)
            {
                _resultField.text = _number1.ToString() + "*";
            }
            else if (ID == 4)
            {
                _resultField.text = _number1.ToString() + "/";
            }
            else if (ID == 5)
            {
                _resultField.text = _number1.ToString() + "^";
            }
            else if (ID == 6)
            {
                _resultField.text = "Ln(" + _number1.ToString() + ")";
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
            }
            else if (ID == 7)
            {
                _resultField.text = "Log10(" + _number1.ToString() + ")";
                _result = Mathf.Log10(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
            }
            else if (ID == 8)
            {
                _resultField.text = "Ctï(" + _number1.ToString() + ")";
                _result = 1 / Mathf.Tan(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
            }
            else if (ID == 9)
            {
                _resultField.text = "Sin(" + _number1.ToString() + ")";
                _result = Mathf.Sin(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
            }
            else if (ID == 10)
            {
                _resultField.text = "factorization(" + _number1.ToString() + ")";
                string _result = Fraction(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
            }
            _screenInputMode = true;
            _numberOneStatus = true;
            _inputField1.text = "";
        }

        else
        {

            _number2 = float.Parse(_inputField1.text);

            Debug.Log("number1=" + _number1.ToString());
            Debug.Log("number2=" + _number2.ToString());


            _resultField.text = _resultField.text + _number2.ToString();

            if (ID == 1)
            {
                _result = _number1 + _number2;
            }
            else if (ID == 2)
            {
                _result = _number1 - _number2;
            }
            else if (ID == 3)
            {
                _result = _number1 * _number2;
            }
            else if (ID == 4)
            {
                _result = _number1 / _number2;
            }
            else if (ID == 5)
            {
                _result = Mathf.Pow(_number1, _number2);
            }

            _inputField1.text = _result.ToString();
            _numberOneStatus = false;
            _number1 = 0;
            _number2 = 0;
        }

        _operationID = ID;
        Debug.Log("result=" + _result.ToString());
    }
    public void EqualButtonOnClick()
    {
        if (_numberOneStatus == true)
        {
            OperationOnClick(_operationID);
        }
        else
        {
            Clear();
        }
    }
    public string Fraction(float fracNum)
    {
        string sendToFunction;
        if (fracNum == ((double)((int)fracNum)))
        {
            List<int> result = new List<int>();
            int divisor = 2;
            while (fracNum != 1)
            {
                while (fracNum % divisor == 0)
                {
                    result.Add(divisor);
                    fracNum = fracNum / divisor;
                }
                divisor = divisor + 1;
            }
            sendToFunction = string.Join(",", result);
        }

        else
        {
            sendToFunction = "Not a natural number";
        }
        return sendToFunction;
    }
}
