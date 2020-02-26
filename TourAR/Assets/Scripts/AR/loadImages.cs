using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadImages : MonoBehaviour
{

    [SerializeField] Sprite imageComp;
    int imgLoadedHeight = 0;
    int imgLoadedWidth = 0;
    public static List<Sprite> images = new List<Sprite>();
    public static List<string> imageNames = new List<string>();

    public static int imageIndex=0;
    public static int prev_imageIndex=0;


    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
      imageComp = GetComponent<Image>().sprite;

      //for each name in loadTourStops.imageNames
      //no file type needed
      imageNames.Add("horseshoe_new");
      imageNames.Add("horseshoe_old");

      Debug.Log("ImageNames: ");
      int index=0;
      foreach (string imageName in imageNames) {
        Debug.Log(imageNames[index]);
        index++;

      }

      foreach (string imageName in imageNames) {

        //bool exists = imageNames.Contains(imageName);
        //if (!exists) {
          images.Add(Resources.Load <Sprite>("Sprites/"+imageName));
          Debug.Log("Added "+imageName+" to <sprite>images list");
        //}
      }


      /*
  		sprite = Resources.Load <Sprite>("Images/SampleSprite");

  		GameObject image = GameObject.Find ("Image");
  		image.GetComponent<Image>().sprite = sprite;
      */
    }

    // Update is called once per frame
    void Update()
    {
      if (imageIndex != prev_imageIndex) {
        loadSprite();
        prev_imageIndex = imageIndex;
      }
    }

    void loadSprite() {
      Debug.Log("index"+imageIndex);
      imageComp = images[imageIndex];
      Debug.Log("load image"+images[imageIndex].name);
      //Debug.Log("Its dimensions are- height: "+ +"width:"+ )
      //fade animation?
    }
}
