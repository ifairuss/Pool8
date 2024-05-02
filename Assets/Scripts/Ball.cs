using UnityEditorInternal;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Space]
    [Header("Ball statistics")]
    [SerializeField]private float moveSpeed;
    [SerializeField,Range(min: 0, max: 5)] private float ballSpeed;

    [Space]
    [Header("Ball stats")]
    [SerializeField]private bool _clickBtnMouse = false;

    [SerializeField] private Vector3 _startMousePosition;
    [SerializeField] private Vector3 _mousePosition;
    [SerializeField] private Vector3 _startHitPosition;
    [SerializeField] private Vector3 _ballPosition;


    public static float _travelSpeed;
    //для дебвгу
    public float _travelSpeedInspector;
    //

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _startHitPosition = transform.position;
    }


    private void Update()
    {
        //для дебвгу
        _travelSpeedInspector = _travelSpeed;
        //

        if (_travelSpeed > 0.01f && _travelSpeed <= 0.3f)
        {
            rb.drag = 5;
        }
        else
        {
            rb.drag = 0;
        }

        _travelSpeed = Vector3.Distance(_startHitPosition, _ballPosition);
        _travelSpeed = rb.velocity.magnitude;

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _mousePosition.Normalize();

        _startHitPosition = transform.position;
        _ballPosition = rb.transform.position;

        Move();
    }

    private void Move()
    {
        if (_travelSpeed < 0.3f)
        {
            if (Input.GetMouseButton(0))
            {
                if (_clickBtnMouse == false)
                {
                    _startMousePosition = _mousePosition;
                    _clickBtnMouse = true;
                }

                if (_clickBtnMouse == true)
                {
                    float distanceVector = Vector3.Distance(_startMousePosition, _mousePosition) * 10;

                    distanceVector = Mathf.Round(distanceVector);

                    ballSpeed = distanceVector;
                }
            }
            else
            {
                _startMousePosition = new Vector3(0, 0, 0);
                _clickBtnMouse = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                float hitForce = ballSpeed * moveSpeed;

                Vector3 velovity = new Vector3(-_mousePosition.x, 0, -_mousePosition.z);
                rb.AddForce(velovity * hitForce);

                ballSpeed = 0f;
            }
        }
    }
}
