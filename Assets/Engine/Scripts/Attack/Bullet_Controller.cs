using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Engine.Attack
{
    public class Bullet_Controller : MonoBehaviour
    {
        private Rigidbody2D rigid;
        private float bulletLifeTime = 0.5f;
        private float bulletSpeed = 150f;//300f;

        //private bool dontCollide = false;

        private Collider2D thisCollider;

        void Awake()
        {          
            if (rigid == null)
                rigid = GetComponent<Rigidbody2D>();
            if (thisCollider == null)
                thisCollider = GetComponent<Collider2D>();
        }

        // On enable make bullet move and start deactivate timer
        void OnEnable()
        {
            StartCoroutine(BulletDeath(bulletLifeTime));
        }

        void Update()
        {
            rigid.velocity = transform.TransformDirection(rigid.transform.up) * -bulletSpeed;
            rigid.velocity.Normalize();

            
        }

        void SetWeapon (int weaponType)
        {
            switch (weaponType)
            {
                case 1:
                    bulletSpeed = 150f;
                    bulletLifeTime = 0.5f;
                    break;
                case 2:
                    bulletSpeed = 250f;
                    bulletLifeTime = 0.25f;
                    break;
            }

        }

        void IgnoreCollion (Collider2D col)
        {
            Physics2D.IgnoreCollision(col, thisCollider);
        }

        // Timer for bullet being disabled
        private IEnumerator BulletDeath(float lifeTime)
        {
            yield return new WaitForSeconds(lifeTime);

            this.gameObject.SetActive(false);
        }

        // Disables gameObject from object it collides with
        void DisableBullet ()
        {            
            this.gameObject.SetActive(false);            
        }

        void OnDisable()
        {
            StopCoroutine(BulletDeath(bulletLifeTime));
        }
    }
}
