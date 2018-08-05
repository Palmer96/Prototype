using UnityEngine;
using System.Collections;

public class VertexModify : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private Color[] colours;

    public float Speed;
    public int iColour;

    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        colours = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            colours[i] = Color.blue;
        }
        mesh.colors = colours;
        mesh.vertices = vertices;

        Debug.Log("Vertices" + mesh.vertices.Length);
        Debug.Log("Colors" + mesh.colors.Length);
        Debug.Log("Colors32" + mesh.colors32.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            iColour = 1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            iColour = 2;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            iColour = 3;

        if (Input.GetKeyDown(KeyCode.V))
            Save();

        if (Input.GetKeyDown(KeyCode.B))
            Load();
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);

                Vector3 point = hit.point;

                int count = 0;
                foreach (Vector3 vertex in mesh.vertices)
                {

                    if (Vector3.Distance(vertex, point) < 0.2f)
                    {
                        if (iColour == 1)
                            colours[count] = Color.red;
                        else if (iColour == 2)
                            colours[count] = Color.green;
                        else if (iColour == 3)
                            colours[count] = Color.blue;
                    }
                    count++;
                }
            }


            mesh.colors = colours;
            mesh.vertices = vertices;
        }
    }

    public void Save()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            PlayerPrefs.SetFloat("Colour" + i + "r", colours[i].r);
            PlayerPrefs.SetFloat("Colour" + i + "g", colours[i].g);
            PlayerPrefs.SetFloat("Colour" + i + "b", colours[i].b);

        }
    }

    public void Load()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            colours[i].r = PlayerPrefs.GetFloat("Colour" + i + "r");
            colours[i].g = PlayerPrefs.GetFloat("Colour" + i + "g");
            colours[i].b = PlayerPrefs.GetFloat("Colour" + i + "b");

        }

        mesh.colors = colours;
        mesh.vertices = vertices;
    }
}
