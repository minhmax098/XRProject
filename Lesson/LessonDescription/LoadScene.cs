using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI; 
using System; 

namespace LessonDescription
{
public class LoadScene : MonoBehaviour
{
    public LessonDetail [] myData; 
    public LessonDetail currentLesson;

    public GameObject bodyObject;

    public GameObject lessonTitle; 

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait; 
        Debug.Log("Lesson ID:");
        Debug.Log(LessonManager.lessonId);

        myData = LoadData.Instance.GetLessonsByID(LessonManager.lessonId.ToString()).data; 
        currentLesson = Array.Find(myData, lesson => lesson.lessonId == LessonManager.lessonId); 
        LoadCurrentLesson(currentLesson);
    }

    void Update()
    {

    }
    void LoadCurrentLesson(LessonDetail currentLesson)
    {
        lessonTitle.gameObject.GetComponent<Text>().text = currentLesson.lessonTitle;
        bodyObject.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<Text>().text = currentLesson.lessonObjectives;
        Debug.Log(currentLesson.lessonThumbnail);
        bodyObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(currentLesson.lessonThumbnail.Split('.')[0].Substring(1));
        // bodyObject.transform.GetChild(0).GetChild(1).GetComponent<Button>().image.color = currentLesson.isFavorate != 0 ? Color.red : Color.black;
        bodyObject.transform.GetChild(2).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = currentLesson.authorName;
        bodyObject.transform.GetChild(2).GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>().text = currentLesson.createdDate;
        bodyObject.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "#" + currentLesson.lessonId.ToString();
        bodyObject.transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Text>().text = currentLesson.size;
        bodyObject.transform.GetChild(2).GetChild(1).GetChild(2).GetComponent<Text>().text = currentLesson.viewed.ToString() + " Views";
        
    }
}
}
