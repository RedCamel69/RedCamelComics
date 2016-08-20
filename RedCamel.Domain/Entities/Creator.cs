using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Entities
{
    public class Creator
    {
       
            public string Name { get; set; }
            public int Age { get; set; }
            public string DOB { get; set; }
            public string Nationality { get; set; }


            public List<string> MostNotableWorks { get; set; }

            public List<ProfileSection> Sections { get; set; }

            public List<ProfileGallery> Galleries { get; set; }
      


        public class ProfileSection
        {
            public string Title { get; set; }
            public string Text { get; set; }
        }

        public class ProfileGallery
        {
            public string Title { get; set; }
            public List<ProfileGalleryImage> Images { get; set; }

        }

        public class ProfileGalleryImage
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Source { get; set; }
        }

    }
}
