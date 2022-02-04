using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadJSON : MonoBehaviour
{
    public static Estudiantes est;
    public string nameStudentsFile;
    public bool grid;
    public bool card;

    [Header ("Prefabs")]
    public GameObject studentType;

    // Start is called before the first frame update
    void Start()
    {
        loadStudents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadStudents(){
        //string json = File.ReadAllText(@"E:\Windows 10\Desktop\Talentum\Prueba\Assets\JSON\partidas.json");
        string json =  Application.streamingAssetsPath + "/" + nameStudentsFile + ".JSON";
        Debug.Log(json);
        est = JsonUtility.FromJson<Estudiantes>(json);

        if(grid){
            createStudentsGrid();
        }

        if(card){
            createStudentsCard();
        }
    }

    public void createStudentsGrid(){
        if(est.estudiantes.Count > 0){
            for (int i = 0; i < est.estudiantes.Count; i++)
            {
                GameObject estuGrid = studentType;
                estuGrid = Instantiate(estuGrid, new Vector2(-3000, 0), Quaternion.identity);            
                estuGrid.transform.SetParent(GameObject.Find("/StudentsTable").transform);            
                estuGrid.name = "Estudent" + i;

                estuGrid.transform.GetChild(0).GetComponent<Text>().text = est.estudiantes[i].codigo;
                estuGrid.transform.GetChild(1).GetComponent<Text>().text = est.estudiantes[i].nombre + " " + est.estudiantes[i].apellido;
                estuGrid.transform.GetChild(2).GetComponent<Text>().text = est.estudiantes[i].correo;
                estuGrid.transform.GetChild(3).GetComponent<Text>().text = est.estudiantes[i].notaFinal;
            }
        }
    }

    public void createStudentsCard(){

    }

    public void saveStudents(){

    }
}

[Serializable]
public class Estudiantes{
    public List<Estudiante> estudiantes;
}

[Serializable]
public class Estudiante{
    public string nombre;
    public string apellido;
    public string codigo;
    public string correo;
    public string notaFinal;
    
}