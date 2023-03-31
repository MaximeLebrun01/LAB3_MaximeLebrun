using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTpDepart : MonoBehaviour
{
    private GestionJeu _gestionJeu;

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = new Vector3(0f, 301.734985f, -40f);
            _gestionJeu.AugmenterPointage();
        }
    }
}
