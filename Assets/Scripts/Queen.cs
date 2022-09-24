using System;
using UnityEngine;
using UnityEngine.UI;

public class Queen : BeeBase
{

    [SerializeField] private Button nextShiftButton;
    protected override float CostPerShift => 2.15f;

    private const float EGGS_PER_SHIFT = 0.25f;
    private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

    public float Eggs { get; private set; }

    public float UnassignedWorkers { get; private set; }

    [SerializeField] private BeeBase[] workers;

    public event Action OnNewShift;

    

    private void Awake()
    {
        nextShiftButton.onClick.AddListener(DoJob);
    }

    protected override void DoJob()
    {
     float[] beeAmounts =
    {
        BeeCountManager.HoneyManufacturerBeeCount, 
        BeeCountManager.EggCareBeeCount,
        BeeCountManager.NectarCollectorBeeCount
    };
     if (BeeCountManager._totalNumOfBees > 0)
     {
         Eggs += EGGS_PER_SHIFT;
         var honeyToFeedToUnassignedWorkers = UnassignedWorkers * HONEY_PER_UNASSIGNED_WORKER;
         HoneyVault.ConsumeHoney(honeyToFeedToUnassignedWorkers);

         WorkTheBees(workers, beeAmounts);
        
         OnNewShift?.Invoke();
     }
    }

    public void CareForEggs(float eggsToConvert)
    {
        if (Eggs >= eggsToConvert)
        {
            Eggs -= eggsToConvert;
            UnassignedWorkers += eggsToConvert;
        }
    }

    private void WorkTheBees(BeeBase[] worker, float[] amount)
    {
        for (int i = 0; i < worker.Length; i++)
        {
            for (int j = 0; j < amount[i]; j++)
            {
                worker[i].WorkNextShift();
            }
        }
    }

    public void RemoveUnassignedWorker()
    {
        UnassignedWorkers--;
    }

    public void AddUnassignedWorker()
    {
        UnassignedWorkers++;
    }
}
