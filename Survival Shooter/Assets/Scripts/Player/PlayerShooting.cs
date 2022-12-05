using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot;//daño por disparo que va a hacer el player
    public float timeBetweenBullets;//tiempo entre disparos
    public float range;//longitud del raycast, que realmente significa hasta que distancia puede disparar el player
    public LayerMask shootableMask;//capa de objetos a la que vamos a poder disparar

    float timer;//variable que voy a usar de contador de tiempo
    Ray ray;
    RaycastHit hit;
    LineRenderer lineRenderer;
    AudioSource audioS;
    Light gunLight;
    float effectsDisplayTime = 0.2f;//variable que va a determinar cuando tiempo van a estar los efectos en pantalla
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;//contador de tiempo
        
        if(Input.GetMouseButtonDown(0) && timer >= timeBetweenBullets)
        {
            Shoot();
        }
        //Deshabilitamos los efectos
        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            lineRenderer.enabled = false;
            gunLight.enabled = false;
        }
    }
    void Shoot()
    {
        timer = 0;

        audioS.Play();

        //habilitamos el componente LineRenderer y la point light
        lineRenderer.enabled = true;
        gunLight.enabled = true;
        //Establezco el primer punto del LineRenderer
        lineRenderer.SetPosition(0, transform.position);


        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out hit, range, shootableMask))
        {
            //me guardo en una variable (local) el gameobject con el que estoy chocando
            GameObject _object = hit.collider.gameObject;
            //compruebo si ese gameobject es el enemigo
            if(_object.GetComponent<EnemyHealth>())
            {
                _object.GetComponent<EnemyHealth>().TakeDamage(damagePerShot, hit.point);
            }

            //Estoy estableciendo el segundo punto del LineRenderer
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            //Estoy estableciendo el segundo punto del lineRenderer a una distancia range desde el origen del
            //raycast
            lineRenderer.SetPosition(1, ray.origin + (ray.direction * range));
        }
    }
}
