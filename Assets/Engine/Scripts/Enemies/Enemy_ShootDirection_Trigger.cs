using UnityEngine;
using System.Collections;
using Engine;

namespace Enginge.Enemies
{
    public class Enemy_ShootDirection_Trigger : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                SendMessageUpwards("IsFriendInFront", true);
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                SendMessageUpwards("IsFriendInFront", false);
            }
        }
    }
}