using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimType : MonoBehaviour
{   


    public static bool noMenu=true;
    [SerializeField] bool dontInitialize = false;



    [SerializeField] Animator slidingMenu;
    Animator menu;

    [SerializeField] RuntimeAnimatorController menuStart, menuNoStart;

    // Start is called before the first frame update
    void Awake()
    {
        if (!dontInitialize) {
            menu = gameObject.GetComponent<Animator>();
            if (noMenu) {
                Debug.Log("noMenu");
                menu.runtimeAnimatorController = menuNoStart;
                noMenu = false;
            } else {
                menu.runtimeAnimatorController = menuStart;
            }
        }
        
    }

    public void setNoMenu() {
        if (!dontInitialize) {
            if (slidingMenu.GetBool("Pressed")) {
                noMenu=false;
            } else {
                noMenu = true;
            }
        } else {
            noMenu = true;
        }
    }
}
