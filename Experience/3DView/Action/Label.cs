using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Label : MonoBehaviour
{
    private static Label instance; 
    public static Label Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Label>(); 
            }
            return instance; 
        }
    }

    private int childCount;
    private GameObject activeObject;
    private bool isFirstCall = true;
    private float c = 7f;

    private List<GameObject> labelObjects = new List<GameObject>(); 

    public void CreateLabel()
    {
        
        activeObject = GameObjectManager.Instance.CurrentObject;
        Debug.Log("ACTIVE OBJECT: " + activeObject);
        childCount = activeObject.transform.childCount;

        // childCount = GameObjectManager.Instance.CurrentObject.transform.childCount;
        Debug.Log("NUMBER OF CHILD: " + childCount);
        for(int i = 0; i < childCount; i++)
        {
            GameObject childObject = activeObject.transform.GetChild(i).gameObject;
            GameObject labelObject = Instantiate(Resources.Load("Model/Lessons/LabelManager_1") as GameObject);
            labelObject.transform.SetParent(childObject.transform, false);
            SetLabel(childObject, labelObject, i%2 !=0);
            labelObjects.Add(labelObject); 
        }
    }

    public static Bounds GetRenderBounds(GameObject go)
    {
        var totalBounds = new Bounds();
        totalBounds.SetMinMax(Vector3.one * Mathf.Infinity, -Vector3.one * Mathf.Infinity);
        foreach (var renderer in go.GetComponentsInChildren<Renderer>()){
            var bounds = renderer.bounds;
            var totalMin = totalBounds.min;
            totalMin.x = Mathf.Min(totalMin.x, bounds.min.x);
            totalMin.y = Mathf.Min(totalMin.y, bounds.min.y);
            totalMin.z = Mathf.Min(totalMin.z, bounds.min.z);

            var totalMax = totalBounds.max;
            totalMax.x = Mathf.Max(totalMax.x, bounds.max.x);
            totalMax.y = Mathf.Max(totalMax.y, bounds.max.y);
            totalMax.z = Mathf.Max(totalMax.z, bounds.max.z);

            totalBounds.SetMinMax(totalMin, totalMax);
        }
        return totalBounds;
    }

    public void SetLabel(GameObject currentObject, GameObject label, bool isLeft)
    {
        GameObject line = label.transform.GetChild(0).gameObject; 
        GameObject labelName = label.transform.GetChild(1).gameObject;

        // labelName.transform.GetChild(0).gameObject.GetComponent<Text>().text = currentObject.name;
        labelName.GetComponent<TextMeshPro>().text = currentObject.name; 
        Bounds objectBounds = GetRenderBounds(currentObject);

        if(isLeft)
        {
            labelName.transform.localPosition = new Vector3(currentObject.transform.localPosition.x, currentObject.transform.localPosition.y, currentObject.transform.localPosition.z); 

        }
        else
        {
            labelName.transform.localPosition = new Vector3(currentObject.transform.localPosition.x, currentObject.transform.localPosition.y, currentObject.transform.localPosition.z); 
        }
    }

    public void displayLabel()
    {
        Debug.Log("DISPLAY LABELS !!!");
        if (isFirstCall){
            CreateLabel();
            isFirstCall = false;
        }
        else{
            foreach(GameObject label in labelObjects)
            {
                label.SetActive(true);
            }
        }
       
    }

    public void hideLabel()
    {
        Debug.Log("HIDE LABELS !!!");
        foreach(GameObject label in labelObjects)
        {
            label.SetActive(false);
        }
    }
}

//     private GameObject labelModelBtn; 
//     private bool isPress = false; 
//     private List<Material> materials = new List<Material>(); 
//     private GameObject activeObject; 
//     List<GameObject> labelObjects = new List<GameObject>(); 

//     // Start is called before the first frame update
//     void Start()
//     {
//         activeObject = GameObject.Find(" "); 
//         InitUI(); 
//         CreateLabel(); 
//         ShowChildLabel(); 

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         AdjustLabelToCamera(); 

//     }
//     void InitUI()
//     {
//         labelModelBtn = GameObject.Find("LabelModel"); 
//     }

//     void CreateLabel()
//     {
//         int childCount = activeObject.transform.childCount; 
//         for (int i = 0; i < childCount; i++)
//         {
//             GameObject childObject = activeObject.transform.GetChild(i).gameObject; 
//             GameObject labelObject = Instantiate(Resources.Load(PathConfig.labelPath) as GameObject); 
//             labelObject.tag = TagConfig.labelModel; 
//             labelObject.transform.SetParent(childObject.transform, false);
//             SetLabel(childObject, labelObject, i % 2 != 0); 
//             labelObjects.Add(labelObject);

//         }
//     }

//     void SetLabel(GameObject currentObject, GameObject label, bool isLeftButton)
//     {
//         GameObject line = label.transform.GetChild(0).gameObject; 
//         GameObject labelName = label.transform.GetChild(1).gameObject; 

//         labelName.transform.GetChild(0).gameObject.GetComponent<Text>().text = currentObject.name; 
//         Bounds objectBounds = GetRenderBounds(currentObject); 

//         if (isLeft)
//         {
//             labelName.transform.localPosition = new Vector3(currentObject.transform.localPosition.x - 4 * objectBounds.size.x, currentObject.transform.localPosition.y + 2 * objectBounds.size.y, currentObject.transform.localPosition.z); 

//         }
//         else 
//         {
//             labelName.transform.localPosition = new Vector3(currentObject.transform.localPosition.x + 4 * objectBound.size.x, currentObject.transform.localPosition.y + 2 * objectBound.size.y, currentObject.transform.localPosition.z); 
            
//         }
//     }
    
//     void ShowChildLabel()
//     {

//     }

//     void AdjustLabelToCamera()
//     {

//     }
// }
