using UnityEngine;

public class EggCare : BeeBase
{
    private Queen queen;
    public EggCare() : base("EggCare")
    {
    }

    private void Start()
    {
        queen = FindObjectOfType<Queen>();
    }

    protected override float CostPerShift => 1.35f;

    private const float CARE_PROGRESS_PER_SHIFT = 0.15f;

    protected override void DoJob()
    {
        queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        Debug.Log("EC DID ITS JOB");

    }
}
