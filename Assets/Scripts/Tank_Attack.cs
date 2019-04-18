using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Attack : MonoBehaviour
{

    public GameObject shellPrefab;
    public KeyCode fireKey = KeyCode.Space;
    public float shellSpeed = 20;
    public int bulletCount=20;
    public AudioClip ShootAudio;
    public GameObject camera;

    private Transform firePosition;
    // Start is called before the first frame update
    void Start()
    {
        firePosition = transform.Find("FirePosition");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            AudioSource.PlayClipAtPoint(ShootAudio,camera.transform.position,100f);
            GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
        }
    }
}
