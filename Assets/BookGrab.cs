using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookGrab : MonoBehaviour
{
    // Start is called before the first frame update
    public string showText = string.Empty;
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartUse());
        grabInteractable.deactivated.AddListener(s => StopUse());
    }

    public void StartUse()
    {
        UIManager.Instance.GenerateFloatingText(transform.position, showText);
    }

    public void StopUse()
    {
        Debug.Log("πÿ±’¡À");
    }
}
