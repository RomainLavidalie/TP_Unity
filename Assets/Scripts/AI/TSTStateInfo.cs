using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Les infos passées au state pour le jeu FrozenBattle
public class TSTStateInfo : FSMStateInfo
{
    public IG1EnemyController Controller;
    public Vector3 LastPlayerPosition;
    public Vector3 LastPlayerVelocity;
    public float LastPlayerPerceivedTime;
    public bool CanSeeTarget;
    public bool CanHearTarget;
    public float PcentLife;
}