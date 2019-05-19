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
            if (p > 0)
            {
                OnThresholdsPassed?.Invoke(p);
                OnThresholdPassed(p);
            }
        }
    }
    public int ThresholdsPassed { get; private set; }
    public event Action<int> OnThresholdsPassed;

    private int _kills;
    private int[] _thresholds =
    {
        30, 60, 250
    };

    private int lastThreshold = 0;

    private void OnThresholdPassed(int count)
    {
        switch (count)
        {
            case 1:
                Enemy.DamageScale = 1.5f;
                break;
            case 2:
                Enemy.DamageScale = 3f;
                break;
            case 3:
                Enemy.DamageScale = 5f;
                break;
            default:
                break;
        }
    }

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
