using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Expression : ScriptableObject
{
    [SerializeField]
    public int id { get; set; }
    [SerializeField]
    public string objectName = "Express";
    [SerializeField]
    public RawImage icon { get; set; }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
