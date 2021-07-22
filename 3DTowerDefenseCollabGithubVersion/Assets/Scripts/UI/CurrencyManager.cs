using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    [Header("UI - Currency")]
    public Text currencyUI;
    public static int currency;

    void Start()
    {
        currency = 1150; 
    } 

    void Update()
    {
        currencyUI.text = "£" + (currency);
    }
}
