using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;//máxima salud del enemigo
    public int currentHealth;
    public float sinkSpeed;//velocidad de hundimiento del enemigo
    public int scoreValue;//los puntos que va a dar al player una vez el enemigo haya sido destruido
    public bool isDead;

    public AudioClip deathClip;

    public ParticleSystem hitParticles;

    AudioSource audioS;
    Animator anim;
    bool isSinking;//para saber si el enemigo "se está hundiendo"

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isSinking == true)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    //Función público porque voy a llamar a esta función desde el script de disparo del player
    public void TakeDamage(int amount, Vector3 point)
    {
        //si el valor de la booleana isDead es true, me salgo de la función
        if (isDead) return;

        currentHealth -= amount;
        audioS.Play();

        //situo el sistema de partículas en el punto de impacto del raycast con el enemigo
        hitParticles.transform.position = point;
        hitParticles.Play();
        //currentHealth = currentHealth - amount;

        if (currentHealth <= 0) Death();
    }
    void Death()
    {
        audioS.clip = deathClip;
        audioS.Play();

        isDead = true;
        anim.SetTrigger("Death");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ScoreEnemy(scoreValue);
    }

    //método público que voy a llamar desde la animación de Death
    public void StartSinking()
    {
        isSinking = true;
        //Deshabilitando el componente NavMeshAgent
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2);
    }
 
}
