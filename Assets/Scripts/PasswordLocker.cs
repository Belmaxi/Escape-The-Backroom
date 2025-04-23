using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PasswordLocker : MonoBehaviour
{
    public GameObject[] passwordButton = new GameObject[12];
    public Text passwordTipText;
    public int[] curPassword = new int[4];
    private int index = 0;
    public string password = "1234";
    public Transform door;

    private bool isok = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var i in passwordButton)
        {
            i.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => UpdateText(i.name));
        }
    }

    public void UpdateText(string chr)
    {
        if (isok) return;
        int num;
        if(int.TryParse(chr,out num))
        {
            if (index == 4) return;
            curPassword[index++] = num;
        }
        else
        {
            if(chr == "B")
            {
                index--;
            }
            if(chr == "OK")
            {
                if (index != 4) return;
                bool ok = true;
                for(int i = 0; i < 4; i++)
                {
                    if (curPassword[i].ToString() != password[i].ToString())
                    {
                        ok = false;
                        index = 0;
                    }
                }
                if (ok)
                {
                    print("ÃÜÂëÕýÈ·");
                    isok = true;
                    door.transform.transform.Rotate(0, -90, 0);
                }
            }
        }
        passwordTipText.text = "";
        for (int i = 0; i < index; i++)
        {
            passwordTipText.text += curPassword[i].ToString() + " ";
        }
        for(int i = index; i < 4; i++)
        {
            passwordTipText.text += "__ ";
        }
    }
}
