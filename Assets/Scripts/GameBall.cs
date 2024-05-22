using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField]private int _gemePoints;

    public static int PointSet;

    private void Start()
    {
        _gemePoints = Random.Range(10, 100);

        PointSet = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hole"))
        {
            PointSet += _gemePoints;
        }
    }
}
