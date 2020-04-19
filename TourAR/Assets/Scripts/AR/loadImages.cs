using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadImages : MonoBehaviour
{
    Image imageComponent;

    //[SerializeField] Sprite imageSprite;
    int imgLoadedHeight = 0;

    int imgLoadedWidth = 0;

    public static List<Sprite> images = new List<Sprite>();

    public List<string> imageNames = new List<string>(); //DO NOT MODIFY

    public static int imageIndex = 0;

    public static int prev_imageIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>(); // gets the image component attached to this gameobject
        imageNames = loadTourStops.imageNames; // uses same memory as loadTourStops list
        clearImages();
        addImages();
        loadSprite();

        //imageSprite = GetComponent<Image>().sprite;
        //for each name in loadTourStops.imageNames
        //no file type needed
        //imageNames.Add("horseshoe_old");
        //imageNames.Add("horseshoe_new");

        /*    //print image names
      Debug.Log("ImageNames: ");
      int index=0;
      foreach (string imageName in imageNames) {
        Debug.Log(imageNames[index]);
        index++;
      }
      */
    }

    // Update is called once per frame
    void Update()
    {
        if (imageIndex != prev_imageIndex)
        {
            loadSprite();
            prev_imageIndex = imageIndex;
        }
    }

    void loadSprite()
    {
        Debug.Log("_index: " + imageIndex);
        imageComponent.sprite = images[imageIndex];
        Debug.Log("load image" + images[imageIndex].name);
        //Debug.Log("Its dimensions are- height: "+ +"width:"+ )
    }

    void clearImages()
    {
        for (int i = images.Count - 1; i >= 0; i--)
        {
            images.RemoveAt (i);
        }
    }

    void addImages()
    {
        foreach (string imageName in imageNames)
        {
            images.Add(Resources.Load<Sprite>("Sprites/" + imageName)); //need to make sure name is valid
        }
    }
}
