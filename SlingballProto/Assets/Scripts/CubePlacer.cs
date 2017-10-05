using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour {

    public int minHeight;
    public int maxHeight;
    public int minWidth;
    public int maxWidth;
    public int minLength;
    public int maxLength;
    public int interval;

    public float lineWidth = .1f;

    public Transform cube;

    // Use this for initialization
    void Start() {

        for (int i = minHeight; i < maxHeight; i += interval)
        {
            for (int j = minWidth; j < maxWidth; j += interval)
            {
                for (int k = minLength; k < maxLength; k += interval)
                {
                    Instantiate(cube, new Vector3(i, j, k), Quaternion.identity);
                }
            }
        }

        for (int j = minLength; j < maxLength; j += interval)
        { 
            for (int i = minHeight; i < maxHeight; i+=interval)
            {
                GameObject lineObj = new GameObject();
                LineRenderer line = lineObj.AddComponent<LineRenderer>();
                line.receiveShadows = false;
                line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                line.startWidth = lineWidth;
                line.endWidth = lineWidth;
                Vector3[] pos = new Vector3[2];
                pos[0] = new Vector3(j, minWidth, i);
                pos[1] = new Vector3(j, maxWidth, i);
                line.SetPositions(pos);
            }

            for (int i = minWidth; i < maxWidth; i+=interval)
            {
                GameObject lineObj = new GameObject();
                LineRenderer line = lineObj.AddComponent<LineRenderer>();
                line.receiveShadows = false;
                line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                line.startWidth = lineWidth;
                line.endWidth = lineWidth;
                Vector3[] pos = new Vector3[2];
                pos[0] = new Vector3(j, i, minHeight);
                pos[1] = new Vector3(j, i, maxHeight);
                line.SetPositions(pos);
            }
        }

        for (int j = minWidth; j < maxWidth; j += interval)
        {
            for (int i = minHeight; i < maxHeight; i += interval)
            {
                GameObject lineObj = new GameObject();
                LineRenderer line = lineObj.AddComponent<LineRenderer>();
                line.receiveShadows = false;
                line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                line.startWidth = lineWidth;
                line.endWidth = lineWidth;
                Vector3[] pos = new Vector3[2];
                pos[0] = new Vector3(minLength, j, i);
                pos[1] = new Vector3(maxLength, j, i);
                line.SetPositions(pos);
            }

            for (int i = minLength; i < maxLength; i += interval)
            {
                GameObject lineObj = new GameObject();
                LineRenderer line = lineObj.AddComponent<LineRenderer>();
                line.receiveShadows = false;
                line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                line.startWidth = lineWidth;
                line.endWidth = lineWidth;
                Vector3[] pos = new Vector3[2];
                pos[0] = new Vector3(i, j, minHeight);
                pos[1] = new Vector3(i, j, maxHeight);
                line.SetPositions(pos);
            }
        }


    }
	

}
