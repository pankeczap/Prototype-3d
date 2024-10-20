using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{

    [SerializeField] GameObject max;
    [SerializeField] GameObject evie;

    bool currentCharacter = false;

    private void Start()
    {
        SwapCharacter();
    }

    public void SwapCharacter()
    {
        currentCharacter = !currentCharacter;

        if (currentCharacter)
        {
            max.SetActive(true);
            evie.SetActive(false);
        }
        else
        {
            max.SetActive(false);
            evie.SetActive(true);

        }

    }




}
