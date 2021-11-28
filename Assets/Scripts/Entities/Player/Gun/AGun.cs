using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour
{
    [SerializeField] protected float _firerate = 15f;
    [SerializeField] protected GameObject _muzzleFlash;
    [SerializeField] protected float _muzzleFlashDuration = 0.15f;
    [SerializeField] protected int _maxAmmo = 10;
    [SerializeField] protected float _reloadTime = 1f;
    [SerializeField] protected bool _automatic = true;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected LayerMask _layerToIgnore;
    [SerializeField] private AudioSource _gunReloading;
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

    protected virtual void Update()
    {
        if (!_reloading) {
            if ((_currentAmmo <= 0 || Input.GetKeyDown("r")) && Time.timeScale == 1) {
                AudioSource gunReloading = Instantiate(_gunReloading, this.transform.position, this.transform.rotation);
                StartCoroutine(Reload());
            } else if (((_automatic && Input.GetButton("Fire1")) || (!_automatic && Input.GetButtonDown("Fire1"))) && Time.time >= _nextTimeToFire && Time.timeScale == 1) {
                _muzzleFlashTimer = Time.time + _muzzleFlashDuration;
                _nextTimeToFire = Time.time + 1f / _firerate;
                Shoot();
            }
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
