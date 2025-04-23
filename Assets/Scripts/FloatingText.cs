using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Text textPrefab; // 预制体
    public float duration = 2f; // 持续时间
    private void Start()
    {
        Destroy(gameObject, duration);
    }

    public void SetText(string text)
    {
        textPrefab.text = text;
    }
}
