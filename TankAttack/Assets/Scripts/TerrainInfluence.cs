using UnityEngine;

public class TerrainInfluence : MonoBehaviour
{
    // Trigger if an object entered this area
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<Player>().DiminishSpeed(0.8f);
        }
    }

    // Trigger if an object left this area
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<Player>().ReturnToNormalSpeed();
        }
    }	
}
