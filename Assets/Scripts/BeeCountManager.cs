using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeCountManager : MonoBehaviour
{
    [SerializeField] private List<Button> addButtons;
    [SerializeField] private List<Button> removeButtons;
    
    
    public static float HoneyManufacturerBeeCount;
    public static float EggCareBeeCount;
    public static float NectarCollectorBeeCount;

    public static float _totalNumOfBees;

    private Queen _queen;
    private GameManager _manager;

    public event Action OnWorkerChange;


    private void Awake()
    {
        HoneyManufacturerBeeCount = 1f;
        EggCareBeeCount = 1;
        NectarCollectorBeeCount = 1f;
    }

    private void Start()
    {
        DelegateButtons();
        CalcTotalNumOfBees();
        _queen = FindObjectOfType<Queen>();
        _manager = FindObjectOfType<GameManager>();

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
            CalcTotalNumOfBees();
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
        CalcTotalNumOfBees();
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

    private void CalcTotalNumOfBees()
    {
        _totalNumOfBees = HoneyManufacturerBeeCount + EggCareBeeCount + NectarCollectorBeeCount;

        if (_totalNumOfBees >= GameManager.WIN_CONDITION)
        {
            _manager.SetEndGame(true);
        }
    }
}
