using UnityEngine;
using UnityEngine.AI;
using CatCity.Player;

[AddComponentMenu("Cat City/Payer Controller")]
public class Player : MonoBehaviour
{
    #region Components
    public NavMeshAgent navAgent;
    public GameObject playerObject;
    public Transform point;
    public float speed;
    public Camera mainCamera;
    public Animator animatorController;
    #endregion

    public PlayerMovement MovementPlayer { get; private set; }
    public PlayerAnimation AnimationPlayer { get; private set; }

    // Called on the first freame object
    void Start()
    {
        SetMovementSript();
        PausePlayer = false; // unpause player to move
    }

    /// <summary>
    /// Start the movement player script 
    /// </summary>
    private void SetMovementSript()
    {
        MovementPlayer = new PlayerMovement(); // set player movement
        MovementPlayer.StartScript(navAgent, point, playerObject, speed, mainCamera); // start player movement script
        
        AnimationPlayer = new PlayerAnimation(); // set player animator
        AnimationPlayer.StartAnimator(animatorController); // start player animator script
    }

    /// <summary>
    /// current movement player option
    /// </summary>
    public bool PausePlayer { get; set; } 
    
    // Called by freame
    void Update()
    {
        // verufy if player pause
        if(PausePlayer)
        {
            return;
        }

        if(MovementPlayer != null)
        {
            MovementPlayer.UpdateMovement(); // update movement
            AnimationPlayer.AnimMovement(MovementPlayer.PlayerDirection()); // update animator
        }
        else
        {
            SetMovementSript();
        }
    }

    #region External Commands
    /// <summary>
    /// Change the movement mode
    /// </summary>
    public void ChangeMovementMode(MovementMode newMode)
    {
        MovementPlayer.ChangeMoveMode(newMode);
    }

    /// <summary>
    /// Return if player is in movement
    /// </summary>
    public bool PlayerInMovement()
    {
        Vector2 playerDirection;
        playerDirection = MovementPlayer.PlayerDirection();

        if((int)playerDirection.x != 0 || (int)playerDirection.y != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}