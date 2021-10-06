using System;
using DAL;
using System.Collections.Generic;
using Persistence;

public class ApplicationBL
{
    public List<Application> SearchApplicationByName(string name)
    {
        return ApplicationDAL.GetApplicationByName(name);
    }
}