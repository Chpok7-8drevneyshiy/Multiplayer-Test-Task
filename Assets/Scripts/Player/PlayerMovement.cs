using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float angle;
    [SerializeField] private float dirx , diry ;
    private Rigidbody2D _rigidbody;
    private PhotonView view;
    
    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Initialize()
    {
        view = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }
    private void Movement()
    {
        dirx = joystick.Horizontal * playerSpeed;
        diry = joystick.Vertical * playerSpeed;
        Vector2 direction = new Vector2(dirx, diry);

        if (view.IsMine)
        {
            _rigidbody.velocity = direction;
            angle = Mathf.Atan2(diry, dirx) * Mathf.Rad2Deg - 90f;
            _rigidbody.rotation = angle;
        }
    }
}
