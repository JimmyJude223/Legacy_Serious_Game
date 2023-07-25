using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrackPlayerScript : MonoBehaviour
{
    public GameObject objecttotrack;

    // Start is called before the first frame update
    Transform playerTransform;
    void Start()
    {
        playerTransform = objecttotrack.transform;
    }
    // Update is called once per frame
    void Update()
    {
        // keep the camera Z the same
        float camZ = this.transform.position.z;
        // make the camera x and y follow the player
        float camX = playerTransform.position.x;
        float camY = playerTransform.position.y;
        this.transform.position = new Vector3(camX, camY, camZ);
    }
}