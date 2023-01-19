using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIK : MonoBehaviour
{

    public Animator animator;
    public MovePerson movePerson;
    public CharacterInventory characterInventory;
    public CharacterStatus characterStatus;
    public Transform targetLook;
    public Transform l_Hand;
    public Transform l_Hand_Target;
    public Transform r_Hand;
    public Quaternion lh_rot;
    public float rh_Weight;
    public Transform shoulder;
    public Transform aimPivot;

    void Start()
    {
        shoulder = animator.GetBoneTransform(HumanBodyBones.RightShoulder).transform;

        aimPivot = new GameObject().transform;
        aimPivot.name = "aim pivot";
        aimPivot.transform.parent = transform;

        r_Hand = new GameObject().transform;
        r_Hand.name = "right hand";
        r_Hand.transform.parent = aimPivot;

        l_Hand = new GameObject().transform;
        l_Hand.name = "left hand";
        l_Hand.transform.parent = aimPivot;

        r_Hand.localPosition = characterInventory.firstWeapon.rHandPos;
        Quaternion rotRight = Quaternion.Euler(characterInventory.firstWeapon.rHandRot.x, characterInventory.firstWeapon.rHandRot.y, characterInventory.firstWeapon.rHandRot.z);
        r_Hand.localRotation = rotRight;
    }

    void Update()
    {
        lh_rot = l_Hand_Target.rotation;
        l_Hand.position = l_Hand_Target.position;
        
    }

    void OnAnimatorIK()
    {
        aimPivot.position = shoulder.position;

        if(characterStatus.isAiming)
        {
            aimPivot.LookAt(targetLook);
            animator.SetLookAtWeight(.3f, .6f, .3f);
            animator.SetLookAtPosition(targetLook.position);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, l_Hand.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, lh_rot);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rh_Weight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rh_Weight);
            animator.SetIKPosition(AvatarIKGoal.RightHand, r_Hand.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, r_Hand.rotation);
        }
        else
        {
            animator.SetLookAtWeight(.5f, .5f, .5f);
            animator.SetLookAtPosition(targetLook.position);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKPosition(AvatarIKGoal.LeftHand, l_Hand.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, lh_rot);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rh_Weight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rh_Weight);
            animator.SetIKPosition(AvatarIKGoal.RightHand, r_Hand.position);
            animator.SetIKRotation(AvatarIKGoal.RightHand, r_Hand.rotation);
        }
    }
}
