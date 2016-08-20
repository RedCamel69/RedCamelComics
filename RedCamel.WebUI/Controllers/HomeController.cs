using AutoMapper;
using RedCamel.WebUI.AppCode;
using RedCamel.WebUI.Models;
using RedCamel.WebUI.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace RedCamel.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public List<PostViewModel> PostList { get; set; }

        // GET: Home
        public ActionResult Index()
        {

            /*
            PostList = new List<PostViewModel>();
            List<FeedRequest> requests = new List<FeedRequest>();

            try
            {


                requests.Add(new FeedRequest() { Source = FeedSource.CBR, Url = @"http://www.comicbookresources.com/feed.php?feed=news" });

                requests.Add(new FeedRequest() { Source = FeedSource.CVINE, Url = @"http://www.comicvine.com/feeds/reviews/" });

                Parallel.ForEach<FeedRequest>(requests, request => DoSomething(request));
            }

            catch (Exception ex)
            {

            }







            return View(PostList);
            */

            return View();


        }

        public void DoSomething(FeedRequest f)

        {



            try
            {

                //throw new Exception("Error!!!!");

                var posts = new RssFeedReader().ReadFeed(f.Url, f.Source);


                var mappedPost = Mapper.Map<List<Post>, PostViewModel>(posts.ToList<Post>());

                PostList.Add(mappedPost);
            }

            catch (Exception ex)
            {

            }



        }

        public ActionResult News()
        {
            PostList = new List<PostViewModel>();

            List<FeedRequest> requests = new List<FeedRequest>();

            requests.Add(new FeedRequest() { Source = FeedSource.CBR, Url = @"http://www.comicbookresources.com/feed.php?feed=news" });

            requests.Add(new FeedRequest() { Source = FeedSource.CVINE, Url = @"http://www.comicvine.com/feeds/reviews/" });



            Parallel.ForEach<FeedRequest>(requests, request => DoSomething(request));



            return PartialView("_LatestNews",PostList);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Locator()

        {

            return PartialView("_FindMyLocalStore");

        }



        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult About()
        {
            return View();
        }

        [Route("CreatorProfileIndex")]
        public ActionResult CreatorProfileIndex()
        {
            return View();

        }

        [Route("CreatorProfile/{firstName}/{secondName}")]
        public ActionResult CreatorProfile(string firstName, string secondName)
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm.Name = String.Format("{0} {1}", firstName, secondName);
            vm.Age = 67;
            vm.DOB = "June 9th 1954";


            vm.MostNotableWorks = new List<string>();
            vm.MostNotableWorks.Add("Avengers");
            vm.MostNotableWorks.Add("The Fantastic Four");
            vm.MostNotableWorks.Add("Teen Titans");
            vm.MostNotableWorks.Add("Wonder Woman");

            vm.Sections = new List<ProfileSection>();
            vm.Sections.Add(new ProfileSection() { Title = "Title Of Section", Text = "Some profile info" });

            vm.Sections[0].Title = "Marvel 1970's";
            vm.Sections[0].Text = "Pérez came to prominence with Marvel's superhero-team comic The Avengers, starting with issue #141. In the 1970s, Pérez illustrated several other Marvel titles, including Creatures on the Loose, featuring the Man-Wolf; The Inhumans; and Fantastic Four.";

            vm.Sections.Add(new ProfileSection() { Title = "Title Of Section", Text = "Some profile info" });
            vm.Sections[1].Title = "DC 1980's";
            vm.Sections[1].Text = "In 1980, while still drawing The Avengers for Marvel, Pérez began working for their rival DC Comics.  Following a popular stint on Justice League of America, Pérez's career took off with the launch of The New Teen Titans, written by Marv Wolfman.";


            vm.Galleries = new List<ProfileGallery>();

            ProfileGallery pg = new ProfileGallery() { Title = "Gallery 1" };
            pg.Images = new List<ProfileGalleryImage>();

            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 160", Description = "Image 1", Source = "../../Images/Covers/FantasticFourVol1/FF_Vol1_165.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 161", Description = "Image 2", Source = "../../Images/Covers/FantasticFourVol1/FF_Vol1_184.jpg" });

            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 160", Description = "Image 1", Source = "../../Images/Covers/AvengersVol1/Avengers-160.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 161", Description = "Image 2", Source = "../../Images/Covers/AvengersVol1/Avengers-161.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 163", Description = "Image 1", Source = "../../Images/Covers/AvengersVol1/Avengers163.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 164", Description = "Image 2", Source = "../../Images/Covers/AvengersVol1/Avengers164.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 165", Description = "Image 3", Source = "../../Images/Covers/AvengersVol1/Avengers165.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 166", Description = "Image 1", Source = "../../Images/Covers/AvengersVol1/Avengers166.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 167", Description = "Image 2", Source = "../../Images/Covers/AvengersVol1/Avengers167.jpg" });            
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 166", Description = "Image 1", Source = "../../Images/Covers/InfinityGauntlet/InfinityGauntlet1.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 167", Description = "Image 2", Source = "../../Images/Covers/InfinityGauntlet/InfinityGauntlet2.jpg" });
            pg.Images.Add(new ProfileGalleryImage() { Title = "Avengers 168", Description = "Image 3", Source = "../../Images/Covers/InfinityGauntlet/InfinityGauntlet4.jpg" });

            vm.Galleries.Add(pg);

            return View(vm);

        }

        [Route("FindMyLocalShop")]
        public ActionResult FindMyLocalShop(string firstName, string secondName)
        {
            return View();
        }
    }
}
