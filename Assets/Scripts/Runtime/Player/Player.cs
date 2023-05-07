using UnityEngine;
using UnityEngine.AI;
using CatCity.Player;

public class Player : MonoBehaviour
{
    #region Public Components
    public NavMeshAgent navAgent;
    public GameObject playerObject;
    public Transform point;
    public float speed;
    public Camera mainCamera;
    public Animator animatorController;
    #endregion

    private PlayerMovement movementPlayer;
    private PlayerAnimation animationPlayer;

    // Called on the first freame object
    void Start()
    {
        movementPlayer = new PlayerMovement(); // set player movement
        movementPlayer.StartScript(navAgent, point, playerObject, speed, mainCamera); // start player movement script
        
        animationPlayer = new PlayerAnimation(); // set player animator
        animationPlayer.StartAnimator(animatorController); // start player animator script

        pausePlayer = false; // unpause player to move
    }

    public bool pausePlayer { get; private set; } // current movement player option

    // Called by freame
    void Update()
    {
        // verufy if player pause
        if(pausePlayer)
        {
            return;
        }

        movementPlayer.UpdateMovement(); // update movement
        animationPlayer.AnimMovement(movementPlayer.PlayerDirection()); // update animator
    }

    #region External Commands
    // change the movement mode
    public void ChangeMovementMode(MovementMode newMode)
    {
        movementPlayer.ChangeMoveMode(newMode);
    }

    // Alternt in player pause and unpause
    public void PausePlayerMovement()
    {
        pausePlayer = !pausePlayer;
    }
    #endregion
}