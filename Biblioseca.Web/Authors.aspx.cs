﻿using Biblioseca.DataAccess.Authors;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioseca.Web
{
    public partial class Authors : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorDao authorDao = new AuthorDao(Global.SessionFactory);
            AuthorService authorService = new AuthorService(authorDao);

            this.GridViewAuthors.DataSource = authorService.GetAll();
            this.GridViewAuthors.DataBind();
        }
    }
}