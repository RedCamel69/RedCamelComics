using RedCamel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedCamel.Domain.Entities;

namespace RedCamel.Domain.Concrete
{
    public class CreatorRepository : ICreatorRepository
    {
        public IEnumerable<Creator> Creators
        {
            get
            {
                List<Creator> creators = new List<Creator>();

                Creator vm = new Creator();
                vm.Name = String.Format("{0} {1}", "George", "Perez");
                vm.Age = 67;
                vm.DOB = "June 9th 1954";


                vm.MostNotableWorks = new List<string>();
                vm.MostNotableWorks.Add("Avengers");
                vm.MostNotableWorks.Add("The Fantastic Four");
                vm.MostNotableWorks.Add("Teen Titans");
                vm.MostNotableWorks.Add("Wonder Woman");

                vm.Sections = new List<Creator.ProfileSection>();
                vm.Sections.Add(new Creator.ProfileSection() { Title = "Title Of Section", Text = "Some profile info" });

                vm.Sections[0].Title = "Marvel 1970's";
                vm.Sections[0].Text = "Pérez came to prominence with Marvel's superhero-team comic The Avengers, starting with issue #141. In the 1970s, Pérez illustrated several other Marvel titles, including Creatures on the Loose, featuring the Man-Wolf; The Inhumans; and Fantastic Four.";

                vm.Sections.Add(new Creator.ProfileSection() { Title = "Title Of Section", Text = "Some profile info" });
                vm.Sections[1].Title = "DC 1980's";
                vm.Sections[1].Text = "In 1980, while still drawing The Avengers for Marvel, Pérez began working for their rival DC Comics.  Following a popular stint on Justice League of America, Pérez's career took off with the launch of The New Teen Titans, written by Marv Wolfman.";


                vm.Galleries = new List<Creator.ProfileGallery>();

                Creator.ProfileGallery pg = new Creator.ProfileGallery() { Title = "Gallery 1" };
                pg.Images = new List<Creator.ProfileGalleryImage>();

                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 160", Description = "Image 1", Source = "../../Images/Covers/FantasticFourVol1/FF_Vol1_165.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 161", Description = "Image 2", Source = "../../Images/Covers/FantasticFourVol1/FF_Vol1_184.jpg" });

                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 160", Description = "Image 1", Source = "../../Images/Covers/AvengersVol1/Avengers-160.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 161", Description = "Image 2", Source = "../../Images/Covers/AvengersVol1/Avengers-161.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 163", Description = "Image 1", Source = "../../Images/Covers/AvengersVol1/Avengers163.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 164", Description = "Image 2", Source = "../../Images/Covers/AvengersVol1/Avengers164.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 165", Description = "Image 3", Source = "../../Images/Covers/AvengersVol1/Avengers165.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 166", Description = "Image 1", Source = "../../Images/Covers/AvengersVol1/Avengers166.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 167", Description = "Image 2", Source = "../../Images/Covers/AvengersVol1/Avengers167.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 166", Description = "Image 1", Source = "../../Images/Covers/InfinityGauntlet/InfinityGauntlet1.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 167", Description = "Image 2", Source = "../../Images/Covers/InfinityGauntlet/InfinityGauntlet2.jpg" });
                pg.Images.Add(new Creator.ProfileGalleryImage() { Title = "Avengers 168", Description = "Image 3", Source = "../../Images/Covers/InfinityGauntlet/InfinityGauntlet4.jpg" });

                vm.Galleries.Add(pg);

                creators.Add(vm);

                return creators;

            }
        }
    }
}
