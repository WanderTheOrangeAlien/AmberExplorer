using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/ItemScriptableObject", order = 1)]
public class Item : ScriptableObject
{
    public string id;
    public NamesByLanguage names; //The name changes with the language, but the ID does not   
    public Texture texture;

    public Item(string id, NamesByLanguage names, Texture texture)
    {
        this.id = id;
        this.names = names;
        this.texture = texture;
    }

    public string getName()
    {
        switch (GlobalSettings.Instance.language)
        {
            case Language.English: 
                return names.English;
            case Language.Espanol: 
                return names.Espanol;
            default: 
                Debug.LogError("Language has an invalid value!");                
                break;
        }

        return names.English;
    }

    public Item NoItem()
    {
        return new Item("no_item",
            new NamesByLanguage
            {
                English = "NoItem",
                Espanol = "NoItem"
            }, 
            null
            );
    }
}

[System.Serializable]
public struct NamesByLanguage
{
    public string Espanol;
    public string English;
}
