using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Engine.Poolers
{
    public class Enemy_PoolSpawner : MonoBehaviour
    {

        bool hasSpawned = false;
        //public GameObject enemyStandard;
        GameObject enemyStandardParent;
        public int enemyStandardPool = 10;
        static public List<GameObject> enemyStandard_list;

        void Start()
        {
            
            enemyStandardParent = GameObject.Find("EnemyStandardParent");
            if (!hasSpawned)
            {
                SpawnEnemy();
            }
        }

        // Generates bullets and places them within a list deactivated
        void SpawnEnemy()
        {
            enemyStandard_list = new List<GameObject>();
            for (int i = 0; i < enemyStandardPool; i++)
            {
                GameObject eS = Instantiate(Resources.Load("Enemy_Standard", typeof(GameObject))) as GameObject;
                eS.SetActive(false);
                eS.name = "Enemy_Standard";
                eS.transform.position = Vector2.zero;
                eS.transform.parent = enemyStandardParent.transform;
                enemyStandard_list.Add(eS);
            }
            hasSpawned = true;
        }
    }
}
