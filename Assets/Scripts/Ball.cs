using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Space]
    [Header("Ball statistics")]
    [SerializeField] private float ballSpeed;
    [SerializeField] private float moveSpeed;

    [Space]
    [Header("Ball stats")]
    private bool _isMouseBtnClicked = false;

    private Vector3 _startMousePosition;
    private Vector3 _mousePosition;

    public float TravelSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (TravelSpeed > 0.01f && TravelSpeed <= 0.3f)
        {
            rb.drag = 3.5f;
        }
        else
        {
            rb.drag = 0;
        }

        TravelSpeed = rb.velocity.magnitude;

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _mousePosition.Normalize();

        Move();
    }

    private void Move()
    {
        if (TravelSpeed < 0.3f)
        {
            if (Input.GetMouseButton(0))
            {
                if (_isMouseBtnClicked == false)
                {
                    _startMousePosition = _mousePosition;
                    _isMouseBtnClicked = true;
                }

                if (_isMouseBtnClicked == true)
                {
                    float distanceForce = Vector3.Distance(_startMousePosition, _mousePosition) * 10;

                    distanceForce = Mathf.Round(distanceForce);

                    ballSpeed = distanceForce;
                }
            }
            else
            {
                _startMousePosition = new Vector3(0, 0, 0);
                _isMouseBtnClicked = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                float hitForce = ballSpeed * moveSpeed;

                Vector3 velovity = new Vector3(-_mousePosition.x, 0, -_mousePosition.z);
                rb.AddForce(velovity * hitForce, ForceMode.Impulse);

                ballSpeed = 0f;
            }
        }

        ballSpeed = Mathf.Clamp(ballSpeed, 0f, 5f);
    }
}
