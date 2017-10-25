using UnityEngine;
using System.Collections;
using Engine.AI;
using Engine.Attack;

namespace Engine.Enemies
{
    public class Enemy_Controller : MonoBehaviour
    {
        private Transform target;
        private float rotateSpeed = 5;
        private float extraTurn = 90;
        private float moveVelocity = 0.0f;
        private bool canIMove = true;        

        private float moveSpeed = 5f;

        //private Rigidbody2D rigidPlayer;

        private AIBehavior aiBehavior;
        private Attack_Controller attackController;

        // Use this for initialization
        void Start()
        {
            //rigidPlayer = GetComponent<Rigidbody2D>();

            if (aiBehavior == null)
                aiBehavior = GetComponent<AIBehavior>();
            if (attackController == null)
                attackController = GetComponent<Attack_Controller>();

        }

        void OnEnable()
        {
            if (target == null)
                target = GameObject.Find("Player").transform;
        }

        void Update ()
        {
            if (aiBehavior.WillIShoot())
            {
                attackController.Fire();
            }            
        }

        void FixedUpdate()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, GetPlayerPositionR(target.position), Time.deltaTime * rotateSpeed);  // Makes Enemy look at towards Player

            if (aiBehavior.WillIMove())
            {
                transform.position += transform.up * moveSpeed * Time.deltaTime;
            }
          
           
        }

        // Calculates the direction to rotate the enemy
        private Quaternion GetPlayerPositionR(Vector3 getTarget)
        {
            Vector3 targ = getTarget - transform.position;
            float angle = (Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg) - extraTurn;
            Quaternion rotateTo = Quaternion.AngleAxis(angle, Vector3.forward);
            return rotateTo;
        }                      
    }
}
