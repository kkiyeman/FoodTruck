using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    

    void Start()
    {
        ChangeRed();

    }

    public void ChangeRed()
    {
        SimpleTruck simpleTruck = new SimpleTruck();

        simpleTruck.ChangeColorRed();
    }

}
