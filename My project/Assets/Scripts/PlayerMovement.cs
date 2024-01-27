using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        float zDirection = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xDirection, 0, zDirection).normalized;
        if (movement != Vector3.zero)
            _animator.SetBool("isWalking", true);
        else
            _animator.SetBool("isWalking", false);

        if (xDirection >= 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;

        transform.Translate(movement * _speed * Time.deltaTime);
        //_rb.velocity = movement * _speed;    

    }

    public void Punch()
    {
        _animator.SetTrigger("Punch");
    }
}
