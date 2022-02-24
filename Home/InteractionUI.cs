using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Home {
    public class InteractionUI : MonoBehaviour
    {
        private static InteractionUI instance;
        public static InteractionUI Instance 
        {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<InteractionUI>();
                }
                return instance;
            }
        }
        public void onClickItemLesson(int lessonId)
        {
            LessonManager.InitLesson(lessonId);

            if (PlayerPrefs.GetString("user_email") != ""){
                SceneNameManager.setPrevScene(SceneConfig.home_user);
                SceneManager.LoadScene(SceneConfig.lesson);  
            }
            else{
                SceneNameManager.setPrevScene(SceneConfig.home_nosignin);
                SceneManager.LoadScene(SceneConfig.lesson_nosignin);  
            }
            
        }
    }

}
