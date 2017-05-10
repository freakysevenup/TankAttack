using UnityEngine;

public enum Direction
{
    NORTH,
    EAST,
    SOUTH,
    WEST
}

public class Player : MonoBehaviour {

    private bool moveUp = false, moveDown = false, moveLeft = false, moveRight = false;                 // Allow Movement Booleans
    private bool facingNorth = true, facingSouth = false, facingWest = false, facingEast = false;       // Facing Direction Booleans
    public Direction direction = Direction.NORTH;                                                       // Direction of Next Movement
    public float movementSpeed;                                                                         // The speed the player is currently moving

	void Start ()
    {
        moveUp = false;
        moveDown = false;
        moveLeft = false;
        moveRight = false;
        facingNorth = true;
        facingSouth = false;
        facingWest = false;
        facingEast = false;
        direction = Direction.NORTH;
        movementSpeed = 0.025f;
    }

    // Reduce Speed of the tank by a percentage of it's normal speed
    public void DiminishSpeed(float percent)
    {
        ReturnToNormalSpeed();
        movementSpeed *= percent;
    }

    // Increase speed of the tank by a percentage of its normal speed
    public void IncreaseSpeed(float percent)
    {
        ReturnToNormalSpeed();
        movementSpeed += (movementSpeed * percent);
    }

    // Return the tank to its normal speed
    public void ReturnToNormalSpeed()
    {
        movementSpeed = 0.025f;
    }

    // Switch booleans for determining travel direction
    private void ResetFacingDirection(Direction direction)
    {
        // Determine the last direction that
        // the player was facing and reset that
        // facing direction boolean.
        switch (direction)
        {
            case Direction.NORTH:
                facingNorth = false;
                break;
            case Direction.EAST:
                facingEast = false;
                break;
            case Direction.SOUTH:
                facingSouth = false;
                break;
            case Direction.WEST:
                facingWest = false;
                break;
            default:
                break;
        }
    }

    // Rotate the tank in the direction of movement
    private void RotateTank(Direction oldDirection, Direction newDirection)
    {
        // Determine the direction the player
        // was last moving in (oldDirection)
        // and rotate the tank in the direction
        // the player is now moving in.

        /*
         * If oldDirection was Direction.NORTH
         * and newDirection is Direction.EAST
         * rotate the tank to the east from the North;
         * 
         */

        switch (oldDirection)
        {
            case Direction.NORTH:
                switch(newDirection)
                {
                    case Direction.EAST:
                        // rotate to the east
                        transform.Rotate(Vector3.forward, -90f);
                        break;
                    case Direction.SOUTH:
                        // rotate to the south
                        transform.Rotate(Vector3.forward, 180f);
                        break;
                    case Direction.WEST:
                        // rotate to the west
                        transform.Rotate(Vector3.forward, 90f);
                        break;
                    default:
                        break;
                }
                break;
            case Direction.EAST:
                switch (newDirection)
                {
                    case Direction.NORTH:
                        // rotate to the north
                        transform.Rotate(Vector3.forward, 90f);
                        break;
                    case Direction.SOUTH:
                        // rotate to the south
                        transform.Rotate(Vector3.forward, -90f);
                        break;
                    case Direction.WEST:
                        // rotate to the west
                        transform.Rotate(Vector3.forward, 180f);
                        break;
                    default:
                        break;
                }
                break;
            case Direction.SOUTH:
                switch (newDirection)
                {
                    case Direction.EAST:
                        // rotate to the east
                        transform.Rotate(Vector3.forward, 90f);
                        break;
                    case Direction.NORTH:
                        // rotate to the north
                        transform.Rotate(Vector3.forward, 180f);
                        break;
                    case Direction.WEST:
                        // rotate to the west
                        transform.Rotate(Vector3.forward, -90f);
                        break;
                    default:
                        break;
                }
                break;
            case Direction.WEST:
                switch (newDirection)
                {
                    case Direction.EAST:
                        // rotate to the east
                        transform.Rotate(Vector3.forward, 180f);
                        break;
                    case Direction.SOUTH:
                        // rotate to the south
                        transform.Rotate(Vector3.forward, 90f);
                        break;
                    case Direction.NORTH:
                        // rotate to the north
                        transform.Rotate(Vector3.forward, -90f);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    // Process the input from the player
    private void Processinput()
    {
        if(Input.GetKeyDown("w"))
        {
            // The tank should be facing North now
            // if it is not
            if(direction != Direction.NORTH)
            {
                // Determine which way to rotate the tank
                RotateTank(direction, Direction.NORTH);
                // Reset the facing direction booleans
                ResetFacingDirection(direction);
                // set the direction of next travel to North
                direction = Direction.NORTH;
                // set the facing direction boolean 
                facingNorth = true;
                // allow the player to move north
                moveUp = true;
            }
            else
            {
                moveUp = true;
            }
        }
        if (Input.GetKeyDown("a"))
        {
            if (direction != Direction.WEST)
            {
                RotateTank(direction, Direction.WEST);
                ResetFacingDirection(direction);
                direction = Direction.WEST;
                facingWest = true;
                moveLeft = true;
            }
            else
            {
                moveLeft = true;
            }
        }
        if (Input.GetKeyDown("s"))
        {
            if (direction != Direction.SOUTH)
            {
                RotateTank(direction, Direction.SOUTH);
                ResetFacingDirection(direction);
                direction = Direction.SOUTH;
                facingSouth = true;
                moveDown = true;
            }
            else
            {
                moveDown = true;
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (direction != Direction.EAST)
            {
                RotateTank(direction, Direction.EAST);
                ResetFacingDirection(direction);
                direction = Direction.EAST;
                facingEast = true;
                moveRight = true;
            }
            else
            {
                moveRight = true;
            }
        }

        // if no keys are pressed the tank should stop moving
        // set the movement booleans to reflect this
        if (Input.GetKeyUp("w"))
        {
            moveUp = false;
        }
        if (Input.GetKeyUp("a"))
        {
            moveLeft = false;
        }
        if (Input.GetKeyUp("s"))
        {
            moveDown = false;
        }
        if (Input.GetKeyUp("d"))
        {
            moveRight = false;
        }

    }
	
	void Update ()
    {
        Processinput();

        // Move the tank in the direction the player has chosen
        if (moveUp && facingNorth)
        {
            transform.localPosition += new Vector3(0f, movementSpeed, 0f);
        }
        else if (moveLeft && facingWest)
        {
            transform.localPosition += new Vector3(-movementSpeed, 0f, 0f);
        }
        else if(moveDown && facingSouth)
        {
            transform.localPosition += new Vector3(0f, -movementSpeed, 0f);
        }
        else if (moveRight && facingEast)
        {
            transform.localPosition += new Vector3(movementSpeed, 0f, 0f);
        }
    }
}
