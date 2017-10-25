using UnityEngine;
using System.Collections;
using Engine.Attack;

namespace Engine.Player
{
    public class Player_Controller : MonoBehaviour
    {
        float movementSpeed;
        float maxSpeed;

        protected Rigidbody2D rigidPlayer;
        protected Attack_Controller attackController;

        protected float moveVelocity = 0.0f;

        void Start()
        {
            movementSpeed = 25f;
            if (rigidPlayer == null)
                rigidPlayer = GetComponent<Rigidbody2D>();
            if (attackController == null)
                attackController = GetComponent<Attack_Controller>();
        }

        void Update ()
        {
            if (Input.GetButton("Fire1"))
                attackController.Fire();
            
        }

        void FixedUpdate()
        {
            CalculateMovement();
            CalculateRotation();
        }

        // Calculates where player should be facing based on the mouse position on screen
        private void CalculateRotation()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 tar = Vector3.zero;

            if (Physics.Raycast(ray, out hit, 35))
            {
                tar = new Vector3(hit.point.x, hit.point.y, 0f);
                Vector3 newTarget = tar - transform.position;
                float angle = (Mathf.Atan2(newTarget.y, newTarget.x) * Mathf.Rad2Deg) - 90f;
                Quaternion rotateTo = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, Time.deltaTime * 10);
            }
        }

        // Calculates player movement
        private void CalculateMovement()
        {
            float x = Input.GetAxis("Horizontal") * movementSpeed;
            float y = Input.GetAxis("Vertical") * movementSpeed;
            if (x != 0)
                Mathf.SmoothDamp(x, x * 5, ref moveVelocity, 0.3f, 10f, Time.deltaTime);

            if (y != 0)
                Mathf.SmoothDamp(y, y * 5, ref moveVelocity, 0.3f, 10f, Time.deltaTime);

            rigidPlayer.velocity = new Vector2(x, y);
            rigidPlayer.velocity.Normalize();
        }
    }
}
