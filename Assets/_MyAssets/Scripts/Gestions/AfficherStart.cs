using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfficherStart : MonoBehaviour
{
    [SerializeField] private GameObject _Instruction = default;
    
    public void Instruction()
    {
        _Instruction.SetActive(true);
    }

    public void Retour()
    {
        _Instruction.SetActive(false);
    }
}
