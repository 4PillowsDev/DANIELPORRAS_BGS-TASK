using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    public int money = 2000;
    public Text Mtext;

    // Update is called once per frame
    void Update()
    {
        Mtext.text = "" + money;
    }
}
