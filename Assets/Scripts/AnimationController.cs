using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private int A;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    animator.SetBool("Mode", !animator.GetBool("Mode"));
        //}
        //if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        //{
        //    animator.SetBool("Move", true);
        //}
        //else
        //{
        //    animator.SetBool("Move", false);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    animator.SetTrigger("Motion");
        //}
    }

    public void PlayBoolAnim(string animName)
    {
        animator.SetBool(animName, !animator.GetBool(animName));
    }

    public void PlayBoolAnim(string animName, bool animValue)
    {
        animator.SetBool(animName, animValue);
    }

    public void PlayTriggerAnim(string animName)
    {
        animator.SetTrigger(animName);
    }
}
