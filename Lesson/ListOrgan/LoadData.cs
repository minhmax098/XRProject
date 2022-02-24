using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Threading.Tasks;

namespace ListOrgan 
{
    public class LoadData : MonoBehaviour
    {
        private string jsonResponse;
        private static LoadData instance; 
        public static LoadData Instance 
        {
            get {
                if(instance == null)
                {
                    instance = FindObjectOfType<LoadData>(); 
                }
                return instance; 
            }
        }

        public async Task<AllOrgans> GetListLessonsByOrgan(int organId, string searchValue, int offset, int limit)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://api.xrcommunity.org/xap/organs/getListLessonByOrgan?organId={0}&searchValue={1}&offset={2}&limit={3}", organId, searchValue, offset, limit)); 
            request.Method = "GET";
            request.Headers["Authorization"] = PlayerPrefs.GetString("user_token");

            HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();
            StreamReader reader= new StreamReader(response.GetResponseStream());
            jsonResponse = reader.ReadToEnd();
            Debug.Log("JSON RESPONSE: ");
            Debug.Log(jsonResponse);
            
            return JsonUtility.FromJson<AllOrgans>(jsonResponse); 
        }

        // public OrganModel GetOrgans_()
        // {
        //     return JsonUtility.FromJson<OrganModel>(jsonFileGetOrgans.text); 
        // }
    }
}
