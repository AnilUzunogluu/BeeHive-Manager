public class EggCare : BeeBase
{
    private Queen _queen;

    private void Start()
    {
        _queen = FindObjectOfType<Queen>();
    }

    protected override float CostPerShift => 1.35f;

    private const float CARE_PROGRESS_PER_SHIFT = 0.10f;

    protected override void DoJob()
    {
        _queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
    }
}
