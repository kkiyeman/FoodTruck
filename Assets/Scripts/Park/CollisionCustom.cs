using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCustom : MonoBehaviour
{
    MakeManager makemanager;
    // Start is called before the first frame update
    void Start()
    {
        makemanager = FindObjectOfType<MakeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Customer")
        {
            makemanager.ServePizza();
        }

    }
}
