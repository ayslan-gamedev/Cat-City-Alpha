using UnityEngine;

namespace CatCity.Player
{
    public class PlayerAnimation
    {
        private Animator currentAnimatorController;
        private SpriteRenderer currentPlayerRender;

        public void StartAnimator(Animator animatorController)
        {
            currentAnimatorController = animatorController;
            currentPlayerRender = animatorController.gameObject.GetComponent<SpriteRenderer>();
        }

        public void AnimMovement(Vector2 playerDirection)
        {
            if((int)playerDirection.x != 0 || (int)playerDirection.y != 0)
            {
                currentAnimatorController.SetBool("Move", true);
            }
            else
            {
                currentAnimatorController.SetBool("Move", false);
            }

            currentAnimatorController.SetFloat("SpeedX", Mathf.Clamp((int)playerDirection.x, -1, 1));
            currentAnimatorController.SetFloat("SpeedY", Mathf.Clamp((int)playerDirection.y, -1, 1));
        }
    }
}