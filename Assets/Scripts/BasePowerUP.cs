using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasePowerUP : MonoBehaviour
{
    protected float powerupduration = 10f;
    protected string poweruptext;
    private bool coopiseaten = false;
    private bool iseffectover = false;
    private bool iseaten = false; // will be used in other classes to set up the effects
    protected void ApplyEffect(string text)
    {
        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        SpawnPowerUps.Instance.PowerUpPanel.text = text;
        iseaten = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    protected void CoopApplyEffect(string text)
    {
        SoundController.Instance.PlaySound(Sounds.PowerUpSound);
        SpawnPowerUps.Instance.CoopPowerUpPanel.text = text;
        coopiseaten = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }  
    protected virtual void RemoveEffect()
    {
        iseffectover = true;
    }

    public bool Getiseaten()
    {
        return iseaten;
    }
    public bool Getcoopiseaten()
    {
        return coopiseaten;
    }
    public bool Getiseffectover()
    {
        return iseffectover;
    }
}
