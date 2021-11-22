public class TSTSAgressif : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        if (infos.CloseToTarget)
            addAndActivateSubState<TSTSAttaque>();
        else
        {
            addAndActivateSubState<TSTSPoursuite>();
            infos.Controller.StopAttack();
        }
            
    }
}