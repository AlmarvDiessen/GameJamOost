using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : MonoBehaviour, IDeseaseAble
{

    //base class for your effect.
    //you should deprive your effect off this class and make the effect in your new class.

    // Update is called once per frame
    public Disease() {

    }

    public void Update() {
        ApplyEffect();
    }


    public virtual void ApplyEffect() {

    }
}
