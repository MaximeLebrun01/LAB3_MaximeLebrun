using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiege : MonoBehaviour
{
    //Attributs
    private bool _passe = false;
    //[SerializeField] private GameObject _piege = default;
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();
    [SerializeField] private float _intensiteForce = 500;
    private List<Rigidbody> _listeRb = new List<Rigidbody>();
    //private Rigidbody _rb;

    private void Start()
    {
        foreach(var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
            piege.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !_passe)
        {
            foreach(var rb in _listeRb)
            {
                foreach (var Go in _listePieges)
                {
                    Go.SetActive(true);
                }
                rb.AddForce(Vector3.left * _intensiteForce);
            }
            _passe = true;
        }
    }
}
