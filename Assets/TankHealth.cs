using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float hp=100f;
    public GameObject tankExposion;
    public AudioClip tankExposionAudio;
    public Slider hpSlider;
    private float totalHp;
    // Start is called before the first frame update
    void Start()
    {
        totalHp=hp;    
        hpSlider.value=hp/totalHp;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void TakeDamage(float damage){
        if(hp<=0) return;
        hp-=damage;
        hpSlider.value=hp/totalHp;
        if(hp<=0){
            AudioSource.PlayClipAtPoint(tankExposionAudio,transform.position);
            GameObject.Instantiate(tankExposion,transform.position+Vector3.up,transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
