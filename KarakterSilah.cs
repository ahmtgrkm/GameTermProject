using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarakterSilah : MonoBehaviour
{
    [Header("AYARLAR")]
    float AtesEtmeSikligi_1;
    public float AtesEtmeSikligi_2;
    public float menzil;
    int ToplamMermiSayisi = 1000;
    int SarjorKapasitesi = 50;
    int KalanMermi;
    float DarbeGucu = 30;
    public TextMeshProUGUI ToplamMermi_text;
    public TextMeshProUGUI KalanMermi_text;

    [Header("SESLER")]
    public AudioSource[] Sesler;
    [Header("EFEKTLER")]
    public ParticleSystem[] Efektler;
    

    [Header("GENEL İSLEMLER")]
    public Camera BenimKameram;
    public Animator KarakterinAnimatoru;

    void Start()
    {
        KalanMermi = SarjorKapasitesi;
        ToplamMermi_text.text = ToplamMermiSayisi.ToString();
        KalanMermi_text.text = KalanMermi.ToString();

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ReloadKontrol();

        }
        if (KarakterinAnimatoru.GetBool("reload"))
        {
            ReloadislemiTeknikFonksiyon();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > AtesEtmeSikligi_1 && KalanMermi != 0)
            {
                AtesEt();
                AtesEtmeSikligi_1 = Time.time + AtesEtmeSikligi_2;

            }
            if (KalanMermi == 0)
            {

                Sesler[1].Play();
            }


        }
    }



    void AtesEt()
    {

        KalanMermi--;
        KalanMermi_text.text = KalanMermi.ToString();
        Efektler[0].Play();
        Sesler[0].Play();
        KarakterinAnimatoru.Play("Egilme_ates_etme");
        RaycastHit hit;
        if (Physics.Raycast(BenimKameram.transform.position, BenimKameram.transform.forward, out hit, menzil))
        {

            Instantiate(Efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.transform.gameObject.name);

        }

    }

    void ReloadKontrol()
    {
        if (KalanMermi < SarjorKapasitesi && ToplamMermiSayisi != 0)
        {
            KarakterinAnimatoru.Play("sarjordegistir");
            
             if(!Sesler[2].isPlaying)
                Sesler[2].Play();
        }

    }

    void ReloadislemiTeknikFonksiyon()
    {
        if (KalanMermi == 0) 
        {

            if (ToplamMermiSayisi <= SarjorKapasitesi)
            {
               

                KalanMermi = ToplamMermiSayisi;
                
                ToplamMermiSayisi = 0;

            }
            else
            {
                ToplamMermiSayisi -= SarjorKapasitesi;
                KalanMermi = SarjorKapasitesi;

            }


        }
        else 
        {
           

            if (ToplamMermiSayisi <= SarjorKapasitesi)
            {
                int OlusanDeger = KalanMermi + ToplamMermiSayisi;
                
                if (OlusanDeger > SarjorKapasitesi)
                {
                    KalanMermi = SarjorKapasitesi;
                    ToplamMermiSayisi = OlusanDeger - SarjorKapasitesi;
                    

                }
                else
                {

                    KalanMermi += ToplamMermiSayisi; 
                    ToplamMermiSayisi = 0;
                }



            }
            else
            {
                int MevcutMermimiz = SarjorKapasitesi - KalanMermi;
                ToplamMermiSayisi -= MevcutMermimiz;
                KalanMermi = SarjorKapasitesi;

            }


        }
        ToplamMermi_text.text = ToplamMermiSayisi.ToString();
        KalanMermi_text.text = KalanMermi.ToString();

        KarakterinAnimatoru.SetBool("reload", false);

    }
}
