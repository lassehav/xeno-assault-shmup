using UnityEngine;
using System.Collections;

public class AnimatorKillWhenFinished : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Animator a = GetComponent<Animator>();
        AnimatorClipInfo[] ac = a.GetCurrentAnimatorClipInfo(0);
        // wait until the animation has finished and destroy
        Destroy(this.gameObject, ac[0].clip.length); 
    }
    


}
