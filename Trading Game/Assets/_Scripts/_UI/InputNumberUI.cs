using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputNumberUI : MonoBehaviour
{

    [SerializeField] TMP_InputField inputField;

    public void Start()
    {
        inputField.onValueChanged.AddListener(ValidateString);
        inputField.characterLimit = 9;
    }

    public void ValidateString(string newString)
    {
        string outputString = "";
        foreach (char x in inputField.text)
        {
            if (char.IsDigit(x))
            {
                outputString += x;
            }
        }
        inputField.text = outputString;
        if (outputString.Length > 0 && outputString.Length < 10)
        {
            PlayerPrefs.SetInt("seed", int.Parse(outputString));
        }
    }
}
