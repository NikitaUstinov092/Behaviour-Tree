using System;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class Barn : MonoBehaviour
{
    public event Action<bool> OnResourceAmountChanged;
        
    [SerializeField]
    private int resourceCapacity = 50; 
        
    [ShowInInspector, ReadOnly]
    private int resourceAmount;

    [Button]
    public void AddResources(int range)
    {
        if (this.CanAddResources(range))
        {
            this.resourceAmount += range;
            OnResourceAmountChanged?.Invoke(IsFull());
        }
    }

    public bool CanAddResources(int range)
    {
        return this.resourceAmount + range <= this.resourceCapacity;
    }

    public bool IsFull()
    {
        return this.resourceAmount >= this.resourceCapacity;
    }

    [Button]
    public void Clear()
    {
        this.resourceAmount = 0;
    }
}