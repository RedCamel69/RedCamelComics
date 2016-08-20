using AutoMapper;
using RedCamel.WebUI.Models;
using RedCamel.WebUI.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCamel.WebUI.App_Start
{
    public static class AutoMapperConfig

    {

        public static void RegisterMappings()
        {



            Mapper.CreateMap<List<Post>, PostViewModel>()

                .BeforeMap((s, d) => d.Posts = s)

                .AfterMap((s, d) => d.TimeStamp = DateTime.Now);

        }

    }
}