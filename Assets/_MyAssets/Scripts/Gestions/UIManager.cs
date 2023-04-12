using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    [SerializeField] private GameObject _player = default;
    private bool _enPause;
    private Vector3 _position;
    private GestionJeu _gestionJeu;
    private bool _passe = true;



    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _position = _player.transform.position;
        _txtAccrochages.text = "Accrochages : " + _gestionJeu.Pointage;
        float temps = Time.time - _gestionJeu.TempsDepart;
        _txtTemps.text = "Temps : " + (temps - _gestionJeu.TempsAffiche).ToString("f2");
        Time.timeScale = 1;
        _enPause = false;
    }


    private void Update()
    {
        float temps = Time.time - _gestionJeu.TempsDepart;

        if (_position != _player.transform.position)
        {
            if (_passe)
            {
                _gestionJeu.TempsAffiche += Time.timeSinceLevelLoad;
                _passe = false;
            }
            _txtTemps.text = "Temps : " + (temps - _gestionJeu.TempsAffiche).ToString("f2");
        }


        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void ChangerPointage(int p_pointage)
    {
        _txtAccrochages.text = "Accrochages : " + p_pointage.ToString();
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }
}
