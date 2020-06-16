using MiguelCachiaDistrib.Client;
using MiguelCachiaDistrib.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGrease.Extensions;
using static MiguelCachiaDistrib.JsonParser.JsonParser;

namespace MiguelCachiaDistrib.Controllers
{
    [Authorize]
    [RoutePrefix("api/Fbpost")]
    public class FbpostController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
     
        protected Restclient clientt= new Restclient();
        private FacebookEndpoint fblink;
        public FbpostController() : base() 
        {
            this.fblink = new FacebookEndpoint();
        }

        [HttpGet]
        [Route("GetProfile")]
        // GET api/<controller>/5
        public FacbookProfileModel GetProfile(string Token,string email)
        {


            var user = db.Users.FirstOrDefault(x => x.UserName == email);
            var logedinuse = db.Preferencmodels.FirstOrDefault(x => x.praivecyuserid == user.Id);

        fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetPrefEndpoint(logedinuse.email, logedinuse.birthday, logedinuse.name);

            String Data = clientt.Request(HttpVerb.GET,fblink.EndpointURL());
            JSONParser<FacbookProfileModel> jsonp = new JSONParser<FacbookProfileModel>();
            FacbookProfileModel fbm = new FacbookProfileModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }

        [HttpGet]
        [Route("Getfeed")]
        // GET api/<controller>/5
        public FacbookFeedModel Getfeed(String Token)
        {
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetfeedEndpoint();

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
            JSONParser<FacbookFeedModel> jsonp = new JSONParser<FacbookFeedModel>();
            FacbookFeedModel fbm = new FacbookFeedModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }
        [HttpGet]

        [Route("Getlike")]
        // GET api/<controller>/5
        public FacbookLikeModel Getlike(String Token)
        {
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetLikesEndpoint();

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
            JSONParser<FacbookLikeModel> jsonp = new JSONParser<FacbookLikeModel>();
            FacbookLikeModel fbm = new FacbookLikeModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }

        [HttpGet]
        [Route("Getimage")]
        // GET api/<controller>/5
        public FacbookImageModel Getimage(string Token,string imgid)
        {
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetpicsEndpoint(imgid);

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
            JSONParser<FacbookImageModel> jsonp = new JSONParser<FacbookImageModel>();
            FacbookImageModel fbm = new FacbookImageModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }
        [HttpGet]
        [Route("preferences")]
        // GET api/<controller>/5
        public FacbookProfileModel preferences(string Token, string email, bool valueEmail, bool valueBirthDate,bool valuename)
        {
            Preferencmodel pm = new Preferencmodel();
            pm.email = valueEmail;
            pm.birthday = valueBirthDate;
            PreferencmodelsController pc = new PreferencmodelsController();
            if (pc.checkifexist(email)) { pc.Create(email, valueEmail, valueBirthDate, valuename); }
            else {
                pc.UpdatenewFeeld(email, valueEmail, valueBirthDate, valuename);
            }
          
            
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetPrefEndpoint(valueEmail, valueBirthDate, valuename);

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
            JSONParser<FacbookProfileModel> jsonp = new JSONParser<FacbookProfileModel>();
            FacbookProfileModel fbm = new FacbookProfileModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }
        [HttpGet]
        [Route("GetAccountt")]
        // GET api/<controller>/5
        public FacbookAcountModel GetAccountt(string Token)
        {
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GettokenpostEndpoint();

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
            JSONParser<FacbookAcountModel> jsonp = new JSONParser<FacbookAcountModel>();
            FacbookAcountModel fbm = new FacbookAcountModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }
      
          [HttpGet]
        [Route("GetPagePost")]
        // GET api/<controller>/5
        public FacbookFeedModel GetPagePost(string Token,string pageid)
        {
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetcpagepostEndpoint(pageid);

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
            JSONParser<FacbookFeedModel> jsonp = new JSONParser<FacbookFeedModel>();
            FacbookFeedModel fbm = new FacbookFeedModel();
            fbm = jsonp.parseJson(Data);
            return fbm;


        }
        url: '/api/Fbpost/Commenting?token=' + sessionStorage.getItem("ComentAccesToken") + '&PageId=' + sessionStorage.getItem("PageId") + '&message=' + document.getElementById("MyComment").value,

          [HttpPost]
        [Route("Commenting")]
        // GET api/<controller>/5
        public void Commenting(string Token, string PageId,string message)
        {
            fblink.AccesTokenFB = Token;
            clientt.endpoint = fblink.GetcpagepostEndpoint(Token, PageId, message);

            String Data = clientt.Request(HttpVerb.GET, fblink.EndpointURL());
          


        }
    }
}