using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour
{
    public Text counterText;
    int kills;

    private void Update()
    {
        ShowKills();
    }
    private void ShowKills()
    {
        counterText.text = kills.ToString();

    }
    public void AddKIll()
    {
        kills++;

    }
}