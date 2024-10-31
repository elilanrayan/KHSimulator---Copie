using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    [SerializeField] private int numberGold = 0;


    public int Gold
    {
        get { return numberGold; }
        set { numberGold = value; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
