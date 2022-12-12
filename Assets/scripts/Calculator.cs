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
    [SerializeField] private bool _screenInputMode = true; // The imput field has two will have two diffrenet modes. Firstone it to show result after press button "=" and the second is edition mode 
    [SerializeField] private bool _numberOneStatus= false;
    [SerializeField] private int _operationID;
    [SerializeField] private int _preOperationID;

    public float _number1 = 0;
    public float _number2 = 0;

    public void clear()
    {
        _number1 = 0;
        _number2 = 0;
        _inputField1.text = "";
        _inputField2.text = "";
    {



    }
    }

    public void ChangeFocus()
    {
        _inputField1.ActivateInputField();
    }
    public void ReadInputField1(string rawValue)
    {
 
        if (float.TryParse(rawValue, out float value2))
        {
            _number1 = value2;
        }
        else
        {
            _number1 = 0;
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


    public void Polarity ()
    {

    }

    public void OperationOnClick(int ID)
    {
            if (ID !=0 && ID != _operationID && _numberOneStatus == true)
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
                    _inputField2.text = _number1.ToString() + "+";
                }
                else if (ID == 2)
                {
                    _inputField2.text = _number1.ToString() + "-";
                }
                else if (ID == 3)
                {
                    _inputField2.text = _number1.ToString() + "*";
                }
                else if (ID == 4)
                {
                    _inputField2.text = _number1.ToString() + "/";
                }
                else if (ID == 5)
                {
                    _inputField2.text = _number1.ToString() + "^";
                }
                else if (ID == 6)
                {
                _inputField2.text = "Ln(" + _number1.ToString() + ")";
                _result = Mathf.Log(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
                }
                else if (ID == 7)
                {
                _inputField2.text = "Log10(" + _number1.ToString() + ")";
                _result = Mathf.Log10(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
                }
            else if (ID == 8)
            {
                _inputField2.text = "Ctï(" + _number1.ToString() + ")";
                _result = 1 / Mathf.Tan(_number1);
                _inputField1.text = _result.ToString();
                _number1 = 0;
                _number2 = 0;
                return;
            }
            else if (ID == 9)
            {
                _inputField2.text = "Sin(" + _number1.ToString() + ")";
                _result = Mathf.Sin(_number1);
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


                _inputField2.text = _inputField2.text + _number2.ToString();

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
                else if (ID == 6)
                {

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
            clear();
        }
    }

}
