using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBasuraController : MonoBehaviour
{
    public List<BasuraController> basurasGeneradas =new List<BasuraController>();
    [SerializeField] BasuraController[] basurasPrefabs;
    [SerializeField]int quantity;
    [SerializeField] GameController[] spawnPositionBasura;
    int posX,posY, randomBasura,randomPositionBasura;
    BasuraController sabeBasura;
    Vector2 positiotmp;

    void Start()
    {
        for (int i = 0; i < quantity; i++)
        {
            posX= Random.Range(-5,5);
            posY= Random.Range(-5,5);
            randomPositionBasura= Random.Range(0,spawnPositionBasura.Length);
            randomBasura = Random.Range(0,basurasPrefabs.Length);

            positiotmp = new Vector2(spawnPositionBasura[randomPositionBasura].transform.position.x+posX,
            spawnPositionBasura[randomPositionBasura].transform.position.y+posY);

            sabeBasura = Instantiate(basurasPrefabs[randomBasura],positiotmp,Quaternion.identity);
            basurasGeneradas.Add(sabeBasura);
        }
    }
    void Update()
    {
        
    }
    
}
