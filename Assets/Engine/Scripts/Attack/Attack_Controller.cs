using UnityEngine;
using System.Collections;
using Engine.Poolers;

namespace Engine.Attack
{    
    public class Attack_Controller : MonoBehaviour
    {
        public int currentWeapon; // Current selected weapon
        float delayAttack = 0.5f; // Delay between attacks/shots
        private bool canAttack = true; // Can or cannot attack

        public Transform bulletSpawn;

        public string bulletsParentName;
        private Bullet_PoolSpawner bPoolSpawner;

        private new Collider2D collider = null;

        void Start ()
        {
            currentWeapon = 1;
            if (bPoolSpawner == null)
                bPoolSpawner = GameObject.Find(bulletsParentName).GetComponent<Bullet_PoolSpawner>();
            if (collider == null)
                collider = GetComponent<Collider2D>();
        }
        void Awake ()
        {
            currentWeapon = 1;
            if (bPoolSpawner == null)
                bPoolSpawner = GameObject.Find(bulletsParentName).GetComponent<Bullet_PoolSpawner>();
            if (collider == null)
                collider = GetComponent<Collider2D>();
        }

        // Called when attack wanted
        public void Fire ()
        {
            if (canAttack)
            {
                Attack(currentWeapon);
                canAttack = false;
            }
        }

        // Initiates attacks 
        private void Attack(int curWeapon)
        {
            SpawnBullet();
            StartCoroutine(DelayAttack(delayAttack));
        }

        // Spawns bullet in spawn location
        private void SpawnBullet()
        {
            for (int i = 0; i < bPoolSpawner.standardBullets_list.Count; i++)
            {
                if (!bPoolSpawner.standardBullets_list[i].activeInHierarchy)
                {
                    bPoolSpawner.standardBullets_list[i].transform.position = bulletSpawn.transform.position;
                    bPoolSpawner.standardBullets_list[i].transform.rotation = bulletSpawn.transform.rotation;
                    bPoolSpawner.standardBullets_list[i].SetActive(true);
                    bPoolSpawner.standardBullets_list[i].SendMessage("Set Weapon", currentWeapon);
                    bPoolSpawner.standardBullets_list[i].SendMessage("IgnoreCollion", collider);
                    break;
                }
            }
        }

        // Delay between attacks
        private IEnumerator DelayAttack(float delAttack)
        {
            yield return new WaitForSeconds(delAttack);
            canAttack = true;
        }
    }
}
