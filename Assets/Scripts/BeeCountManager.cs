using System;
using UnityEngine;
using UnityEngine.UI;

public class BeeCountManager : MonoBehaviour
{
    [SerializeField] private Button[] addButtons;
    [SerializeField] private Button[] removeButtons;
    
    
    public static float HoneyManufacturerBeeCount = 1f;
    public static float EggCareBeeCount = 1f;
    public static float NectarCollectorBeeCount = 1f;


    private void Start()
    {
        DelegateAddButtons();

    }

    // public void AddHMBee()
    // {
    //     HoneyManufacturerBeeCount++;
    //     Debug.Log("hmBees " + HoneyManufacturerBeeCount);
    // }
    // public void AddECBee()
    // {
    //     EggCareBeeCount++;
    //     Debug.Log("ecBees " + EggCareBeeCount);
    //
    // }
    // public void AddNCBee()
    // {
    //     NectarCollectorBeeCount++;
    //     Debug.Log("ncBees " + NectarCollectorBeeCount);
    //
    // }

    public void AddBee(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 0:
                HoneyManufacturerBeeCount++;
                Debug.Log("hmBees " + HoneyManufacturerBeeCount);
                break;
            case 1:
                EggCareBeeCount++;
                Debug.Log("ecBees " + EggCareBeeCount);
                break;
            case 2:
                NectarCollectorBeeCount++;
                Debug.Log("ncBees " + NectarCollectorBeeCount);
                break;
        }
    }

    public void RemoveHMBee()
    {
        HoneyManufacturerBeeCount--;
        Debug.Log("hmBees " + HoneyManufacturerBeeCount);

    }
    public void RemoveECBee()
    {
        EggCareBeeCount--;
        Debug.Log("ecBees " + EggCareBeeCount);

    }
    public void RemoveNCBee()
    {
        NectarCollectorBeeCount--;
        Debug.Log("ncBees " + NectarCollectorBeeCount);

    }

    private void DelegateAddButtons()
    {
        for (int i = 0; i < addButtons.Length; i++)
        {
            var i1 = i;
            addButtons[i].onClick.AddListener(delegate { AddBee(i1); });
        }
    }
}
