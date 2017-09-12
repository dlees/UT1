using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RangeValue : MonoBehaviour {
    public string identifier;
    public float min;
    public float max;
    public float startingValue;
    public RangeValueListener[] listeners;

    private float cur;

    public float current {
        get { 
            return cur; 
        }
        set {
            this.cur = value;
            currentUpdated(this.cur);
        }
    }

    void Start() {
        current = startingValue;

    }

    private void currentUpdated(float cur) {
        verifyCurIsInRange();
        updateListeners();                
    }

    public float getRange() {
        return max - min;
    }

    public float getCurrentInNewRange(float new_min, float new_max) {
        return new_min + (new_max - new_min) / (max - min) * (cur - min);
    }

    private void verifyCurIsInRange() {
        if (cur > max) {
            cur = max;
        }
        else if (cur < min) {
            cur = min;
        }
    }

    private void updateListeners() {
        foreach (var listener in listeners) {
            listener.updateValue(this);
        }
    }
}
