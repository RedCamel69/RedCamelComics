using AutoMapper;
using RedCamel.WebUI.AppCode;
using RedCamel.WebUI.Models;
using RedCamel.WebUI.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RedCamel.WebUI.Controllers.API
{
    public class NewsController : ApiController
    {
        public List<PostViewModel> PostList { get; set; }

        // GET: api/News
        public IEnumerable<PostViewModel> Get()
        {
            PostList = new List<PostViewModel>();

            List<FeedRequest> requests = new List<FeedRequest>();

            requests.Add(new FeedRequest() { Source = FeedSource.CBR, Url = @"http://www.comicbookresources.com/feed.php?feed=news" });

            requests.Add(new FeedRequest() { Source = FeedSource.CVINE, Url = @"http://www.comicvine.com/feeds/reviews/" });



            Parallel.ForEach<FeedRequest>(requests, request => DoSomething(request));

            return PostList;
        }

        // GET: api/News/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/News
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/News/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/News/5
        public void Delete(int id)
        {
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
                Console.Write(ex);
            }



        }
    }
}
