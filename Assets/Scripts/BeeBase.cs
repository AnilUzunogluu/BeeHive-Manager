using UnityEngine;

public class BeeBase : MonoBehaviour
{
    protected virtual float CostPerShift { get; }

    private GameManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    public void WorkNextShift()
    {
        if (HoneyVault.ConsumeHoney(CostPerShift))
        {
            DoJob();
        }
        else
        {
            _manager.SetEndGame(false);
        }
    }

    protected virtual void DoJob()
    {
        //Subclass overrides this.
    }
}
