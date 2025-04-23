using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class BubbleManager : MonoBehaviour
{
    public List<Bubble> bubbles = new List<Bubble>();
    public Text counterText;
    public int answer = 3;

    private List<int> bubbleList = new List<int>();

    private void Start()
    {
        // Find all Bubble components in the scene and add them to the list
        for(int i = 0; i < bubbles.Count; i++)
        {
            Bubble bubble = bubbles[i];
            bubbleList.Add(bubble.hideNumValue);
            int j = i;
            bubble.gameObject.GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => SelectBubbleStart(j));
            bubble.gameObject.GetComponent<XRSimpleInteractable>().selectExited.AddListener(x => SelectBubbleEnd());
            bubble.gameObject.GetComponent<XRSimpleInteractable>().activated.AddListener(x => ActivateBubble());
            bubble.hideNum.gameObject.SetActive(false);
        }
    }
    private int currentBubbleID = 0;
    private void SelectBubbleStart(int bubbleID)
    {
        print("Enter");
        currentBubbleID = bubbleID;
        bubbles[bubbleID].hideNum.gameObject.SetActive(true);
        if(bubbleID+ 1 < bubbles.Count)
        {
            bubbles[bubbleID + 1].hideNum.gameObject.SetActive(true);
        }
        for(int i =0; i < bubbles.Count; i++)
        {
            if (i != bubbleID)
            {
                bubbles[i].gameObject.GetComponent<XRSimpleInteractable>().enabled = false;
            }
        }
    }

    private void SelectBubbleEnd()
    {
        print("Exit");
        for (int i = 0; i < bubbles.Count; i++)
        {
            if (i != currentBubbleID)
            {
                bubbles[i].gameObject.GetComponent<XRSimpleInteractable>().enabled = true;
            }
        }
        bubbles[currentBubbleID].hideNum.gameObject.SetActive(false);
        if (currentBubbleID + 1 < bubbles.Count)
        {
            bubbles[currentBubbleID + 1].hideNum.gameObject.SetActive(false);
        }

        if (CheckBubbles())
        {
            if(counterText.text == answer.ToString())
            {
                print("Success!");
                counterText.color = Color.green;
                for (int i = 0; i < bubbles.Count; i++)
                {
                    bubbles[i].hideNum.gameObject.SetActive(true);
                }
                for (int i = 0; i < bubbles.Count; i++)
                {
                    bubbles[i].gameObject.GetComponent<XRSimpleInteractable>().enabled = false;
                }
            }
            else
            {
                counterText.text = "0";
                for(int i = 0; i < bubbles.Count; i++)
                {
                    bubbles[i].hideNumValue = bubbleList[i];
                    bubbles[i].hideNum.text = bubbleList[i].ToString();
                    bubbles[i].hideNum.gameObject.SetActive(false);
                }
            }
        }
    }

    //判断是否有序
    private bool CheckBubbles()
    {
        for (int i = 0; i < bubbles.Count - 1; i++)
        {
            if (bubbles[i].hideNumValue > bubbles[i + 1].hideNumValue)
            {
                return false;
            }
        }
        return true;
    }

    private void ActivateBubble()
    {
        print("Activate");
        if(currentBubbleID + 1 < bubbles.Count)
        {
            //交换相邻两个气泡的值
            int temp = bubbles[currentBubbleID].hideNumValue;
            bubbles[currentBubbleID].hideNumValue = bubbles[currentBubbleID + 1].hideNumValue;
            bubbles[currentBubbleID + 1].hideNumValue = temp;
            bubbles[currentBubbleID].hideNum.text = bubbles[currentBubbleID].hideNumValue.ToString();
            bubbles[currentBubbleID + 1].hideNum.text = bubbles[currentBubbleID + 1].hideNumValue.ToString();
            counterText.text = ((int.Parse(counterText.text) + 1) % 10).ToString();
        }
    }
}
