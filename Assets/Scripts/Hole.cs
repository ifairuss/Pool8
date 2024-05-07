using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private float _decreaseBall = 0.35f;

    private void OnTriggerStay(Collider other)
    {
        _decreaseBall = Mathf.Clamp(_decreaseBall, 0.1f, 0.35f);

        if (other.CompareTag("Ball"))
        {
            _decreaseBall -= 0.05f;

            other.gameObject.transform.localScale = new Vector3(_decreaseBall, _decreaseBall, _decreaseBall);

            if(_decreaseBall <= 0.1f)
            {
                Destroy(other.gameObject);
                _decreaseBall = 0.35f;
            }
        }
    }
}
