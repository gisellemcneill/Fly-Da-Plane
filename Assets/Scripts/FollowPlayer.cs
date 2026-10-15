using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player object

    private Vector3 offset = new Vector3(0, 5, -7); // Offset from the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // LateUpdate was added to ensure that the camera follows the player after the player has moved in Update
    // Removed jittery/rocky camera follow
    void LateUpdate()
    {
        //Finds player then adds some offset to the camera position so it is not directly on top of the player
        transform.position = player.transform.position + offset;
        
    }
}
