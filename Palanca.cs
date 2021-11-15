using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Animator AbrirBoca;
    public BoxCollider stopUI;
    public void activarPalanca()
    {
        anim.SetBool("Palanca", true);
        AbrirBoca.SetBool("Llave", true);
    }
    public void FinishedAnim()
    {
        stopUI.enabled = false;
    }
    public void PlayMusic()
    {
        FindObjectOfType<AudioManager>().Play("Palanca");
    }
}