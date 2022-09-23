using System;

public static class HoneyVault
{
    public static float Honey { get; private set; } = 25f;
    public static float Nectar { get; private set; } = 100f;


    private const float NECTAR_CONVERSION_RATIO = 0.19f;
    private const float LOW_LEVEL_WARNING = 10F;

    public static void CollectNectar(float amount)
    {
        if (amount > 0)
        {
            Nectar += amount;
        }
    }
    public static void ConvertNectarToHoney(float amount)
    {
        if (amount > Nectar)
        {
            amount = Nectar;
        }
        Nectar -= amount;
        var nectarConvertedToHoney = amount * NECTAR_CONVERSION_RATIO;
        Honey += nectarConvertedToHoney;
    }

    public static bool ConsumeHoney(float amount)
    {
        if (Honey >= amount)
        {
            Honey -= amount;
            return true;
        }

        return false;
    }

    public static bool CheckHoneyWarning()
    {
        return Honey <= LOW_LEVEL_WARNING;
    }
    
    public static bool CheckNectarWarning()
    {
        return Nectar <= LOW_LEVEL_WARNING;
    }
}
