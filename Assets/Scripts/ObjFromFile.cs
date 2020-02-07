using Dummiesman;
using System.IO;
using UnityEngine;
using SFB;

public class ObjFromFile : MonoBehaviour
{
    string objPath = string.Empty;
    string error = string.Empty;
    GameObject loadedObject;

    void OnGUI() {

       
        if(GUI.Button(new Rect(0, 0, 64, 32), "Load File"))
        {
            //file path
            var extensions = new[] {
                new ExtensionFilter("Model files", "obj" ),
                new ExtensionFilter("All Files", "*" ),
            };
            objPath = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true)[0];
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
