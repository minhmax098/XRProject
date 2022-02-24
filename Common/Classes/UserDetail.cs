using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserDetail
{
    public int code; 
    public string message; 
    public string token;
    public UserInfo user;
    public string secret; 
}

[System.Serializable]
public class UserInfo {
    public string fullName;
    public string email;

    // public string password;
    // public string confirmPassword; 
}