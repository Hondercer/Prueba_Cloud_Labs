using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reviewStudents : MonoBehaviour
{
    public GameObject notification;
    public GameObject notification2;
    public Text notificationText;
    public Button aceptar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void revisarEstudiantes(){

        if(GameObject.Find("StudentsTable").transform.childCount > 0){
            Debug.Log("Si hay varios estudiantes");
            int count = 0;
            Transform tra = GameObject.Find("StudentsTable").transform;

            for (int i = 0; i < GameObject.Find("StudentsTable").transform.childCount; i++)
            {
                if(tra.GetChild(i).GetChild(4).GetChild(0).GetComponent<Dropdown>().value == 0 && float.Parse(tra.GetChild(i).GetChild(3).GetComponent<Text>().text) >= 3.0f){
                    count++;
                }

                if(tra.GetChild(i).GetChild(4).GetChild(0).GetComponent<Dropdown>().value == 1 && float.Parse(tra.GetChild(i).GetChild(3).GetComponent<Text>().text) < 3.0f){
                    count++;
                }
            }

            if(count >= GameObject.Find("StudentsTable").transform.childCount){
                notification.SetActive(true);
                notificationText.text = "¡Has calificado correctamente!";
                aceptar.enabled = true;
            }else{
                notification.SetActive(true);
                notificationText.text = "Te has equivocado calificando, revisa de nuevo";
                aceptar.enabled = false;
            }
        }
    }

    public void revisarEstudiantesCard(){
        Debug.Log("Se empieza a revisar");
        if(GameObject.Find("AreaBueno").transform.childCount > 0 || GameObject.Find("AreaMalo").transform.childCount > 0){
            Debug.Log("Si hay varios estudiantes");
            int count = 0;
            Transform tra = GameObject.Find("AreaBueno").transform;
            Transform tra1 = GameObject.Find("AreaMalo").transform;

            if(tra.childCount > 0){
                for (int i = 0; i < tra.childCount; i++)
                {
                    if(float.Parse(tra.GetChild(i).GetChild(2).GetComponent<Text>().text) >= 3.0f){
                        count++;
                    }
                }
            }

            if(tra1.childCount > 0){
                for (int i = 0; i < tra1.childCount; i++)
                {
                    if(float.Parse(tra1.GetChild(i).GetChild(2).GetComponent<Text>().text) < 3.0f){
                        count++;
                    }
                }
            }            

            if(count >= (tra.childCount + tra1.childCount)){
                notification.SetActive(true);
                notificationText.text = "¡Has calificado correctamente!";
                aceptar.interactable = true;
            }else{
                notification.SetActive(true);
                notificationText.text = "Te has equivocado calificando, revisa de nuevo";
                aceptar.interactable = false;
            }
        }
    }

    public void exit(){
        notification.SetActive(false);
    }

    public void exit2(){
        notification2.SetActive(false);
    }    

    public void acept(){
        SceneManager.LoadScene(1);
    }
}
