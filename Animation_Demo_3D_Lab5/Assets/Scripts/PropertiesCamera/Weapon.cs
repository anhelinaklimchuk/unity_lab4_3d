using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/properties")]

public class Weapon : ScriptableObject
{
    public Vector3 rHandPos;
    public Vector3 rHandRot;

    public GameObject weaponPrefab;
}
