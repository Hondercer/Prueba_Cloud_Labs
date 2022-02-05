using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadJSON : MonoBehaviour
{
    public static Estudiantes est = new Estudiantes();
    public string nameStudentsFile;
    public bool grid;
    public bool card;

    private float time = 10.0f;

    [Header ("Prefabs")]
    public GameObject studentType;

    // Start is called before the first frame update
    void Start()
    {
        loadStudents();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        //Debug.Log("Tiempo: " + time);
        if(time <= 0){
            Debug.Log("Se va a evaluar");
            compareStudents(loadStudentsMoment());
            time = 10.0f;
        }
    }

    public Estudiantes loadStudentsMoment(){
        
        string json =  File.ReadAllText(Application.streamingAssetsPath + "/" + nameStudentsFile + ".json");
        Estudiantes estMoment = new Estudiantes(); 
        estMoment = JsonUtility.FromJson<Estudiantes>(json);
        return estMoment;
    }

    public void compareStudents(Estudiantes comp){
        if(est.estudiantes.Count < comp.estudiantes.Count || est.estudiantes.Count > comp.estudiantes.Count){
            if(est.estudiantes.Count < comp.estudiantes.Count){
                for (int j = 0; j < comp.estudiantes.Count; j++)
                {
                    Debug.Log("Se destruyen los anteriores");
                    Destroy(GameObject.Find("Estudent" + j));
                }
            }else{
                for (int j = 0; j < est.estudiantes.Count; j++)
                {
                    Debug.Log("Se destruyen los anteriores");
                    Destroy(GameObject.Find("Estudent" + j));
                }
            }
            loadStudents();
        }else{
            
            if(est.estudiantes.Count > 0 && 0 < comp.estudiantes.Count){
                for (int i = 0; i < est.estudiantes.Count; i++)
                {
                    if(est.estudiantes[i].nombre != comp.estudiantes[i].nombre || est.estudiantes[i].apellido != comp.estudiantes[i].apellido ||
                    est.estudiantes[i].correo != comp.estudiantes[i].correo || est.estudiantes[i].codigo != comp.estudiantes[i].codigo
                    || est.estudiantes[i].notaFinal != comp.estudiantes[i].notaFinal){

                        
                        for (int j = 0; j < est.estudiantes.Count; j++)
                        {
                            
                            Destroy(GameObject.Find("Estudent" + j));
                        }
                        loadStudents();
                        break;
                    }
                    
                }
            }
        }
    }

    public void loadStudents(){        
        string json =  File.ReadAllText(Application.streamingAssetsPath + "/" + nameStudentsFile + ".json");
        est = JsonUtility.FromJson<Estudiantes>(json);

        
        if(grid){            
            createStudentsGrid();
        }

        if(card){
            createStudentsCard();
        }
    }

    public void saveStudents(){
        string json = JsonUtility.ToJson(est);
        File.WriteAllText(Application.streamingAssetsPath + "/" + nameStudentsFile + "_prueba" + ".json", json);
        Debug.Log("Archivo guardado");
    }

    public void createStudentsGrid(){
        
        if(est.estudiantes.Count > 0){
            
            for (int i = 0; i < est.estudiantes.Count; i++)
            {                
                GameObject estuGrid = studentType;
                estuGrid = Instantiate(estuGrid, new Vector2(-3000, 0), Quaternion.identity);            
                estuGrid.transform.SetParent(GameObject.Find("StudentsTable").transform);            
                estuGrid.name = "Estudent" + i;

                estuGrid.transform.GetChild(0).GetComponent<Text>().text = est.estudiantes[i].codigo;
                estuGrid.transform.GetChild(1).GetComponent<Text>().text = est.estudiantes[i].nombre + " " + est.estudiantes[i].apellido;
                estuGrid.transform.GetChild(2).GetComponent<Text>().text = est.estudiantes[i].correo;
                estuGrid.transform.GetChild(3).GetComponent<Text>().text = est.estudiantes[i].notaFinal.ToString();
            }
        }
    }

    public void createStudentsCard(){
        if(est.estudiantes.Count > 0){
            
            for (int i = 0; i < est.estudiantes.Count; i++)
            {                
                GameObject estuGrid = studentType;
                estuGrid = Instantiate(estuGrid, new Vector2(-3000, 0), Quaternion.identity);            
                estuGrid.transform.SetParent(GameObject.Find("StudentsTable").transform);            
                estuGrid.name = "Estudent" + i;
                                
                estuGrid.transform.GetChild(1).GetComponent<Text>().text = est.estudiantes[i].nombre + " " + est.estudiantes[i].apellido;                
                estuGrid.transform.GetChild(2).GetComponent<Text>().text = est.estudiantes[i].notaFinal.ToString();
            }
        }
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
    public float notaFinal;
    
}