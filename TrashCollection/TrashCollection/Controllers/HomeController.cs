using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using static TrashCollection.Models.Location;

namespace TrashCollection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet, ActionName("GetStopList")]
        public JsonResult GetStopList(string SearchText)
        {
            string placeApiUrl = ConfigurationManager.AppSettings["GooglePlaceAPIUrl"];

            try
            {
                placeApiUrl = placeApiUrl.Replace("{0}", SearchText);
                placeApiUrl = placeApiUrl.Replace("{1}", ConfigurationManager.AppSettings["GooglePlaceAPIKey"]);

                var result = new System.Net.WebClient().DownloadString(placeApiUrl);
                var Jsonobject = JsonConvert.DeserializeObject<RootObject>(result);

                List<Prediction> list = Jsonobject.predictions;

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //Code for page using google api
        //List<Country> objCountry = new List<Country>();
        //CountryModel model = new CountryModel();
        //objCountry = model.GetCountries();
        //return View(new CollectionLocation { Countries = objCountry });
    }
}