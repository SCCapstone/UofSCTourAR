using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadImages : MonoBehaviour
{

    Sprite imageComp;
    int imgLoadedHeight = 0;
    int imgLoadedWidth = 0;
    public List<Sprite> images = new List<Sprite>();
    public List<string> imageNames = new List<string>();

    public static int imageIndex=0;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
      imageComp = GetComponent<SpriteRenderer>();

      //for each name in loadTourStops.imageNames
      //no file type needed
      imageNames.Add("horseshoe_new");
      imageNames.Add("horseshoe_old");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void imageToLoad() {
      imageComp = images[imageIndex];
    }
}
