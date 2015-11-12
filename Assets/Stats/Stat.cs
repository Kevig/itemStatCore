using UnityEngine;
using System.Collections;

public class Stat
{

    public float value
    {
        get;
        set;
    }

    // Zerio Arg Constructor
    public Stat()
    {
        this.value = 0;
    }

    // Contructor
    public Stat(float n)
    {
        this.value = n;
    }

    // Increase by an amount
    public void add(float n)
    {
        this.value += n;
    }
	
    // Decrease by an amount
    public void sub(float n)
    {
        this.value -= n;
    }

    // Report current value to console display window
    public void toString()
    {
        
    }
}

