using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class IG1EnemyController : AgentController
{
    private float PcentLife = 100;
    private FSMachine<TSTSBase, TSTStateInfo> FSM = new FSMachine<TSTSBase, TSTStateInfo>();
    TSTStateInfo FSMInfos = new TSTStateInfo();
    public GameObject Hammer;
    public BoxCollider HammerCollider;

    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<AISenseSight>().AddSenseHandler(new AISense<SightStimulus>.SenseEventHandler(HandleSight));
        GetComponent<AISenseSight>().AddObjectToTrack(player);
        GetComponent<AISenseHearing>().AddSenseHandler(new AISense<HearingStimulus>.SenseEventHandler(HandleHearing));
        GetComponent<AISenseHearing>().AddObjectToTrack(player);
        Hammer = GameObject.Find("hammer");
        HammerCollider = Hammer.GetComponent<BoxCollider>();
    }

    void HandleSight(SightStimulus sti, AISense<SightStimulus>.Status evt)
    {
        FSMInfos.CanSeeTarget = evt == AISense<SightStimulus>.Status.Enter || evt == AISense<SightStimulus>.Status.Stay;

        if (evt == AISense<SightStimulus>.Status.Enter)
            Debug.Log("Objet " + evt + " vue en " + sti.position);

        if (evt != AISense<SightStimulus>.Status.Leave)
        {
            FSMInfos.LastPlayerPosition = sti.position;
            FSMInfos.LastPlayerVelocity = sti.velocity;
            FSMInfos.LastPlayerPerceivedTime = Time.time;
        }

    }

    void HandleHearing(HearingStimulus sti, AISense<HearingStimulus>.Status evt)
    {
        FSMInfos.CanHearTarget =
            evt == AISense<HearingStimulus>.Status.Enter || evt == AISense<HearingStimulus>.Status.Stay;

        if (evt == AISense<HearingStimulus>.Status.Enter)
            Debug.Log("Objet " + evt + " ouïe en " + sti.position);

        if (evt != AISense<HearingStimulus>.Status.Leave)
        {
            FSMInfos.LastPlayerPosition = sti.position;
            FSMInfos.LastPlayerPerceivedTime = Time.time;
        }
    }

    public void Attack()
    {
        Debug.Log("ATTACKING");
        Hammer.transform.localScale = Vector3.one;
        HammerCollider.enabled = true;
    }
    
    public void StopAttack()
    {
        Hammer.transform.localScale = Vector3.zero;
        HammerCollider.enabled = false;
    }

    void Update()
    {
        FSM.ShowDebug = this.ShowDebug;
        FSMInfos.Controller = this;
        FSMInfos.PcentLife = PcentLife;
        FSM.Update(FSMInfos);
        //if (Hammer.Contact = true)
    }
}