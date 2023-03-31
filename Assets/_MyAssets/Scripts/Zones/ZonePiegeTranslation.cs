using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiegeTranslation : MonoBehaviour
{
    //Attribue
    private bool _passe = false;
    [SerializeField] private GameObject _piege = default;
    [SerializeField] private float _VitesseDeplacement = 10f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = _piege.GetComponent<Rigidbody>();
        _rb.mass = 200;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_passe)
        {
            Vector3 direction = new Vector3(-50f, 0f, 0f);
            _rb.velocity = direction * Time.fixedDeltaTime * _VitesseDeplacement;
            _passe = true;
        }
        if (other.gameObject.tag == "Piege")
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
