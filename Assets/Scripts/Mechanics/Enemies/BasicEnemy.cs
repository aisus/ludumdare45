using System;
using System.Collections;
using System.Collections.Generic;

using Common;

using DG.Tweening;
using Utility;

using Mechanics;
using Mechanics.Weapons;

using Player;

using UnityEngine;


public class BasicEnemy
        : MonoBehaviour,
          IGameCharacter
{
    [Range(0, 1000)]
    [SerializeField] private float      _movementSpeed;
    [Range(0.1f, 3)]
    [SerializeField] private float      _shootDelay        = 1f;
    [Range(1, 50)]
    [SerializeField] private float      _detectionDistance = 10f;
    [SerializeField] private GameObject _deathEffectPrefab;
    [SerializeField] private bool _drawGizmos;

    private Rigidbody2D _rigidbody;
    private float       _lookAngle;
    protected Vector2     _moveDirection;
    private Weapon      _weapon;

    private Coroutine _shootCoroutine;

    public  Action<BasicEnemy> OnDeath;
    private int                _layer_mask;


    public void RecieveDamage()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
        OnDeath.Invoke(this);
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _weapon = GetComponentInChildren<Weapon>();
        _weapon.SetMaster(this);
        _layer_mask = ~LayerMask.GetMask("Enemies");
    }

    protected virtual void Start()
    {
        GameplayManager.Instance.RegisterEnemy(this);
    }

    protected virtual void OnEnable()
    {
        _shootCoroutine = StartCoroutine(Shoot());
    }

    protected virtual void OnDisable()
    {
        StopCoroutine(_shootCoroutine);
    }

    protected virtual void Update()
    {
        var lookPos = GameplayManager.Instance.PlayerPosition;
        var lookDir = lookPos - this.transform.position;

        _lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    protected virtual void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * _movementSpeed * Time.fixedDeltaTime;
        _rigidbody.MoveRotation(Quaternion.Euler(0, 0, _lookAngle));
    }

    private IEnumerator Shoot()
    {
        var lastShotTime = Time.time;
        while (this.isActiveAndEnabled)
        {
            var t = 0f;
            while (t < 1)
            {
                t = (Time.time - lastShotTime) / _shootDelay;
                _weapon.SetFillSprite(t);
                yield return new WaitForEndOfFrame();
            }

            Debug.DrawLine(transform.position, transform.position + transform.up * _detectionDistance, Color.cyan, 0.1f);
            var hit = Physics2D.Raycast(transform.position, transform.up, _detectionDistance, _layer_mask);
            if (hit.collider != null)
            {
                var character = hit.transform.gameObject.GetComponent<PlayerCharacter>();
                if (character != null)
                {
                    lastShotTime = Time.time;
                    _weapon.Shoot();
                    _weapon.SetFillSprite(0);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmos)
        {
            GizmosExtensions.DrawCircleGizmo(Color.cyan, _detectionDistance, this.transform.position + Vector3.up * 0.3f, 20);
        }
    }
}
