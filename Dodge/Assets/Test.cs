using UnityEngine;
using UnityEditor;

public class Test : EditorWindow
{
   [MenuItem("Window/Test")]
   static void init()
    {
        Test window = (Test)EditorWindow.GetWindow(typeof(Test));
        window.Show();
    }

    [System.Obsolete]
    void OnGUI()
    {
        Handles.color = Color.blue;
        Handles.DrawRectangle(0,new Vector3(200,200),Quaternion.identity,100);
        Handles.DrawSolidDisc(new Vector3(200, 200), Vector3.forward, 100); 
        Handles.DrawSolidDisc(new Vector3(150, 150), Vector3.forward, 50); 
        Handles.DrawSolidDisc(new Vector3(250, 150), Vector3.forward, 50); 
    }
}
