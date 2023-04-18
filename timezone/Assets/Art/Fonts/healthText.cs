using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthText : MonoBehaviour
{
    public float aliveTime = 0.5f;
    public float floatSpeed = 50f;
    public Vector3 floatDirection = new Vector3(0f, 1f, 0f);
    public TextMeshProUGUI textMesh;
    private Color startingColor;
    private RectTransform rTransform;
    private float textTimeElapsed = 0f;

    void Start()
    {
        startingColor = textMesh.color;
        rTransform = GetComponent<RectTransform>();
    }

        public void Initialize(float damageAmount, Vector2 position)
        {
            textMesh.text = damageAmount.ToString();
            rTransform.position = Camera.main.WorldToScreenPoint(position);
        }

    void Update()
    {
        textTimeElapsed += Time.deltaTime;

        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1f - textTimeElapsed / aliveTime);

        if (textTimeElapsed > aliveTime)
        {
            Destroy(gameObject);
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class healthText : MonoBehaviour
// {

//     public float aliveTime = 0.5f;
//     public float floatSpeed= 50;

//     public Vector3 floatDirection = new Vector3(0,1,0);
//     public TextMeshProUGUI textMesh;

//     Color startingColor;

//     RectTransform rTransform;

//     float textTimeElapsed = 0f;
//     void Start(){
//         startingColor = textMesh.color;
//         rTransform = GetComponent<RectTransform>();
//         rTransform.anchoredPosition = new Vector3(0, 0,0);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         textTimeElapsed += Time.deltaTime;

//         rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

//         textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1-textTimeElapsed/aliveTime);

//         if (textTimeElapsed > aliveTime){
//             Destroy(gameObject);
//         }
//     }
// }
