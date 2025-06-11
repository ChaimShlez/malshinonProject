using System;
using malshinonProject.Entitys;
using malshinonProject.Logic;

internal class ControllerLogin
{
    private LogicLogin _logicLogin;

    public ControllerLogin(LogicLogin logicLogin)
    {
        _logicLogin = logicLogin;
    }

    public Person Login(string codeName)
    {

       
        return _logicLogin.Login(codeName);
    }


    public Person LoginAdmin(string codeName)
    {


        return _logicLogin.LoginAdmin(codeName);
    }
}
