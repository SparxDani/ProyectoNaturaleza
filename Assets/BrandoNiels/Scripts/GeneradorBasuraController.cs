using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBasuraController : MonoBehaviour
{
    public List<BasuraController> basurasGeneradas =new List<BasuraController>();
    [SerializeField] BasuraController[] basurasPrefabs;
    [SerializeField]int quantity;
    void Start()
    {
        for (int i = 0; i < quantity; i++)
        {
            
        }
    }
    void Update()
    {
        
    }
}
