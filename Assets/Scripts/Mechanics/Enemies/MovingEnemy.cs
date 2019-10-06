using UnityEngine;
using Common;

public class MovingEnemy : BasicEnemy
{
    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;

    protected override void Update()
    {
        base.Update();
        var playerPos = GameplayManager.Instance.PlayerPosition;

        var direction =  (playerPos - transform.position).normalized;
        _moveDirection = direction;
    }
}
