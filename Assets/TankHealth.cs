using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int hp=100;
    public GameObject tankExposion;
    public AudioClip tankExposionAudio;
    public Slider hpSlider;
    private int totalHp;
    // Start is called before the first frame update
    void Start()
    {
        totalHp=hp;    
        hpSlider.value=(float)hp/totalHp;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void TakeDamage(){
        if(hp<=0) return;
        hp-=Random.Range(10,20);
        hpSlider.value=(float)hp/totalHp;
        if(hp<=0){
            AudioSource.PlayClipAtPoint(tankExposionAudio,transform.position);
            GameObject.Instantiate(tankExposion,transform.position+Vector3.up,transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
