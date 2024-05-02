using UnityEngine;

public class CueScript : MonoBehaviour
{
    [SerializeField] private Transform _cuePosition;
    [SerializeField] private Transform _whiteBallPosition;

    private Vector3 mousePosition;

    private float rotZ;

    private void Start()
    {
        _cuePosition.position = new Vector3(_whiteBallPosition.position.x, 1, _whiteBallPosition.position.z);

        _cuePosition.gameObject.SetActive(false);
    }

    private void Update()
    {
        _cuePosition.position = new Vector3(_whiteBallPosition.position.x, 1, _whiteBallPosition.position.z);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _cuePosition.transform.position;
        mousePosition.Normalize();

        rotZ = Mathf.Atan2(mousePosition.x, mousePosition.z) * Mathf.Rad2Deg;

        Controller();

    }

    private void Controller()
    {
        if (Ball._travelSpeed < 0.3f)
        {
            if (Input.GetMouseButton(0))
            {
                _cuePosition.transform.rotation = Quaternion.Euler(0, rotZ, 0);

                _cuePosition.gameObject.SetActive(true);
            }
            else
            {
                _cuePosition.gameObject.SetActive(false);
            }
        }
        
    }
}
