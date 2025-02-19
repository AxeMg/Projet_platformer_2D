using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;

public class BossManager : MonoBehaviour
{

    public Animator porteHaut;
    public Animator porteBas;
    [SerializeField] private bool isOpen = false;

    [SerializeField] PlayableDirector bossFight;

    public TriggerDeath death;
    public LaserGunBossFight laser;

    public TimerBoss timer;

    public AudioSource music;
    public AudioSource musicBoss;

    public Light2D lightPorte;
    public Animator animatorBoss;

    // Start is called before the first frame update
    void Start()
    {

        porteBas.enabled = false;
        porteHaut.enabled = false;
        lightPorte.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(death.isDead == true)
        {
            timer.ResetTimer();
            bossFight.time = 0;
            bossFight.Stop();
            bossFight.Evaluate();
        }
    }

    public void OuverturePorte()
    {
        isOpen = true;
        animatorBoss.SetBool("Dead", true);
        lightPorte.enabled = true;
        porteBas.enabled = true;
        porteHaut.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bossFight.Play();
        music.Stop();
        musicBoss.Play();
    }


}
