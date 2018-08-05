using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SpawnGround : MonoBehaviour
{
    [System.Serializable]
    public enum Tool
    {
        Height,
        HeightSet,
        Paint1,
        Paint2,
        Paint3,
        Decal
    }

    public GameObject block;
    public GameObject gizmo;
    public ParticleSystem decal;
    public Transform parent;
    public float speed;
    public int gridSize;
    float timer;

    public float opacity;
    public float range;

    [Range(0, 1)]
    public float spread;

    public float maxHeight;
    public Vector3 scrollOffset;
    public Vector3 angledView;
    public float angle;
    public float targetAngle;
    public float scrollMulti;
    public float snap;

    Camera cam;
    Vector3 pos;

    [SerializeField]
    public Tool tool;

    public float snowHeight;
    public float lowerHeight;

    RaycastHit hit;

    bool topView;

    Vector3 gizmoOffset;


    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GameObject obj = Instantiate(block, new Vector3(j, 0, gridSize - i), transform.rotation, parent);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, scrollOffset, 0.1f);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(targetAngle, 0, 0), 0.1f);


        timer -= Time.deltaTime;
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            gizmoOffset = hit.point;
            HeightUpdate();
            gizmo.transform.position = gizmoOffset;
            gizmo.transform.localScale = new Vector3(range * 2, (gizmoOffset.y * 2) - 5, range * 2);
            if (!EventSystem.current.IsPointerOverGameObject())
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //  if (timer < 0)
                    {
                        timer = 0.1f;
                        Collider[] col = Physics.OverlapCapsule(hit.point - Vector3.up * 10, hit.point + Vector3.up * 10, range);

                        switch (tool)
                        {
                            case Tool.Height:
                                if (Input.GetKey(KeyCode.LeftShift))
                                    for (int i = 0; i < col.Length; i++)
                                    {
                                        Lower(col[i].transform, hit.point);
                                    }
                                else
                                    for (int i = 0; i < col.Length; i++)
                                    {
                                        Raise(col[i].transform, hit.point);
                                    }
                                break;
                            case Tool.HeightSet:
                                for (int i = 0; i < col.Length; i++)
                                {
                                    Raise(col[i].transform, hit.point);
                                }
                                break;
                            case Tool.Paint1:
                                for (int i = 0; i < col.Length; i++)
                                {
                                    col[i].GetComponent<FloorBlock>().SetColor(Color.red);
                                }
                                break;
                            case Tool.Paint2:
                                for (int i = 0; i < col.Length; i++)
                                {
                                    col[i].GetComponent<FloorBlock>().SetColor(Color.green);
                                }
                                break;
                            case Tool.Paint3:
                                for (int i = 0; i < col.Length; i++)
                                {
                                    col[i].GetComponent<FloorBlock>().SetColor(Color.blue);
                                }
                                break;


                        }
                    }
                }
        }


        scrollMulti -= Input.GetAxis("Mouse ScrollWheel");
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, scrollOffset * scrollMulti, 0.1f);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += movement * speed * Time.deltaTime;


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                pos = parent.GetChild(i).position;
                pos.y /= snap;
                pos.y = Mathf.Round(pos.y) * snap;
                parent.GetChild(i).position = pos;
            }
        }
    }
    public void SetTool(Tool setTool)
    {
        tool = setTool;
    }
    public void SetTool(int setTool)
    {
        tool = (Tool)setTool;
    }

    void HeightUpdate()
    {
        Collider[] col = Physics.OverlapCapsule(hit.point - Vector3.up * 10, hit.point + Vector3.up * 10, range);
        float lowest = maxHeight;
        float highest = 0;
        float currentVal = 0;
        for (int i = 0; i < col.Length; i++)
        {
            currentVal = col[i].transform.position.y;
            if (currentVal < lowest)
                lowest = currentVal;
            if (currentVal > highest)
                highest = currentVal;
        }

        gizmoOffset.y = (Mathf.Max(1, highest - lowest) + 5) / 2;



    }

    public void Generate(InputField inputField)
    {

        Vector3 pos = Vector3.zero;
        Transform child = null;
        for (int i = 0; i < parent.childCount; i++)
        {
            child = parent.GetChild(i).transform;
            pos = child.position;
            pos.y = Mathf.PerlinNoise((pos.x + float.Parse(inputField.text)) / maxHeight, (pos.z + float.Parse(inputField.text)) / maxHeight) * maxHeight;
            child.position = pos;

            if (pos.y > snowHeight)
                child.GetComponent<FloorBlock>().SetColor(Color.green);
            else if (pos.y < lowerHeight)
                child.GetComponent<FloorBlock>().SetColor(Color.blue);
            else
                child.GetComponent<FloorBlock>().SetColor(Color.red);
        }
    }
    public void Raise(Transform tran, Vector3 centre)
    {
        pos = tran.position;
        if (pos.y < maxHeight)
        {
            pos.y += opacity / Vector3.Distance(tran.position, centre) * spread;
        }
        pos.y = Mathf.Clamp(pos.y, 0, maxHeight);
        tran.position = pos;
    }

    public void Lower(Transform tran, Vector3 centre)
    {
        pos = tran.position;
        if (pos.y > 0)
        {
            pos.y -= opacity / Vector3.Distance(tran.position, centre) * spread;
        }
        pos.y = Mathf.Clamp(pos.y, 0, maxHeight);
        tran.position = pos;
    }

    public void ChangeView()
    {
        if (topView)
        {
            topView = false;
            targetAngle = angle;
            scrollOffset = angledView;

        }
        else
        {
            topView = true;
            targetAngle = 90;
            scrollOffset = Vector3.up * angledView.y;
        }
    }

    public void UpdateRange(Slider slider)
    {
        range = Mathf.Round(slider.value / 0.01f) * 0.01f;
        gizmo.transform.localScale = new Vector3(range * 2, 2, range * 2);
        slider.transform.parent.GetChild(0).GetComponent<Text>().text = "Range: " + range;
    }
    public void UpdateOppacity(Slider slider)
    {
        opacity = Mathf.Round(slider.value / 0.01f) * 0.01f;

        slider.transform.parent.GetChild(0).GetComponent<Text>().text = "Opacity: " + opacity;
    }


    public void Decal()
    {

    }

}
