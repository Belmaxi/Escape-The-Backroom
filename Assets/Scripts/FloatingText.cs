using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Text textPrefab; // Ԥ����
    public float duration = 2f; // ����ʱ��
    private void Start()
    {
        Destroy(gameObject, duration);
    }

    public void SetText(string text)
    {
        textPrefab.text = text;
    }
}
