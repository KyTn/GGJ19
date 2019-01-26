using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public Question[] questions;
    public Expression TestExpress;

    public Dialog()
    {
        questions = new Question[] {
            new Question(
                new Expression[]{ TestExpress, TestExpress },
                new Expression[]{ TestExpress, TestExpress }
            ),
            new Question(
                new Expression[]{ TestExpress, TestExpress },
                new Expression[]{ TestExpress, TestExpress }
            ),
        };
        Debug.Log("Prueba de 1: " + questions[0].question[0].name);
    }

    void Start()
    {
        Debug.Log("Prueba de 1: " + questions[0].question[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
