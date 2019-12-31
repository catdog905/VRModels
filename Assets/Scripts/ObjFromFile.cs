using Dummiesman;
using System.IO;
using UnityEngine;

public class ObjFromFile : MonoBehaviour
{
    string objPath = string.Empty;
    string error = string.Empty;
    GameObject loadedObject;

    void OnGUI() {
        objPath = GUI.TextField(new Rect(0, 0, 256, 32), objPath);

        GUI.Label(new Rect(0, 0, 256, 32), "");
        if(GUI.Button(new Rect(256, 32, 64, 32), "Load File"))
        {
            //file path
            if (!File.Exists(objPath))
            {
                error = "File doesn't exist.";
            }else{
                if(loadedObject != null)            
                    Destroy(loadedObject);
                loadedObject = new OBJLoader().Load(objPath);
                loadedObject.transform.Translate(-100, 2, 0);
                loadedObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                loadedObject.transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
                for (int i = 0; i < loadedObject.transform.childCount; i++)
                {
                    GameObject child = loadedObject.transform.GetChild(i).gameObject;
                    _ = child.AddComponent<MeshCollider>() as MeshCollider;
                }
                error = string.Empty;
            }
        }

        if(!string.IsNullOrWhiteSpace(error))
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(0, 64, 256 + 64, 32), error);
            GUI.color = Color.white;
        }

    }
}
