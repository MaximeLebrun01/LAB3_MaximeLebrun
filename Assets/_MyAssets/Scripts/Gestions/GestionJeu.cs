using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // Attributs
    private int _pointage = 0;
    private float _tempsAffiche = 0;
    private float _tempsFinal = 0;
    private float _tempsDepart = 0;

    
    public float TempsFinal { get => _tempsFinal; set => _tempsFinal = value; }
    public float TempsDepart { get => _tempsDepart; set => _tempsDepart = value; }
    public int Pointage { get => _pointage; set => _pointage = value; }
    public float TempsAffiche { get => _tempsAffiche; set => _tempsAffiche = value; }

    private void Awake()
    {
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Pointage = 0;
        _tempsDepart = Time.time;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetTempsFinal(float p_tempFinal)
    {
        _tempsFinal = p_tempFinal - _tempsDepart - _tempsAffiche;
    }


    // Méthode plublic
    public void AugmenterPointage()
    {
        Pointage++;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(_pointage);
    }
}
