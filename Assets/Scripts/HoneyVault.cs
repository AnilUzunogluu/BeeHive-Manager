using UnityEngine;

public static class HoneyVault
{
    private static float honey = 25f;
    private static float nectar = 100f;

    
    private const float NECTAR_CONVERSION_RATIO = 0.19f;
    private const float LOW_LEVEL_WARNING = 10F;

    public static void CollectNectar(float amount)
    {
        if (amount > 0)
        {
            nectar += amount;
        }
    }
    public static void ConvertNectarToHoney(float amount)
    {
        if (amount > nectar)
        {
            amount = nectar;
        }
        nectar -= amount;
        var nectarConvertedToHoney = amount * NECTAR_CONVERSION_RATIO;
        honey += nectarConvertedToHoney;
    }

    public static bool ConsumeHoney(float amount)
    {
        if (honey >= amount)
        {
            honey -= amount;
            return true;
        }

        return false;
    }
}
