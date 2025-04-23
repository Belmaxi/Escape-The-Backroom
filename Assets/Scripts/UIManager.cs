using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("UIManager");
                    instance = obj.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    public GameObject floatingText;

    public void GenerateFloatingText(Vector3 position, string text)
    {
        GameObject textObject = Instantiate(floatingText, position, Quaternion.identity);
        textObject.transform.LookAt(GameDriver.Instance.player.transform.position);
        textObject.transform.Rotate(0, 180, 0); // 旋转180度，使其面向玩家
        textObject.GetComponent<FloatingText>().SetText(text);
    }
}
