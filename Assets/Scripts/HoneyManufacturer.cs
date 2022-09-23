using UnityEngine;

public class HoneyManufacturer : BeeBase
{
    public HoneyManufacturer() : base("HoneyManufacturer")
    {
    }
    
    protected override float CostPerShift => 1.7f;

    private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

    protected override void DoJob()
    {
        HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        Debug.Log("HM DID ITS JOB");
    }
}
