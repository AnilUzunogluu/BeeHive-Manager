public class HoneyManufacturer : BeeBase
{
    protected override float CostPerShift => 1.7f;

    private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

    protected override void DoJob()
    {
        HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
    }
}
