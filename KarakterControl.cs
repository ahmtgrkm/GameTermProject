using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimasyonControlMerkezi;

public class KarakterControl : MonoBehaviour
{
    float inputX;      
    Animator Anim;
    Vector3 mevcutyon;
    Camera MainCam;
    float maksimumuzunluk=1;
    float rotationSpeed=20;
    float MaxSpeed;
    Animasyon animasyon = new Animasyon();
    
    float[] Sol_Yon_parametreleri = { 0.12f, 0.34f, 0.63f, 0.92f };
    float[] Sag_Yon_parametreleri = { 0.12f, 0.33f, 0.66f, 0.92f };
    float[] Egilme_Yon_parametreleri = { 0.2f, 0.35f, 0.40f, 0.45f,1f };

    void Start()
    {    

        Anim = GetComponent<Animator>();
        MainCam = Camera.main;
       
    }

    void LateUpdate()
    {
       
        animasyon.Karakter_hareket(Anim,"speed", maksimumuzunluk,1, 0.2f);
        animasyon.Karakter_Rotation(MainCam, rotationSpeed,gameObject);  
        animasyon.Sol_hareket(Anim,"Sol_hareket","Sol_aktifmi", animasyon.ParametreOlustur(Sol_Yon_parametreleri));
        animasyon.Sag_hareket(Anim, "Sag_hareket", "Sag_aktifmi", animasyon.ParametreOlustur(Sag_Yon_parametreleri));
        animasyon.Geri_hareket(Anim, "geriyuru");
        animasyon.Egilme_hareket(Anim, "Egilme_hareket", animasyon.ParametreOlustur(Egilme_Yon_parametreleri));
        
    }
  
}
