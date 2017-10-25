using UnityEngine;
using System.Collections;
using Engine.Poolers;

namespace Engine.AI
{
    public class AIBehavior : MonoBehaviour
    {
        private bool canIMove = true;
        private bool canIShoot = false;

        private bool friendInWay = false;

        private Transform target;
        private float minDist = 7f;
        //private float maxDist = 15f;
        private float maxShootDistance = 15f;    

        void Start ()
        {
            if (target == null)
                target = GameObject.Find("Player").transform;
        }

        void OnEnable ()
        {
            if (target == null)
                target = GameObject.Find("Player").transform;
        }

        void Update ()
        {
            CheckForEnemy();
            //CheckForFriendly();
        }

        void StopPlayer()
        {
            canIMove = false;
        }

        public bool WillIMove ()
        {
            return canIMove;
        }

        public bool WillIShoot ()
        {
            return canIShoot;
        }

        private void CheckForEnemy ()
        {
            if (Vector3.Distance(transform.position, target.position) >= minDist)            
                canIMove = true;            
            if (Vector3.Distance(transform.position, target.position) < minDist)            
                canIMove = false;

            if (!friendInWay)
            {
                if (Vector3.Distance(transform.position, target.position) <= maxShootDistance)
                    canIShoot = true;
                if (Vector3.Distance(transform.position, target.position) > maxShootDistance)
                    canIShoot = false;
            }
        }

        void IsFriendInFront (bool isTrue)
        {
            friendInWay = isTrue;
        }   
    }
}
