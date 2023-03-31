using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionFin : MonoBehaviour
{
    // Attributs

    private GestionJeu _temp;
    private Player _player;
    private float total;

    private void Start()
    {
        _temp = FindObjectOfType<GestionJeu>();
        _player = FindObjectOfType<Player>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
            if (collision.gameObject.tag == "Player")
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                switch (indexScene)
                {
                    case 0:
                        {
                            _temp.SetNiveau1(_temp.Pointage, Time.time);
                            SceneManager.LoadScene(indexScene + 1);

                        }
                        break;
                    case 1:
                        {
                            _temp.SetNiveau2(_temp.Pointage, Time.time);
                            SceneManager.LoadScene(indexScene + 1);
                        }
                        break;
                    case 2:
                        {
                            Debug.Log("*** Fin de la partie ***");


                            Debug.Log("*** Niveau 1 ***");
                            Debug.Log($"{_temp.TempsNiveau1.ToString("f2")} Secondes se sont écoulées");
                            Debug.Log($"Nombre d'accrochages {_temp.AccrochageNiveau1}");

                            Debug.Log("*** Niveau 2 ***");
                            _temp.TempsNiveau2 = _temp.TempsNiveau2 - _temp.TempsNiveau1;
                            _temp.AccrochageNiveau2 = _temp.AccrochageNiveau2 - _temp.AccrochageNiveau1;

                            Debug.Log($"{_temp.TempsNiveau2.ToString("f2")} Secondes se sont écoulées");
                            Debug.Log($"Nombre d'accrochages {_temp.AccrochageNiveau2}");

                            Debug.Log("*** Niveau 3 ***");
                            _temp.TempsNiveau3 = Time.time - _temp.TempsNiveau2 - _temp.TempsNiveau1;
                            _temp.AccrochageNiveau3 = _temp.Pointage - _temp.AccrochageNiveau2 - _temp.AccrochageNiveau1;

                            Debug.Log($"{_temp.TempsNiveau3.ToString("f2")} Secondes se sont écoulées");
                            Debug.Log($"Nombre d'accrochages {_temp.AccrochageNiveau3}");

                            Debug.Log("*** Total ***");
                            total = Time.time + _temp.Pointage;
                            Debug.Log($"{Time.time.ToString("f2")} Secondes se sont écoulées");
                            Debug.Log($"Nombre d'accrochages {_temp.Pointage}");
                            Debug.Log($"{total.ToString("f2")} Pts");

                        _player.FinPartie();
                    }
                        break;
                }
                
            }
    }
}
