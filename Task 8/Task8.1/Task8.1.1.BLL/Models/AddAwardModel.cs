using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Class1
/// </summary>
public class AddAwardModel
{
    public string award;
    public static readonly string add = "The award is added";
    public static readonly string notitle = "Enter a title";
    private static AddAwardModel _instance;
    public string Title;
    public static AddAwardModel Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AddAwardModel();// (0,null);
            return _instance;
        }
        set
        {
            if (_instance != null)//&&_instance.counter == 0)
                _instance = value;
        }
    }
}