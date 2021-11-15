using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : AGun
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _range = 100f;
    [SerializeField] private Camera _playerCam;
    [SerializeField] private GameObject _impactEffect;

    protected override void Shoot()
    {
        base.Shoot();
        RaycastHit hit;
        if (Physics.Raycast(_playerCam.transform.position, _playerCam.transform.forward, out hit, _range))
        {
            AHealthManager target = hit.transform.GetComponent<AHealthManager>();
            if (target)
            {
                target.TakeDamage(_damage);
            }
            GameObject impactEffect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 2f);
        }
    }
}
