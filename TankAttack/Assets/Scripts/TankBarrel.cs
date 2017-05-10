using UnityEngine;

public class TankBarrel : MonoBehaviour
{
    private Vector3 direction;                          // The direction the barrel is facing right now
    public GameObject projectile;                       // The Projectile
    private float force = 200.0f;                       // The force of the projectile

    // Process the players input
    void ProcessInput()
    {
        // Mouse Buttons
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone;
            Debug.Log("Fire 1");
            clone = Instantiate(projectile, transform.position + ( 0.4f * direction), Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("You No Fire");
        }
    }

    // Return the direction the barrel is facing 
    public Vector3 GetBarrelDirection()
    {
        return direction;
    }

    // physics update, does not fire as often as Update
    void FixedUpdate ()
    {
        ProcessInput();

        //// Get the position of the transform in screen coordinates
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //// Get the direction of the mouse from the transform
        Vector3 dir = Vector3.Normalize(Input.mousePosition - pos);
        direction = dir;
        //// Get the angle 
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        angle *= -1;
        //// Rotate the transform to face the mouse cursor
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
