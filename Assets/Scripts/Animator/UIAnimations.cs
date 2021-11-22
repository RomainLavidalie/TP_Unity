using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    public Animator Papate;

    private readonly int SearchingHash = Animator.StringToHash("Searching");
    private readonly int WalkingHash = Animator.StringToHash("Walking");
    private readonly int RunningHash = Animator.StringToHash("Running");
    private readonly int DanceHash = Animator.StringToHash("Dance");
    private readonly int KillHash = Animator.StringToHash("Kill");
    private readonly int RessurectHash = Animator.StringToHash("Ressurect");
    private readonly int JumpHash = Animator.StringToHash("Jump");
    private readonly int HookPunchHash = Animator.StringToHash("Hook Punch");
    private readonly int StraightPunchHash = Animator.StringToHash("Straight Punch");
    private readonly int PunchFlurryHash = Animator.StringToHash("Punch Flurry");
    private readonly int GettingHitHash = Animator.StringToHash("Getting Hit");
    private readonly int ThrowingHash = Animator.StringToHash("Throwing");

    public void Searching()
    {
        if (Papate.GetBool(SearchingHash))
            Papate.SetBool(SearchingHash, false);
        else
            Papate.SetBool(SearchingHash, true);
    }
    
    public void Walking()
    {
        if (Papate.GetBool(WalkingHash))
            Papate.SetBool(WalkingHash, false);
        else
            Papate.SetBool(WalkingHash, true);
    }
    
    public void Running()
    {
        if (Papate.GetBool(RunningHash))
            Papate.SetBool(RunningHash, false);
        else
            Papate.SetBool(RunningHash, true);
    }
    
    public void Dance()
    {
        if (Papate.GetBool(DanceHash))
            Papate.SetBool(DanceHash, false);
        else
            Papate.SetBool(DanceHash, true);
    }
    
    public void Kill()
    {
        if (Papate.GetBool(KillHash))
            Papate.SetBool(KillHash, false);
        else
            Papate.SetBool(KillHash, true);
    }
    
    public void Ressurect()
    {
        if (Papate.GetBool(RessurectHash))
            Papate.SetBool(RessurectHash, false);
        else
            Papate.SetBool(RessurectHash, true);
    }
    
    public void Jump()
    {
        if (Papate.GetBool(JumpHash))
            Papate.SetBool(JumpHash, false);
        else
            Papate.SetBool(JumpHash, true);
    }
    
    public void HookPunch()
    {
        if (Papate.GetBool(HookPunchHash))
            Papate.SetBool(HookPunchHash, false);
        else
            Papate.SetBool(HookPunchHash, true);
    }
    
    public void StraightPunch()
    {
        if (Papate.GetBool(StraightPunchHash))
            Papate.SetBool(StraightPunchHash, false);
        else
            Papate.SetBool(StraightPunchHash, true);
    }
    
    public void PunchFlurry()
    {
        if (Papate.GetBool(PunchFlurryHash))
            Papate.SetBool(PunchFlurryHash, false);
        else
            Papate.SetBool(PunchFlurryHash, true);
    }
    
    public void GettingHit()
    {
        if (Papate.GetBool(GettingHitHash))
            Papate.SetBool(GettingHitHash, false);
        else
            Papate.SetBool(GettingHitHash, true);
    }
    
    public void Throwing()
    {
        if (Papate.GetBool(ThrowingHash))
            Papate.SetBool(ThrowingHash, false);
        else
            Papate.SetBool(ThrowingHash, true);
    }
    
    
}