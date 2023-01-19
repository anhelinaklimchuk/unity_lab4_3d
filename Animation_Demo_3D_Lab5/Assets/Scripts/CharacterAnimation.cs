using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
   public Animator animator;
    public MovePerson movePerson;
    public CharacterStatus characterStatus;
    
    public void UpdateAnimation()
    {
        animator.SetBool("sprint", characterStatus.isSprint);
        animator.SetBool("aiming", characterStatus.isAiming);

        if(!characterStatus.isAiming)
        {
            AnimationNormal();
        }
        else
        {
            AnimationAiming();
        }
    }

    void AnimationNormal()
    {
        if (movePerson.moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        if (movePerson.moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {   
            Run();            
        }
        else if (movePerson.moveDirection == Vector3.zero)
        {
            Idle();
        }
    }

    void AnimationAiming()
    {
        float ver = movePerson.vertical;
        float hor = movePerson.horizontal;

        if (movePerson.moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("vertical", ver, 0.1f, Time.deltaTime);
            animator.SetFloat("horizontal", hor, 0.1f, Time.deltaTime);
            Walk();
        }
        else if (movePerson.moveDirection == Vector3.zero)
        {
            animator.SetFloat("vertical", ver, 0.1f, Time.deltaTime);
            animator.SetFloat("horizontal", hor, 0.1f, Time.deltaTime);
            Idle();
        }
    }

    private void Idle()
    {
        animator.SetFloat("vertical", 0f, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        movePerson.moveAmount = 5;
        animator.SetFloat("vertical", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        movePerson.moveAmount = 10;
        animator.SetFloat("vertical", 1, 0.1f, Time.deltaTime);
    }

}
