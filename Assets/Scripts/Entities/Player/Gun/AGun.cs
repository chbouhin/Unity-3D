using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour
{
    public float _firerate = 15f;
    public GameObject _muzzleFlash;
    public float _muzzleFlashDuration = 0.15f;
    public int _maxAmmo = 10;
    public float _reloadTime = 1f;
    public bool _automatic = true;
    public Animator _animator;

    protected bool _reloading = false;
    protected int _currentAmmo;
    protected float _nextTimeToFire = 0f;
    protected float _muzzleFlashTimer = 0f;

    protected virtual void Awake()
    {
        _currentAmmo = _maxAmmo;
    }

    protected virtual void Start()
    {
        _muzzleFlash.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_reloading) {
        } else if (_currentAmmo <= 0 || Input.GetKeyDown("r"))
            StartCoroutine(Reload());
        else if (((_automatic && Input.GetButton("Fire1")) || (!_automatic && Input.GetButtonDown("Fire1"))) && Time.time >= _nextTimeToFire) {
            _muzzleFlashTimer = Time.time + _muzzleFlashDuration;
            _nextTimeToFire = Time.time + 1f / _firerate;
            Shoot();
        }
        if (_muzzleFlash.activeInHierarchy && Time.time >= _muzzleFlashTimer)
            _muzzleFlash.SetActive(false);
    }

    protected virtual void OnEnable()
    {
        _reloading = false;
        _animator.SetBool("Reloading", false);
        _muzzleFlash.SetActive(false);
    }

    protected virtual void Shoot()
    {
        _muzzleFlash.SetActive(true);
        _currentAmmo--;
    }

    protected virtual IEnumerator Reload()
    {
        _muzzleFlash.SetActive(false);
        _reloading = true;
        _animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(_reloadTime - 0.25f);
        _animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        _currentAmmo = _maxAmmo;
        _reloading = false;
    }
}
