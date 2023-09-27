using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Renderer))]
public class SceneTransition : MonoBehaviour
{
    public Color fadeColor;
    public float fadeDuration;
    public string targetScene;
    private Renderer solidColor;

    //public float DEBUG_alpha;
    // Start is called before the first frame update

    public delegate void SceneTransitionFunc(float duration, string scene);
    public static event SceneTransitionFunc OnSceneTransition;

    void Start()
    {

        //Get the SolidColor Object
        solidColor = GetComponent<Renderer>();

        if (solidColor == null) Debug.LogError("Culd not find the required GameObject called \"SolidColor\". Did you change the name? >:[");
        fadeColor.a = 1;

        Fade(1, 0, fadeDuration, false);

        //fadeColor.a = 0;
        SceneTransition.OnSceneTransition += ChangeScene;

        
    }

    // Update is called once per frame
    void Update()
    {
        //DEGUG: TO TEST IN NON VR
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeScene(fadeDuration, targetScene);
        }
    }

    public void ChangeScene(float duration, string scene)
    {
        Debug.Log($"{gameObject.name}: Chaging scene, duration = {duration}");
        Fade(0, 1, duration, true);

        //SceneManager.LoadScene(targetScene);
    }

    public void Fade(float alphaIn, float alphaOut, float duration, bool changeScene)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut, duration,changeScene));   
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut, float duration, bool changeScene)
    {
        float timer = 0;
        Color newColor = fadeColor;

        while (timer <= duration)
        {
            timer += Time.deltaTime;
            newColor.a = SmoothFunction(Mathf.Lerp(alphaIn, alphaOut, timer / duration));
            solidColor.material.SetColor("_Color", newColor);

            yield return null;
        }

        
        newColor.a = alphaOut;
        solidColor.material.SetColor("_Color", newColor);

        if (changeScene)
        {
            SceneManager.LoadScene(targetScene);
        }
            
    }

    private float SmoothFunction(float t)
    {
        return Mathf.Sin(2 * (t - 0.2f)) + 0.1f;
    }
}
