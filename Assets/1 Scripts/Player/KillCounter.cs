using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter
{
    public int Kills {
        get {
            return _kills;
        }
        set {
            _kills = value;
            int p = CheckThresholdsPassed(_kills);
            if (p > 0) OnThresholdsPassed?.Invoke(p);
        }
        }
    public int ThresholdsPassed { get; private set; }
    public event Action<int> OnThresholdsPassed;

    private int _kills;
    private int[] _thresholds =
    {
        10, 25, 50, 100
    };

    private int lastThreshold = 0;

    private int CheckThresholdsPassed(int val)
    {
        int count = 0;
        for (int i = 0; i < _thresholds.Length; i++)
        {
            if (val >= _thresholds[i]) count++;
        }
        if (count > lastThreshold)
        {
            lastThreshold = count;
            return count;
        }
        else return 0;
    }
}
