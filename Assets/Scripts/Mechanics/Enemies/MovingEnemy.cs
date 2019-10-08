using UnityEngine;
using Common;

public class MovingEnemy : BasicEnemy
{
    [Range(1, 50)]
    [SerializeField] private float _minRadius;
    [Range(1, 50)]
    [SerializeField] private float _maxRadius;

    private bool _isChasing;

    protected override void Update()
    {
        base.Update();

        if (_playerSeen)
        {
            _isChasing = true;
        }

        var playerPos = GameplayManager.Instance.PlayerPosition;

        var direction =  (playerPos - transform.position).normalized;

        if (_isChasing)
        {
            _moveDirection = direction;
        }
    }
}
