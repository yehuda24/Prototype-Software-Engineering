using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyer : MonoBehaviour
{
   public void DestroyObject(GameObject go)
    {
        Destroy(go);
    }
}
