using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSTSAgressif : FSMState<TSTStateInfo>
{
    float closeToTargetDistance = 4;
    public override void doState(ref TSTStateInfo infos)
    {
        bool closeToTarget = (infos.LastPlayerPosition - infos.Controller.transform.position).sqrMagnitude < closeToTargetDistance * closeToTargetDistance;
        if (closeToTarget)
            addAndActivateSubState<TSTSAttaque>();
        else
            addAndActivateSubState<TSTSPoursuite>();
    }
}