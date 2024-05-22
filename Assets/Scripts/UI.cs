using System.Reflection;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private int _score;

    [SerializeField] private TextMeshProUGUI _scorePoint;

    private void Update()
    {
        if(GameBall.PointSet > 0)
        {
            if (GameBall.PointSet > 0)
            {
                _score += GameBall.PointSet;
                GameBall.PointSet = 0;
            }

            _scorePoint.text = $">|{_score}|<";
        }
    }
}
