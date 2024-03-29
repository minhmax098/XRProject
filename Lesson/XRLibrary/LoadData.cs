using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.Networking;
using System.IO;
using System;

namespace XRLibrary
{
    public class LoadData : MonoBehaviour
    {
        // public TextAsset jsonFileGetListXRLibrary; 
        private static LoadData instance; 
        private string jsonResponse;
        public static LoadData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<LoadData>(); 
                }
                return instance; 
            }
        }

        public AllXRLibrary GetListLessons(string searchValue, int offset, int limit)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://api.xrcommunity.org/xap/organs/getListLessonByOrgan?organId=&searchValue={0}&offset={1}&limit={2}", searchValue, offset, limit)); 
            request.Method = "GET";
            request.Headers["Authorization"] = PlayerPrefs.GetString("user_token");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader= new StreamReader(response.GetResponseStream());
            jsonResponse = reader.ReadToEnd();
            Debug.Log("JSON RESPONSE: ");
            Debug.Log(jsonResponse);

            return JsonUtility.FromJson<AllXRLibrary>(jsonResponse); 
        }
        
    }
}
