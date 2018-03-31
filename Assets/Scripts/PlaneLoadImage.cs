using UnityEngine;
using System.Collections;

public class PlaneLoadImage : MonoBehaviour {

    public Material frontPlane;
    public string imageFileName;

    void Start()
    {
        print("1");
        // Create the Plane
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        //myPlane = GetComponent<Plane>();

        // Load the Image from somewhere on disk
        //var filePath1 = "C:\\AlexYT\\Game01\\Assets\\Images\\1362_04_32.png";

        var filePath = "C:\\AlexYT\\Game01\\Assets\\Images\\" + imageFileName + ".png";
        if (System.IO.File.Exists(filePath))
        {
            print("2");
            // Image file exists - load bytes into texture
            var bytes = System.IO.File.ReadAllBytes(filePath);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(bytes);
            frontPlane.mainTexture = tex;

            // Apply to Plane
            //MeshRenderer mr = plane.GetComponent<MeshRenderer>();
            MeshRenderer mr = gameObject.GetComponentInChildren<MeshRenderer>();
            mr.material = frontPlane;
        }
    }

}
