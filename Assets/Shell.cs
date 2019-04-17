using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject shellExplosionPrefab;
    public AudioClip shellExlosionAudio;
    public ParticleSystem m_explosionParticles;
    public LayerMask m_TankMask;
    public float m_ExplosionForce=1000f;
    public float m_MaxLifeTime=2f;
    public float m_ExplosionRadius=5f;
    public float m_MaxDamage=100f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        Collider[] colliders=Physics.OverlapSphere(transform.position,m_ExplosionRadius,m_TankMask);

        for(int i=0;i<colliders.Length;i++){
            Rigidbody targetRigidbody=colliders[i].GetComponent<Rigidbody>();

            if(!targetRigidbody)
                continue;
            
            targetRigidbody.AddExplosionForce(m_ExplosionForce,transform.position,m_ExplosionRadius);

            TankHealth targetHealth=targetRigidbody.GetComponent<TankHealth>();

            if(!targetHealth){
                continue;
            }

            float damage =CalculateDamage(targetRigidbody.position);

            targetHealth.TakeDamage(damage);
        }

        m_explosionParticles.transform.parent=null;

        m_explosionParticles.Play();

        AudioSource.PlayClipAtPoint(shellExlosionAudio,transform.position);

        Destroy(m_explosionParticles.gameObject,m_explosionParticles.duration);

        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);

    }

    private float CalculateDamage(Vector3 targetPosition){
        Vector3 exlosionToTarget=targetPosition-transform.position;

        float explosionDistance=exlosionToTarget.magnitude;

        float relativeDistance=(m_ExplosionRadius-explosionDistance)/m_ExplosionRadius;

        float damage=relativeDistance*m_MaxDamage;

        damage=Mathf.Max(0f,damage);

        return damage;
    }
}
