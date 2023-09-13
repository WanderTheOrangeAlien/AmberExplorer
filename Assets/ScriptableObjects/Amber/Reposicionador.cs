using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Reposicionador : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Range(0f,1f)] [SerializeField] private float moverYVelocity;
    void Start(){
        StartCoroutine(waitFrames());
    }

    IEnumerator waitFrames(){
        for(int i = 0; i < 2; ++i){
            yield return null;
            Reposicionar();
        }
    }

    void Reposicionar(){
        float x1 = transform.parent.position.x;
        float x2 = player.position.x;
        float z1 = transform.parent.position.z;
        float z2 = player.position.z;
        transform.position += new Vector3(x1-x2, 0, z1-z2);
        transform.eulerAngles += new Vector3(0, transform.parent.eulerAngles.y-player.eulerAngles.y, 0);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Reposicionar();
            Reposicionar();
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.position += Vector3.up*moverYVelocity;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.position += Vector3.down*moverYVelocity;
        }
    }
}
