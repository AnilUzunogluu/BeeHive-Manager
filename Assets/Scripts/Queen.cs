using UnityEngine;

public class Queen : BeeBase
{

    public Queen() : base("Queen")
    {
    }
    protected override float CostPerShift => 2.15f;
    
    public const float EGGS_PER_SHIFT = 0.45f;
    public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

    private float eggs;
    private float unassignedWorkers;

    [SerializeField] private BeeBase[] workers;

    private float[] beeAmounts =
    {
        BeeCountManager.HoneyManufacturerBeeCount, 
        BeeCountManager.EggCareBeeCount,
        BeeCountManager.NectarCollectorBeeCount
    };



    protected override void DoJob()
    {
        eggs += EGGS_PER_SHIFT;
        var honeyToFeedToUnassignedWorkers = unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER;
        
        WorkTheBees(workers, beeAmounts);
        
        HoneyVault.ConsumeHoney(honeyToFeedToUnassignedWorkers);
    }

    public void CareForEggs(float eggsToConvert)
    {
        if (eggs >= eggsToConvert)
        {
            eggs -= eggsToConvert;
            unassignedWorkers += eggsToConvert;
        }
    }

    private void WorkTheBees(BeeBase[] workers, float[] amount)
    {
        for (int i = 0; i < workers.Length; i++)
        {
            for (int j = 0; j < amount[i]; j++)
            {
                workers[i].WorkNextShift();
            }
        }
    }
}
