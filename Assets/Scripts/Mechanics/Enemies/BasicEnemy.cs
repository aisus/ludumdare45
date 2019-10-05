﻿using System;
using System.Collections;
using System.Collections.Generic;

using Common;

using DG.Tweening;

using Mechanics;
using Mechanics.Weapons;

using UnityEngine;


public class BasicEnemy : MonoBehaviour, IGameCharacter
{
    [SerializeField] private float      _movementSpeed;
    [SerializeField] private float      _shootDelay = 1f;
    [SerializeField] private GameObject _deathEffectPrefab;

    private Rigidbody2D _rigidbody;
    private float       _lookAngle;
    private Vector2     _moveDirection;
    private Weapon      _weapon;

    private Coroutine _shootCoroutine;

    public Action<BasicEnemy> OnDeath; 

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
    }

    private void Start()
    {
        GameplayManager.Instance.RegisterEnemy(this);
    }

    private void OnEnable()
    {
        _shootCoroutine = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shootCoroutine);
    }

    private void Update()
    {
        var lookPos = GameplayManager.Instance.PlayerPosition;
        var lookDir = lookPos - this.transform.position;

        _lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * Time.fixedDeltaTime;
        _rigidbody.MoveRotation(Quaternion.Euler(0, 0, _lookAngle));
    }

    private IEnumerator Shoot()
    {
        while (this.isActiveAndEnabled)
        {
            yield return new WaitForSeconds(_shootDelay);

            _weapon.Shoot();
        }
    }
}
