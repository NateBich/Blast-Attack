using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour
{
    public GameObject playerGameObject;
    private float dist = 25f;
    private Camera cam;
	
	void Start ()
    {
        playerGameObject = GameObject.Find("Player");        
        gameObject.GetComponent<Camera>().orthographicSize = 15;
	}
	
	
	void Update ()
    {
        transform.position = new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y, playerGameObject.transform.position.z - dist);
	}
}
