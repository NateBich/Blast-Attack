using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Engine.Poolers;
using Engine.Config;

namespace Engine.Config
{   
    public class Game_Manager : MonoBehaviour
    {
        public bool canEnableEnemy = false;
        private int randomSpawnNumber = 0;

        protected Transform player;

        public float timeDelay = 5f;
        public float spawnDistMin = 25f;
        public float spawnDistMax = 50f;
        
        

        // Use this for initialization
        void Start()
        {
            
            if (player == null)
                player = GameObject.Find("Player").transform;
           // if (coroutine == null)
                //coroutine = RandomNumberPicker();
        }

        // Initiates first random number to be chose
        void Awake()
        {
            if (player == null)
                player = GameObject.Find("Player").transform;
        
            StartCoroutine(RandomNumberPicker());
        }        

        // Update is called once per frame
        void Update()
        {
            if (canEnableEnemy)
            {
                EnableEnemy();
                canEnableEnemy = false;
                StartCoroutine(RandomNumberPicker());
            }
        }

        // Enables and positions the enemy a curtain distance away from player
        private void EnableEnemy()
        {
            int whereToSpawn = 0;
            for (int ranSpawnNumb = 0; ranSpawnNumb < randomSpawnNumber; ranSpawnNumb++)
            {
                whereToSpawn = Random.Range(1, 8);
                for (int i = 0; i < Enemy_PoolSpawner.enemyStandard_list.Count; i++)
                {
                    if (!Enemy_PoolSpawner.enemyStandard_list[i].activeInHierarchy)
                    {                        
                        Enemy_PoolSpawner.enemyStandard_list[i].transform.position = RandomPosition_Generator.RandomPositionGenerator(whereToSpawn, player);
                        Enemy_PoolSpawner.enemyStandard_list[i].SetActive(true);
                        break;
                    }
                }
            }            
        }

        // Chooses random number on how many enemies are to spawn
        private IEnumerator RandomNumberPicker()
        {
            randomSpawnNumber = Random.Range(1, 5); // Random number chosen
            yield return new WaitForSeconds(5f); // Time delay to enable enemies
            canEnableEnemy = true;           
        }
    }
}
