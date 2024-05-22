using System.Collections;
using TMPro;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private float _duration = 0.35f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.attachedRigidbody.velocity = Vector3.zero;
            StartCoroutine(ChangeScaleRoutine(other));
        }

    }

    private IEnumerator ChangeScaleRoutine(Collider other)
    {
        var startScale = other.transform.localScale;
        var remaingTime = _duration;

        while (remaingTime >= 0)
        {
            remaingTime -= Time.deltaTime;
            var lerpValue = Mathf.InverseLerp(0f, _duration, remaingTime);
            other.transform.localScale = Vector3.Lerp(Vector3.zero, startScale, lerpValue);

            yield return null;
        }
    }
}
