using UnityEngine;
using System.Collections;
using Engine.Attack;

namespace Engine.Enemies
{
    public class Enemy_CollisionDector : MonoBehaviour    
    {
        private Rigidbody2D rigidBody;

        void Start ()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Bullet")
            {
                gameObject.SetActive(false);
                col.gameObject.SendMessage("DisableBullet");                
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                SendMessage("StopEnemy");
            }
        }

        private void StopEnemy()
        {
            rigidBody.isKinematic = true;
            rigidBody.isKinematic = false;
        }        
    }
}
