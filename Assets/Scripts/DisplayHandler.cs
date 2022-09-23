using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{
    [Header("Working Bees")]
    [SerializeField] private TextMeshProUGUI hmBeeText;
    [SerializeField] private TextMeshProUGUI ecBeeText;
    [SerializeField] private TextMeshProUGUI ncBeeText;
    
    [Header("Status Display")]
    [SerializeField] private TextMeshProUGUI honeyAndNectarText;
    [SerializeField] private TextMeshProUGUI eggsAndWorkersText;

    private Queen _queen;
    private BeeCountManager _countManager;
    void Start()
    {
        _queen = FindObjectOfType<Queen>();
        _countManager = FindObjectOfType<BeeCountManager>();
        
        SetFullDisplay();
        
        _countManager.OnWorkerChange += SetFullDisplay;
        _queen.OnNewShift += SetFullDisplay;
    }

    private void UpdateWorkingBeesDisplay()
    {
        hmBeeText.text = $"Honey Manufacturer\n Bees: {BeeCountManager.HoneyManufacturerBeeCount}";
        ecBeeText.text = $"Egg Care\n Bees: {BeeCountManager.EggCareBeeCount}";
        ncBeeText.text = $"Nectar Manufacturer\n Bees: {BeeCountManager.NectarCollectorBeeCount}";
    }

    private void UpdateEggsAndWorkers()
    {
        eggsAndWorkersText.text = $"Eggs: {(int)_queen.Eggs}" +
                                  $"\nUnassigned Workers: {(int)_queen.UnassignedWorkers}";
    }

    private void UpdateHoneyAndNectar()
    {
        honeyAndNectarText.text = "Honey: " + HoneyVault.Honey.ToString("F2")+
                                  $"\nNectar:" + HoneyVault.Nectar.ToString("F2");

        if (HoneyVault.CheckHoneyWarning())
        {
            honeyAndNectarText.text += $"\nLow honey!";
        }
        if (HoneyVault.CheckNectarWarning())
        {
            honeyAndNectarText.text += $"\nLow Nectar!";
        }
    }

    private void SetFullDisplay()
    {
        UpdateWorkingBeesDisplay();
        UpdateHoneyAndNectar();
        UpdateEggsAndWorkers();
    }
}
