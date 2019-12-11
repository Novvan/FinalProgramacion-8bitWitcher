using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private FillerHandler Health;
    [SerializeField] private FillerHandler Stamina;
    [SerializeField] private Image signHolder;
    [SerializeField] public Sprite[] sign;

    public float InitHealth;
    private float CurrentHealth;
    public float InitStamina;
    private float currentStamina;
    private PlayerMovement pm;
    private Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        Health.Initialize(InitHealth, InitHealth);
        Stamina.Initialize(InitStamina, InitStamina);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && pm.currentState != PlayerState.quen)
        {
            StartCoroutine(Quen());
            Stamina.MyCurrentValue -= 5;
        }

        if (Input.GetKeyDown(KeyCode.J) && pm.currentState != PlayerState.igni)
        {
            StartCoroutine(Igni());
            Stamina.MyCurrentValue -= 5;
        }

        if (Input.GetKeyDown(KeyCode.K) && pm.currentState != PlayerState.aard)
        {
            StartCoroutine(Aard());
            Stamina.MyCurrentValue -= 5;
        }

        if (Input.GetKeyDown(KeyCode.L) && pm.currentState != PlayerState.yrden)
        {
            StartCoroutine(Yrden());
            Stamina.MyCurrentValue -= 5;
        }

        if (Input.GetButtonDown("attack") && pm.currentState != PlayerState.attack)
        {
            StartCoroutine(BasicAttack());
            Stamina.MyCurrentValue -= 5;
        }
    }


    //Corrutinas

    private IEnumerator BasicAttack()
    {
        Animator.SetBool("isAttacking", true);
        pm.currentState = PlayerState.attack;
        yield return null;
        Animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.3f);
        pm.currentState = PlayerState.walk;
    }

    private IEnumerator Quen()
    {
        Animator.SetBool("quen", true);
        pm.currentState = PlayerState.quen;
        yield return null;
        Animator.SetBool("quen", false);
        yield return new WaitForSeconds(.3f);
        signHolder.sprite = sign.ElementAt(2);
        pm.currentState = PlayerState.walk;
    }

    private IEnumerator Igni()
    {
        Animator.SetBool("igni", true);
        pm.currentState = PlayerState.igni;
        yield return null;
        Animator.SetBool("igni", false);
        yield return new WaitForSeconds(.3f);
        signHolder.sprite = sign.ElementAt(0);
        pm.currentState = PlayerState.walk;
    }

    private IEnumerator Aard()
    {
        Animator.SetBool("aard", true);
        pm.currentState = PlayerState.aard;
        yield return null;
        Animator.SetBool("aard", false);
        yield return new WaitForSeconds(.3f);
        signHolder.sprite = sign.ElementAt(1);
        pm.currentState = PlayerState.walk;
    }

    private IEnumerator Yrden()
    {
        Animator.SetBool("yrden", true);
        pm.currentState = PlayerState.yrden;
        yield return null;
        Animator.SetBool("yrden", false);
        yield return new WaitForSeconds(.3f);
        signHolder.sprite = sign.ElementAt(3);
        pm.currentState = PlayerState.walk;
    }
}