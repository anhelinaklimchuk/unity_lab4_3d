using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public MovePerson movePerson;
    public CharacterAnimation characterAnimation;
    public CharacterInput characterInput;

    public void Update()
    {
        movePerson.MoveUpdate();
        characterAnimation.UpdateAnimation();
        characterInput.InputUpdate();
    }
}
