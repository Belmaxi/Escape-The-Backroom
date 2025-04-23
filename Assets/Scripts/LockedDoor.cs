using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockedDoor : MonoBehaviour
{
    /// <summary>
    /// 悬停进入
    /// </summary>
    /// <param name="args"></param>
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        print("123123123123");
    }

    /// <summary>
    /// 选择进入
    /// </summary>
    /// <param name="args"></param>
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        print("456456456456");
    }
}
