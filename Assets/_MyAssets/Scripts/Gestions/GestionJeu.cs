using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // Attributs
    private int _pointage = 0;
    private int _accrochageNiveau1 = 0;
    private int _accrochageNiveau2 = 0;
    private int _accrochageNiveau3 = 0;
    private float _tempsNiveau1 = 0.0f;
    private float _tempsNiveau2 = 0.0f;
    private float _tempsNiveau3 = 0.0f;

    public global::System.Int32 AccrochageNiveau1 { get => _accrochageNiveau1; set => _accrochageNiveau1 = value; }
    public global::System.Int32 AccrochageNiveau2 { get => _accrochageNiveau2; set => _accrochageNiveau2 = value; }
    public global::System.Int32 AccrochageNiveau3 { get => _accrochageNiveau3; set => _accrochageNiveau3 = value; }
    public global::System.Single TempsNiveau1 { get => _tempsNiveau1; set => _tempsNiveau1 = value; }
    public global::System.Single TempsNiveau2 { get => _tempsNiveau2; set => _tempsNiveau2 = value; }
    public global::System.Single TempsNiveau3 { get => _tempsNiveau3; set => _tempsNiveau3 = value; }
    public global::System.Int32 Pointage { get => _pointage; set => _pointage = value; }

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
        Instructions();
    }

    private static void Instructions()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        if (indexScene == 0)
        {
            Debug.Log("*** Course à obstacle *** \n Atteindre la fin du parcours le plus rapidement possible");
            Debug.Log("Chaque obstacle qui sera touché entraînera une pénalité");
        }
    }

    public void SetNiveau1(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiv1;
    }

    public void SetNiveau2(int accrochages, float tempsNiv2)
    {
        _accrochageNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiv2;
    }

    // Méthode plublic
    public void AugmenterPointage()
    {
        Pointage++;
    }
}
