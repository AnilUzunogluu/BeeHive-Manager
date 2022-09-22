using UnityEngine;

public class BeeBase : MonoBehaviour
{
    protected virtual float CostPerShift { get; }
    public string Job { get; private set; }
    public BeeBase(string job)
    {
        Job = job;
    }

    public void WorkNextShift()
    {
        if (HoneyVault.ConsumeHoney(CostPerShift))
        {
            DoJob();
        }
    }

    protected virtual void DoJob()
    {
        //Subclass overrides this.
    }
}
