using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCartelLanguage : MonoBehaviour
{
    [SerializeField] private Sprite espanol;
    [SerializeField] private Sprite english;
    // Start is called before the first frame update
    void Start(){
        var settings = GameObject.FindObjectOfType<Settings>();
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if(settings.language == Language.Espanol){
            spriteRenderer.sprite = espanol;
        }else if(settings.language == Language.English){
            spriteRenderer.sprite = english;
        }
    }
}
