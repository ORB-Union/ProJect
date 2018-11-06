using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour {

    public Transform[] SpawnPoints;
    public float SpawnTime = 13f;


    public GameObject[] Potions;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnPotion", SpawnTime, SpawnTime);    
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void SpawnPotion()
    {
        int potionIndex = Random.Range(0, Potions.Length);

        List<Transform> temp_list = new List<Transform>(SpawnPoints);

        for (int i = 0; i < 2; ++i)
        {
            int spawinIndex = Random.Range(0, SpawnPoints.Length);

            Instantiate(Potions[potionIndex], SpawnPoints[spawinIndex].position, SpawnPoints[spawinIndex].rotation);

            // 한번 뽑은건 리스트에서 삭제. 
            temp_list.Remove(temp_list[spawinIndex]);
        }

    }
}
