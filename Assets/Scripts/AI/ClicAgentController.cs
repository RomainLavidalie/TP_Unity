using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClicAgentController : AgentController
{
    private Ray rayPickPos; //Déclaré ici pour pouvoir le visualiser, il doit rester accessible entre deux clics

    protected void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            rayPickPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Physics.Raycast(rayPickPos, out rh))
            {
                FindPathTo(rh.point);
            }
        }
    }

    public new void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(rayPickPos.origin, rayPickPos.direction * 100);         
    }
}