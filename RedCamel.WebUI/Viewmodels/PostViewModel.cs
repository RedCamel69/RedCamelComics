using RedCamel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCamel.WebUI.Viewmodels
{
    public class PostViewModel
    {
        public DateTime TimeStamp { get; set; }

        public List<Post> Posts { get; set; }
    }
}