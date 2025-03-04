using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Naz;

public class GameManager : MonoBehaviour
{
    
   
   
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;


    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void AdamYonetimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                Matematiksel_islemler.Carpma(GelenSayi,Karakterler,Pozisyon,OlusmaEfektleri);
                break;
               
            case "Toplama":
                Matematiksel_islemler.Toplama(GelenSayi, Karakterler,Pozisyon,OlusmaEfektleri);

                break;

            case "Cikartma":
                Matematiksel_islemler.Cikartma(GelenSayi, Karakterler,YokOlmaEfektleri);

                break; 

        case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri);
                break;
        }

    }

    public void YokOlmaEfektiOlustur(Vector3 Pozisyon, bool Balyoz=false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position= Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                GameManager.AnlikKarakterSayisi--;
                break;
            }
        }
        if (Balyoz)
        {
            Vector3 yeniPoz = new Vector3(Pozisyon.x, -2.58f, Pozisyon.z);
            foreach (var item in AdamLekesiEfektleri) {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;                                 
                    break;
                }
            }
        }
    }

    }

