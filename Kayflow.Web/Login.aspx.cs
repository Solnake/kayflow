using System;
using System.Collections.Generic;

public partial class Login : BasePage
{
    protected override bool FormAuthenticate()
    {
        return true;
    }

    public override List<Crumb> Breadcrumbs
    {
        get { throw new NotImplementedException(); }
    }
}