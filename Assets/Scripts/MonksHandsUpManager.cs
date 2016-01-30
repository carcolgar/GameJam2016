using UnityEngine;
using System.Collections;

public class MonksHandsUpManager : MonoBehaviour {
    [SerializeField]
    private float minimunTimeBetweenMonksRiseArms;
    
    [SerializeField, RangeAttribute(0, 100)]
    private float monksRiseArmsProbability;
    
    [SerializeField]
    private float timeMonksHoldHandsUp;
    
    [SerializeField]
    private MonkHandsUp[] monks;
    
    private float timeSinceLastHandsUp;
    private float accumulatedTimeHundsUp;
    private bool monksAreRisingArms;
    private bool playerRisedArms;
    
	// Use this for initialization
	void Start () {
	   timeSinceLastHandsUp = 0;
       accumulatedTimeHundsUp = 0;
       monksAreRisingArms = false;
       playerRisedArms = false;
	}
	
	// Update is called once per frame
	void Update () {
	   if (!monksAreRisingArms && timeSinceLastHandsUp < minimunTimeBetweenMonksRiseArms) {
           timeSinceLastHandsUp += Time.deltaTime;
       } else {
           if (!monksAreRisingArms) {
               monksAreRisingArms = true;
               timeSinceLastHandsUp = 0;
               StartCoroutine(MonksHandsUp());
           }
       }
	}
    
    private IEnumerator MonksHandsUp () {
        accumulatedTimeHundsUp = 0;
        playerRisedArms = false;
        foreach (MonkHandsUp monkHandsUp in monks) {
            monkHandsUp.HandsUp();
        }
        while (!GameManager.SINGLETON.Player.HasHandsUp && accumulatedTimeHundsUp < timeMonksHoldHandsUp) {
            accumulatedTimeHundsUp += Time.deltaTime;
            yield return 0;
        }
        if (!GameManager.SINGLETON.Player.HasHandsUp) {
            GameManager.SINGLETON.DecreaseLife();
        }
        foreach (MonkHandsUp monkHandsUp in monks) {
            monkHandsUp.HandsDown();
        }
    }
}
