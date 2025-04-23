using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour
{
    private static GameDriver instance;
    public static GameDriver Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameDriver>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameDriver");
                    instance = obj.AddComponent<GameDriver>();
                }
            }
            return instance;
        }
    }

    public GameObject player;
}
