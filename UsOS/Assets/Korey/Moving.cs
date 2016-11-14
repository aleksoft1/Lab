using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Moving : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer sprite;

    private float speedEqual = 4;
    private float horizontal;

    private bool isSprintig;
    private bool isJumping;
    private bool endOfAnimation;
    private bool lowerKick;
    private bool isGrounded = true;
    private bool isMoving;


    private void Update()
    {
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        MovingCharacter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "FloorCollider")
        {
            this.isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FloorCollider"))
        {
            this.isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FloorCollider"))
        {
            this.isGrounded = true;
        }
    }

    private void MovingCharacter()
    {
        if (horizontal != 0)
        {
            transform.Translate(
                new Vector2(horizontal * speedEqual * Time.deltaTime, 0f));
            if (horizontal < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            isSprintig = true;
        }
        else
        {
            isSprintig = false;
        }

        animator.SetFloat("Sprint", Mathf.Abs(horizontal));
        animator.SetFloat("Walking", Mathf.Abs(horizontal));
        animator.SetBool("Idle", isSprintig);
    }
}