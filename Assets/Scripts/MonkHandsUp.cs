using UnityEngine;
using System.Collections;

public class MonkHandsUp : MonoBehaviour {
    [SerializeField]
    private Animator monkAnimator;
    
    public void HandsUp () {
        monkAnimator.Play("MonkRiseArms");
    }
    
    public void HandsDown () {
        monkAnimator.Play("MonkDownArms");
        //StartCoroutine(WaitForIdle());
    }
    
    private IEnumerator WaitForIdle () {
        yield return new WaitForSeconds(0.25f);
        monkAnimator.Play("MonkIdle");
    }
}
