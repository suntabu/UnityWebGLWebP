using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebP;

public class TestWebP : MonoBehaviour
{
    void Start()
    {
        var bytes = Resources.Load<TextAsset>("patter046.webp").bytes;
        WebP.Error lError;
        var tex =
            WebP.Texture2DExt.CreateTexture2DFromWebP(bytes, lMipmaps: false, lLinear: true, lError: out lError);

        if (lError == WebP.Error.Success)
        {
            GetComponent<RawImage>().texture = tex;
        }
        else
        {
            Debug.LogError("Webp Load Error : " + lError.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}