using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Engine.Poolers
{
    public class Bullet_PoolSpawner : MonoBehaviour
    {
        bool hasSpawned = false;
        public GameObject standardBullet;
        public GameObject standardBulletsParent;
        public int standardBulletsPool = 10;
        public List<GameObject> standardBullets_list;

        void Start()
        {            
            if (!hasSpawned)
            {
                SpawnBullets();
            }
        }

        // Generates bullets and places them within a list deactivated
        private void SpawnBullets()
        {
            standardBullets_list = new List<GameObject>();
            for (int i = 0; i < standardBulletsPool; i++)
            {
                GameObject b = Instantiate(Resources.Load("Standard_Bullet", typeof(GameObject))) as GameObject;
                b.SetActive(false);
                b.name = "Standard_Bullet";
                b.transform.position = Vector2.zero;
                b.transform.parent = standardBulletsParent.transform;
                standardBullets_list.Add(b);
            }
            hasSpawned = true;
        }
    }
}