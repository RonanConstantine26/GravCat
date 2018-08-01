using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsScript : MonoBehaviour {

    public Animator anim;
    public Character charScript;

	// Use this for initialization
	void Start () {
        //charScript = gameObject.GetComponent<Character>();
	}

    // Update is called once per frame
    void Update()
    {
        if (charScript.isDead)
        {
           // anim.SetTrigger("is dead");
            anim.SetBool("DEAD", true);
            anim.SetBool("is Charging", false);
            anim.SetBool("is Idle", false);
            anim.SetBool("is Walking", false);
            anim.SetBool("is Jumping", false);
            anim.SetBool("is Falling", false);
        }

        else if (charScript.isCharging)
        {
            anim.SetBool("is Charging", true);
            anim.SetBool("is Idle", false);
            anim.SetBool("is Walking", false);
            anim.SetBool("is Jumping", false);
            anim.SetBool("is Falling", false);
        }
        else if (charScript.isJumping)
        {
            anim.SetBool("is Jumping", true);
            anim.SetBool("is Walking", false);
            anim.SetBool("is Idle", false);
            anim.SetBool("is Charging", false);
            anim.SetBool("is Falling", false);
        }
        else if (charScript.isFalling)
        {
            anim.SetBool("is Falling", true);
            anim.SetBool("is Jumping", false);
            anim.SetBool("is Walking", false);
            anim.SetBool("is Idle", false);
            anim.SetBool("is Charging", false);
        }
        else if (charScript.isIdle)
        {
            anim.SetBool("is Idle", true);
            anim.SetBool("is Walking", false);
            anim.SetBool("is Charging", false);
            anim.SetBool("is Jumping", false);
            anim.SetBool("is Falling", false);
        }

        else if (charScript.isRunningLeft || charScript.isRunningRight)
        {
            anim.SetBool("is Walking", true);
            anim.SetBool("is Idle", false);
            anim.SetBool("is Charging", false);
            anim.SetBool("is Jumping", false);
            anim.SetBool("is Falling", false);
        }

        

        
    }
}
