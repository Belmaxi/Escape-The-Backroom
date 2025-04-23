using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Text hideNum;
    public int hideNumValue;

    private void Start()
    {
        hideNum = GetComponentInChildren<Text>();
        hideNum.text = hideNumValue.ToString();
    }
}
