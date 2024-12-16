using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * .5f * Time.deltaTime);
    }
    void Update()
    {
        if(Input.GetAxis("Mouse X")<0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Bolme"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AdamYonetimi(other.tag, sayi,other.transform);
          
        }
    }
}
