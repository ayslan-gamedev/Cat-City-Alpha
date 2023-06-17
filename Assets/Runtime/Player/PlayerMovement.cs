namespace CatCity.Player
{
    using UnityEngine;
    using UnityEngine.AI;

    public enum MovementMode { WASD, PointClick }

    public class PlayerMovement
    {
        #region TempVariables
        private NavMeshAgent navAgent;
        private Transform point;
        private GameObject playerObject;
        private float speed;
        private Camera currentCamera;

        // Set the direction to Animator Script
        public Vector2 PlayerDirection()
        {
            if(currentMovementMode == MovementMode.WASD)
            {
                return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }
            else
            {
                return point.transform.position - playerObject.transform.position;
            }
        }
        #endregion

        #region Commands
        public MovementMode currentMovementMode;

        public void StartScript(NavMeshAgent NavMeshAgent, Transform DestinyPoint, GameObject PlayerGameObject, float Speed, Camera camera)
        {
            navAgent = NavMeshAgent;
            point = DestinyPoint;
            playerObject = PlayerGameObject;
            speed = Speed;
            currentCamera = camera;

            currentMovementMode = LastMovement();
            ClearMovementData();
        }

        public void ChangeMoveMode(MovementMode? movementMode)
        {
            if(movementMode != null)
            {
                currentMovementMode = (MovementMode)movementMode;
            }
            else
            {
                switch(currentMovementMode) 
                {
                    case MovementMode.WASD:
                        currentMovementMode = MovementMode.PointClick;
                        break;

                    case MovementMode.PointClick:
                        currentMovementMode = MovementMode.WASD;
                        break;
                }
            }

            ClearMovementData();
        }

        public void UpdateMovement()
        {
            switch(currentMovementMode)
            {
                case MovementMode.WASD:
                    MoveWASD(playerObject, speed);
                    break;

                case MovementMode.PointClick:
                    MoveAgent(navAgent, point, currentCamera);
                    break;
            }
        }

        private void ClearMovementData()
        {
            navAgent.enabled = true;

            navAgent.updateRotation = false;
            navAgent.updateUpAxis = false;
            navAgent.speed = speed;

            navAgent.enabled = currentMovementMode == MovementMode.PointClick ? true : false;
            point.transform.localPosition = playerObject.transform.position;
        }
    
        private MovementMode LastMovement()
        {
            return MovementMode.PointClick;
        }
        #endregion

        #region NavMesh
        private void MoveAgent(NavMeshAgent navMeshAgent, Transform DestinyPoint, Camera camera)
        {
            if(Input.touchCount > 0)
            {
                Vector3 inputPosition;

                if(Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    inputPosition = new Vector3(touch.position.x, touch.position.y, 0);
                 
                }
                else
                {
                    inputPosition = Input.mousePosition;
                }
                
                Vector3 worldPoint = camera.ScreenToWorldPoint(inputPosition);
                Vector3 forwardPoint = worldPoint + (camera.transform.forward * 10.0f);

                DestinyPoint.transform.position = forwardPoint;
            }

            navMeshAgent.SetDestination(DestinyPoint.transform.position);
            Debug.Log("ok");
        }
        #endregion

        #region WASD
        private void MoveWASD(GameObject playerObject, float speed)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerObject.transform.Translate(direction * Time.deltaTime * speed);
        }
        #endregion
    }
}