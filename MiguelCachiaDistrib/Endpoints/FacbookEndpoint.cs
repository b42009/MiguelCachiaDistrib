using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MiguelCachiaDistrib
{
    public class FacebookEndpoint
    {

        string baseLink = "https://graph.facebook.com/v7.0/";
        public string AccesTokenFB;
        public string GetProfileEndpoint()
        {
            StringBuilder strb = new StringBuilder(baseLink);
            strb.Append("me?fields=name,email,birthday&access_token=");
            strb.Append(AccesTokenFB);
            return strb.ToString();
        }

        public string GetfeedEndpoint()
        {
            StringBuilder strb = new StringBuilder(baseLink);
            strb.Append("me/feed?access_token=");
            strb.Append(AccesTokenFB);
            return strb.ToString();
        }
        public string GetLikesEndpoint()
        {
            StringBuilder strb = new StringBuilder(baseLink);
            strb.Append("me/likes?access_token=");
            strb.Append(AccesTokenFB);
            return strb.ToString();
        }
        public string GetpicsEndpoint(String id)
        {
            StringBuilder strb = new StringBuilder(baseLink);
            strb.Append(id);
            strb.Append("?fields=full_picture,picture&access_token=");
            strb.Append(AccesTokenFB);
            return strb.ToString();
        }

        public string GetPrefEndpoint(bool valueEmail, bool valueBirthDate,bool valueName)
        {

            StringBuilder strb = new StringBuilder(baseLink);
            strb.Append("me?fields=id");
            if (valueEmail == true || valueBirthDate == true || valueName == true) { strb.Append(","); }
            if (valueName) { strb.Append("name"); }
            if (valueName && valueEmail || valueName && valueBirthDate) { strb.Append(","); }
            if (valueEmail) { strb.Append("email"); }
            if (valueEmail && valueBirthDate) { strb.Append(","); }
            if (valueBirthDate) { strb.Append("birthday"); }
            strb.Append("&access_token="); 

            strb.Append(AccesTokenFB);
            return strb.ToString();
        }
        public string GettokenpostEndpoint()
        {
            StringBuilder strb = new StringBuilder(baseLink);
           
            strb.Append("me/accounts?access_token=");
            strb.Append(AccesTokenFB);
            return strb.ToString();
        }
       
         public string GetcpagepostEndpoint(String pageid)
        {
            StringBuilder strb = new StringBuilder(baseLink);
            strb.Append(pageid);
            strb.Append("/feed?access_token=");
            strb.Append(AccesTokenFB);
            return strb.ToString();
        }

       
          public string Getcomments(String pageToken, String postId)
    {
        StringBuilder strb = new StringBuilder(baseLink);
        strb.Append(postId);
            strb.Append("/comments");
            

            strb.Append("?access_token=");
        strb.Append(pageToken);
      
        return strb.ToString();
    }
      

    public Dictionary<string, string> EndpointURL() 
        {
            return new Dictionary<string, string>
            {
                 { "Authorization", AccesTokenFB }

            };
           
        }
    }
}