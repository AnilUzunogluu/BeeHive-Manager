public class EggCare : BeeBase
{
    private Queen queen;
    public EggCare(Queen queen) : base("EggCare")
    {
        this.queen = queen;
    }

    protected override float CostPerShift => 1.35f;

    private const float CARE_PROGRESS_PER_SHIFT = 0.15f;

    protected override void DoJob()
    {
        queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
    }
}
