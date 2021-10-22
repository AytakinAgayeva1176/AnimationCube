using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;
    [SerializeField] private Transform tileSpawnPoint;
    [Range(0, 10)]
    [SerializeField] private int numberOfTiles;
    [SerializeField] private GameObject tilePrefeb;
    [SerializeField] private List<GameObject> tileArray = new List<GameObject>();
    private int currentCoinCount = 0;

    // [SerializeField] private ObstacleStateSO[] obstacleStateSOs;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tileInstance = Instantiate(tilePrefeb);
            tileInstance.name = tileArray.Count.ToString();
            if (tileArray.Count>0)
            {
                tileInstance.transform.position =
                    tileArray[tileArray.Count-1].GetComponent<TileController>()
                    .endPoint.position;

                tileInstance.transform.parent = tileArray[0].transform;
            }
            else
            {
                tileInstance.transform.position = tileSpawnPoint.position;

                tileInstance.GetComponent<TileController>().InvokeRepeating("MoveTile",0,0.01f);
            }

            tileArray.Add(tileInstance);
        }
    }

    private void ChangeParent()
    {
            
    }
}
