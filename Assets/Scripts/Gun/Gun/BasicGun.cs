using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : AGun
{
    public float _damage = 10f;
    public float _range = 100f;
    public Camera _playerCam;
    public GameObject _impactEffect;

    protected override void Shoot()
    {
        base.Shoot();
        RaycastHit hit;
        if (Physics.Raycast(_playerCam.transform.position, _playerCam.transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
            ATarget target = hit.transform.GetComponent<ATarget>();
            if (target)
            {
                target.TakeDamage(_damage);
            }
            GameObject impactEffect = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 2f);
        }
    }
}
