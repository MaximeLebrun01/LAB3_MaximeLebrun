using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Attribue
    [SerializeField] private float _vitesse = 100;
    private Rigidbody _rb;

    private void Start()
    {
        // Position départ joueur
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        
        this.transform.position = new Vector3(-45.0200005f, 301.734985f, -43.0299988f);
        if (indexScene == 1)
            this.transform.position = new Vector3(0f, 301.734985f, -40f);
        else if (indexScene == 2)
            this.transform.position = new Vector3(-43.9099998f, 301.734985f, -44.5400009f);
            _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(positionX, -0.5f, positionZ);
        // transform.Translate(direction * Time.deltaTime * _vitesse);
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
    }

    public void FinPartie()
    {
        _vitesse = 0;
    }
}
