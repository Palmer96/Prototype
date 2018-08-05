using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBlock : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private Color[] colours;

    private Mesh childMesh;
    private Vector3[] childVertices;
    private Color[] childColours;


    Vector3 pos;
    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        colours = new Color[mesh.vertices.Length];
     
        for (int i = 0; i < colours.Length; i++)
        {
            colours[i] = Color.blue;
        }
        mesh.colors = colours;
     
     
        childMesh = transform.GetChild(0).GetComponent<MeshFilter>().mesh;
        childColours = new Color[childMesh.vertices.Length];
     
        for (int i = 0; i < childColours.Length; i++)
        {
            childColours[i] = Color.blue;
        }
        childMesh.colors = childColours;
    }
  //  public void Raise()
  //  {
  //      pos = transform.position;
  //      if (pos.y < 4)
  //      {
  //          pos.y++;
  //      }
  //      transform.position = pos;
  //  }
  //
  //  public void Lower()
  //  {
  //      pos = transform.position;
  //      if (pos.y > 0)
  //      {
  //          pos.y--;
  //      }
  //      transform.position = pos;
  //  }

    public void SetColor(Color color)
    {

        mesh = GetComponent<MeshFilter>().mesh; 
        colours = new Color[mesh.vertices.Length];

        for (int i = 0; i < colours.Length; i++)
        {
            colours[i] = color;
        }
        mesh.colors = colours;


        childMesh = transform.GetChild(0).GetComponent<MeshFilter>().mesh;
        childColours = new Color[childMesh.vertices.Length];

        for (int i = 0; i < childColours.Length; i++)
        {
            childColours[i] = color;
        }
        childMesh.colors = childColours;
    }


}
