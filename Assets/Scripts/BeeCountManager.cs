using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeCountManager : MonoBehaviour
{
    [SerializeField] private List<Button> addButtons;
    [SerializeField] private List<Button> removeButtons;
    
    
    public static float HoneyManufacturerBeeCount = 1f;
    public static float EggCareBeeCount = 1f;
    public static float NectarCollectorBeeCount = 1f;

    private Queen _queen;

    public event Action OnWorkerChange;


    private void Start()
    {
        DelegateButtons();
        _queen = FindObjectOfType<Queen>();

    }

    private void AddBee(int buttonIndex)
    {
        if (_queen.UnassignedWorkers >= 1)
        {
            switch (buttonIndex)
            {
                case 0:
                    HoneyManufacturerBeeCount++;
                    break;
                case 1:
                    EggCareBeeCount++;
                    break;
                case 2:
                    NectarCollectorBeeCount++;
                    break;
            }
            _queen.RemoveUnassignedWorker();
            OnWorkerChange?.Invoke();
        }
        
    }

    private void RemoveBee(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 0:
                HoneyManufacturerBeeCount = HandleRemoveBee(HoneyManufacturerBeeCount);
                break;
            case 1:
                EggCareBeeCount = HandleRemoveBee(EggCareBeeCount);
                break;
            case 2:
                NectarCollectorBeeCount = HandleRemoveBee(NectarCollectorBeeCount);
                break;
        }
        OnWorkerChange?.Invoke();
    }

    private void DelegateButtons()
    {
        for (int i = 0; i < addButtons.Count; i++)
        {
            var i1 = i;
            addButtons[i].onClick.AddListener(delegate { AddBee(i1); });
        }

        for (int i = 0; i < removeButtons.Count; i++)
        {
            var i1 = i;
            removeButtons[i].onClick.AddListener(delegate { RemoveBee(i1); });
        }
    }

    private float HandleRemoveBee(float beeCount)
    {
        if (beeCount > 0)
        {
            beeCount--;
            _queen.AddUnassignedWorker();
        }

        return beeCount;
    }
}
