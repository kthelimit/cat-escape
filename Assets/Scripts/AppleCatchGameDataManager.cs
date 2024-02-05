using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCatchGameDataManager : MonoBehaviour
{
    public static AppleCatchGameDataManager gameDataManager;
    public float score=0;
    public int appleCount=0;
    public int bombCount=0;
    public float appleScore = 100f;
    public float leftTimeMax = 60f;
    public float bombPenalty = 0.5f;

    void Awake()
    {
        if(gameDataManager == null )
        {
            gameDataManager = this;
            DontDestroyOnLoad(this);

        }
        else
        {
            Destroy(gameObject);
        }
    }


}
