using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TV : MonoBehaviour
{

    private Material tvMaterial;

    private WebCamTexture webCamTexture;

    private string path = "C:\\Users\\Usuario\\Documents\\Documentos\\Documentos de Raimon\\Trabajos-clases\\Universidad\\Cuarto año\\Primer Cuatrimestre\\II\\";

    int captureCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        webCamTexture = new WebCamTexture();
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);
        tvMaterial = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            tvMaterial.mainTexture = webCamTexture; 
            webCamTexture.Play(); 
        }
        if (Input.GetKey("p")) { webCamTexture.Pause(); }
        if (Input.GetKeyDown("x")) { 
            Texture2D snapshot = new Texture2D(webCamTexture.width, webCamTexture.height);
            snapshot.SetPixels(webCamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(path + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
         }
    }
}