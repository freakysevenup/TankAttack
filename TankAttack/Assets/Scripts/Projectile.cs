using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Fire if this object collided with anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Create a particle explosion at the place where this gameobject is
        // then delete the gameobject.

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Killed a player");
        }

        Destroy(gameObject);
    }
}
