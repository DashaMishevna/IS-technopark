﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class New_Data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class_FIO.Director = "МяуМяучивияч";
            Label3.Text = Class_FIO.Director;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}