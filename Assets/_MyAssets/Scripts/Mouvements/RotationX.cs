using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationX : MonoBehaviour
{
    //Attribue
    [SerializeField] private float _vitesseRotationX = 0.5f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_vitesseRotationX, 0f, 0f);
    }
}
