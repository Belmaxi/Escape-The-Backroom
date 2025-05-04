using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Text hideNum;
    public int hideNumValue;

    private void Awake()
    {
        hideNum = GetComponentInChildren<Text>();
        hideNum.text = hideNumValue.ToString();
    }
}
