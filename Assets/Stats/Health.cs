using UnityEngine;
using System.Collections;

public class Health : Stat
{
    public float max
    {
        get;
        set;
    }

    public float regenValue;

    public Health(float n)
        : base (n)
    {
        this.max = n;
    }

    // Increase Health by regenValue as a percentage of max Health
    public void regen()
    {
        this.add((max / 100) * regenValue);
    }

    public void increaseMax(float n)
    {
        this.max += n;
    }

    public void reduceMax(float n)
    {
        this.max -= n;
    }
}
