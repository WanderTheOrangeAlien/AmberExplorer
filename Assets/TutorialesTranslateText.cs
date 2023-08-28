using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialesTranslateText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        if (Settings.Instance.language == Language.Espanol)
        {
            if (textComponent != null && textComponent.name == "Head Title")
            {
                textComponent.text = "Tutoriales";
            }
            else if (textComponent != null && textComponent.name == "Herramientas texto")
            {
                textComponent.text = "Herramientas";
            }
            else if (textComponent != null && textComponent.name == "Controles texto")
            {
                textComponent.text = "Controles";
            }
            else if (textComponent != null && textComponent.name == "Seguridad texto")
            {
                textComponent.text = "Seguridad";
            }

        }
        else
        {
            if (textComponent != null && textComponent.name == "Head Title")
            {
                textComponent.text = "Tutorials";
            }
            else if (textComponent != null && textComponent.name == "Herramientas texto")
            {
                textComponent.text = "Tools";
            }
            else if (textComponent != null && textComponent.name == "Controles texto")
            {
                textComponent.text = "Controls";
            }
            else if (textComponent != null && textComponent.name == "Seguridad texto")
            {
                textComponent.text = "Security";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
