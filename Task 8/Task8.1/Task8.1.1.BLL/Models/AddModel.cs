using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Class1
/// </summary>
public class AddModel
{
    public string user;
    public static readonly string add = "The user is added";
    public static readonly string date = "Incorrect date";
    public static readonly string noname = "Enter a name";
    private static AddModel _instance;
    public string Day;
    public string Month;
    public string Year;
    public string Name;
    public static AddModel Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AddModel();// (0,null);
            return _instance;
        }
        set
        {
            if (_instance != null)//&&_instance.counter == 0)
                _instance = value;
        }
    }
}