using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using core_ewidencja.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using System.Xml;
using Microsoft.EntityFrameworkCore;



namespace core_ewidencja.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration configuration;

        private IHostingEnvironment hostingEnv;

        



        public HomeController( IConfiguration conf, IHostingEnvironment env)
        {
            configuration = conf;
            hostingEnv = env;
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
        }

        public IActionResult Index()
        {
            var context = HttpContext.Request.Host.Host;

            ViewBag.host = context;
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;

            ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            Model m = new Model();

            m.InsertIPIntoDB((string)ViewBag.IP, "Home/Index");

            return View();
        }

        public IActionResult Energy()
        { 
            List<Energy> energia = new List<Energy>();

            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
           

            try
            {
                ewidencjaContext ew = new ewidencjaContext();

                var tzl=ew.TblZuzycieEnergii.OrderByDescending(a => a.Data).Select(x => new { x.Kwh, x.Data, x.WskLicznika });

              
                foreach (var entry in tzl)
                {
                    Energy e = new Energy();
                    e.kwh = Convert.ToInt32(entry.Kwh);
                    e.data = entry.Data.ToString();
                    e.stan_licznika = entry.WskLicznika.ToString();
     
                    energia.Add(e);
                    
                }
              
              
                ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();

                Model m = new Model();
            
            }
            
            catch (Exception ex) {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }

        
            return View(energia);
        }
        public IActionResult Serwis()
        {
            List<Models.Czynnosc> czynnosci = new List<Czynnosc>();
            String info_msg = "";
            try
            {
                ewidencjaContext ew = new ewidencjaContext();

               var cp= ew.CzynnosciPojazdy.OrderByDescending(a => a.Data).Select(x => new { x.Data, x.Przebieg, x.OpisCzynnosci });

                foreach(var entry in cp)
                {
                    Czynnosc c = new Czynnosc();

                    c.data = entry.Data.ToString();
                    c.przebieg = Convert.ToInt32(entry.Przebieg);
                    c.opis = entry.OpisCzynnosci;

                    czynnosci.Add(c);
                }
              
                ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            }
            catch (Exception ex)
            {
                info_msg = ex.ToString();
                ViewBag.info_msg = info_msg;
            }

          
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;

            return View(czynnosci);
        }
        public IActionResult Ewidencja()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            Model m = new Model();
            m.InsertIPIntoDB((string)ViewBag.IP, "/Home/Ewidencja");

            return View();

        }
        public IActionResult Gaz()
        {
            List<Gaz> gaz = new List<Gaz>();


            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            try
            {
                ewidencjaContext ew = new ewidencjaContext();

                var tzg = ew.TblZuzycieGazu.OrderByDescending(a => a.Data).Select(x => new { x.Kwh, x.Data, x.WskLicznika });

                foreach(var entry in tzg)
                {
                    Gaz g = new Gaz();

                    g.kwh = entry.Kwh.ToString();
                    g.data = entry.Data.ToString();
                    g.stan_licznika = entry.WskLicznika.ToString();

                    gaz.Add(g);

                }

                ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();

                Model m = new Model();
                m.InsertIPIntoDB((string)ViewBag.IP, "/Home/Gaz");
            }
            catch (Exception ex)
            {
                ViewBag.info_msg = ex.ToString();
            }

            return View(gaz);
        }
        public IActionResult Woda()
        {

            List<Woda> litry_wody = new List<Woda>();




            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;

            try
            {
                ewidencjaContext ew = new ewidencjaContext();

                var tzw = ew.TblZuzycieWody.OrderByDescending(a => a.Date).Select(x => new { x.Date, x.WskLicznika });

                foreach (var entry in tzw)
                {
                    Woda w = new Woda();
                    w.data = entry.Date.ToString();
                    w.wsk_licznika = entry.WskLicznika.ToString();

                    litry_wody.Add(w);
                }
                
                
                ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();

                Model m = new Model();
                m.InsertIPIntoDB((string)ViewBag.IP, "/Home/Woda");
            }
            catch (Exception ex)
            {
                ViewBag.info_msg = ex.ToString();
            }

            return View(litry_wody);

        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Jednostki()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;

            return View();
        }

        [HttpPost]
        public string Przelicz(string pre_unit, string pre_value, string post_unit, string post_value)
        {
            string err = "";
            double wynik = 0;
            if (!String.IsNullOrEmpty(pre_unit) && !String.IsNullOrEmpty(pre_value) && !String.IsNullOrEmpty(post_unit))
            {

                try
                {

                    if (pre_unit == "mile" && post_unit == "km")
                    {

                        int pre_v = Convert.ToInt32(pre_value);

                        wynik = pre_v * 1.609344;

                    }
                    else if (pre_unit == "km" && post_unit == "mile")
                    {
                        int pre_v = Convert.ToInt32(pre_value);

                        wynik = pre_v * 0.621371;

                    }
                    else if (pre_unit == "cm" && post_unit == "cale")
                    {
                        int pre_v = Convert.ToInt32(pre_value);
                        wynik = pre_v / 2.54;
                    }
                    else if (pre_unit == "cale" && post_unit == "cm")
                    {
                        int pre_v = Convert.ToInt32(pre_value);
                        wynik = pre_v * 2.54;
                    }

                }
                catch (Exception ex)
                {
                    err = ex.ToString();
                }
            }


            return wynik.ToString();
        }


        public IActionResult Stats()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            List<Stat> statystyki = new List<Stat>();

            Model m= new Model();
            statystyki = m.GetStats();

            ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();

            bool access = false;
            if (ViewBag.IP == "127.0.0.1" || ViewBag.IP == "192.168.3.177")
            {
                access = true;
            }
            else
            {
                access = false;
            }
            ViewBag.access = access;

            return View(statystyki);
        }

        public IActionResult Waluty()
        {
            List<Currency> curr = new List<Currency>();
            try
            {


                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
                foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
                {
                    Currency c = new Currency();
                    c.Cur = xmlNode.Attributes["currency"].Value;
                    c.DayValue = xmlNode.Attributes["rate"].Value;
                    curr.Add(c);
                }

                ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            }
            catch (Exception ex)
            {
                ViewBag.Rate = ex.ToString();

            }

            return View(curr);
        }
        [HttpGet]
        public IActionResult AddActivity()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            return View();
        }
        [HttpGet]
        public IActionResult AddActivityEnergy()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            Model m = new Model();
            m.InsertIPIntoDB((string)ViewBag.IP, "/Home/AddActivity");

            return View();
        }
        [HttpGet]
        public IActionResult AddActivityGas()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            Model m = new Model();
            
            m.InsertIPIntoDB((string)ViewBag.IP, "/Home/AddActivityGas");

            return View();
        }

        [HttpGet]
        public IActionResult AddActivityWoda()
        {
            ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;
            ViewBag.IP = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            Model m = new Model();
            
            m.InsertIPIntoDB((string)ViewBag.IP, "/Home/AddActivityWoda");

            return View();
        }

        public PartialViewResult GetEnergyRecord(int year)
        {

            ewidencjaContext ew = new ewidencjaContext();

            List<Energy> lista_en = new List<Energy>();
          

            var tze= ew.TblZuzycieEnergii.Where(a => a.Data.Value.Year == year).Select(x => new { x.Data, x.Kwh, x.WskLicznika }).ToList();

            if (year == 0)
            {
                tze = ew.TblZuzycieEnergii.Select(x => new { x.Data, x.Kwh, x.WskLicznika }).ToList();
            }

            foreach (var ze in tze) {

                Energy en = new Energy();
                en.data = ze.Data.ToString();
                en.kwh = Convert.ToInt32(ze.Kwh);
                en.stan_licznika = ze.WskLicznika.ToString();

                lista_en.Add(en);

            }

         
            return PartialView("_EnergyValuesPartial", lista_en);
        }

        public PartialViewResult GetGazRecord(int year)
        {

            ewidencjaContext ew = new ewidencjaContext();

            List<Gaz> lista_gaz = new List<Gaz>();


            var tzg = ew.TblZuzycieGazu.Where(a=>a.Data.Value.Year==year).OrderByDescending(a => a.Data).Select(x => new { x.Kwh, x.Data, x.WskLicznika });

            if (year == 0)
            {
               tzg= ew.TblZuzycieGazu.OrderByDescending(a => a.Data).Select(x => new { x.Kwh, x.Data, x.WskLicznika });
            }

            foreach (var entry in tzg)
            {
                Gaz g = new Gaz();

                g.kwh = entry.Kwh.ToString();
                g.data = entry.Data.ToString();
                g.stan_licznika = entry.WskLicznika.ToString();

                lista_gaz.Add(g);

            }


            return PartialView("_GazValuesPartial", lista_gaz);
        }


        
        public JsonResult GetEnergyChartYear()
        {
            List<Energy> energyyears = new List<Energy>();

            ewidencjaContext ew = new ewidencjaContext();

            var tze = ew.TblZuzycieEnergii.Select(x => new {  x.Data, x.WskLicznika }).ToList();

           
            foreach(var item in tze)
            {
                Energy e = new Energy();
              
                e.data = item.Data.ToString();
                e.stan_licznika = item.WskLicznika.ToString();

                energyyears.Add(e);
            }

            return Json(energyyears);
        }

        public JsonResult GetGazChartYear()
        {
            List<Gaz> gazyears = new List<Gaz>();

            ewidencjaContext ew = new ewidencjaContext();

            var tzg = ew.TblZuzycieGazu.Select(x => new { x.Data, x.WskLicznika }).ToList();
            

            foreach (var item in tzg)
            {
                Gaz g = new Gaz();

                g.data = item.Data.ToString();
                g.stan_licznika = item.WskLicznika.ToString();

                gazyears.Add(g);
            }

            return Json(gazyears);
        }

        public JsonResult GetMileAgeCarsChart()
        {
            List<Czynnosc> mileages = new List<Czynnosc>();

            ewidencjaContext ew = new ewidencjaContext();

            var cp = ew.CzynnosciPojazdy.Where(x=>x.IdPojazdu==1).Select(x => new { x.Data, x.Przebieg, x.OpisCzynnosci }).OrderBy(a=>a.Przebieg);

            foreach (var entry in cp)
            {
                Czynnosc c = new Czynnosc();

                c.data = entry.Data.ToString();
                c.przebieg = Convert.ToInt32(entry.Przebieg);
                c.opis = entry.OpisCzynnosci;
                
                mileages.Add(c);
            }

            List<Czynnosc> SortedList = mileages.OrderBy(o => o.przebieg).ToList();

            

            return Json(SortedList);
        }

        public PartialViewResult GetWodaRecord(int year)
        {

            ewidencjaContext ew = new ewidencjaContext();

            List<Woda> lista_woda = new List<Woda>();


            var tzg = ew.TblZuzycieWody.Where(a => a.Date.Value.Year == year).OrderByDescending(a => a.Date).Select(x => new {  x.Date, x.WskLicznika });

            if (year == 0)
            {
                tzg = ew.TblZuzycieWody.OrderByDescending(a => a.Date).Select(x => new {  x.Date, x.WskLicznika });
            }

            foreach (var entry in tzg)
            {
                Woda g = new Woda();

                g.data = entry.Date.ToString();
                g.wsk_licznika = entry.WskLicznika.ToString();

                lista_woda.Add(g);
            }


            return PartialView("_WodaValuesPartial", lista_woda);
        }

        [HttpPost]
        public String SaveActivityEnergy(string data, string licznik)
        {

            if (data != "" && licznik != "")
            {
                try
                {



                    //pobieranie ostatniej wartości licznika i wyliczenie kwh

                  

                    ewidencjaContext ew = new ewidencjaContext();

                    var tze=ew.TblZuzycieEnergii.OrderByDescending(x => x.Data).Select(x => x.WskLicznika).FirstOrDefault();
                  


                    int licz = Convert.ToInt32(licznik);
                    int kwh_l = Convert.ToInt32(tze.Value);
                    decimal difference = Math.Abs(licz - kwh_l);

                    System.Diagnostics.Trace.WriteLine("difference:  " + difference);
                    string kwh = "0";

                    kwh = difference.ToString();

                    System.Diagnostics.Trace.WriteLine("kwh:  " + kwh);

                  
                    TblZuzycieEnergii ze = new TblZuzycieEnergii();

                    ze.Data = Convert.ToDateTime(data);
                    ze.WskLicznika = Convert.ToDecimal(licznik);
                    ze.Kwh = Convert.ToDecimal(kwh);


                    ew.TblZuzycieEnergii.Add(ze);
                    ew.SaveChanges();

                    return "OK";

                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }

            }
            else
            {

                return "Nie wypełniono danych ";
            }

        }


        [HttpPost]
        public string SaveActivityWoda(string data, string licznik)
        {

            if (data != "" && licznik != "")
            {
                try
                {

                    ewidencjaContext ew = new ewidencjaContext();

                    TblZuzycieWody tzw = new TblZuzycieWody();

                    tzw.Date = Convert.ToDateTime(data);
                    tzw.WskLicznika = Convert.ToDecimal(licznik);

                    ew.TblZuzycieWody.Add(tzw);
                    ew.SaveChanges();

                    ViewBag.path = configuration.GetSection("AppSettings").GetSection("appath").Value;


                    return "OK";

                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }

            }
            else
            {

                return "Nie wypełniono danych ";
            }

        }
        [HttpPost]
        public String SaveActivity(string data, string przebieg, string opis,string pojazd)
        {
            string err = "";
            if (data != "" && przebieg != "" && opis != "")
            {
                ewidencjaContext ew = new ewidencjaContext();

                int exists_counter = 0;
                try
                {
                    //checking if entry exists
                    
                    DateTime dt = Convert.ToDateTime(data);

                    string dts = dt.ToString("yyyy-MM-dd HH:mm:ss");

                    DateTime dt_format = Convert.ToDateTime(dts);


                    var tcp = ew.CzynnosciPojazdy.Where(x => x.Data == dt && x.Przebieg == przebieg && x.OpisCzynnosci == opis).ToList().Count;

                    exists_counter = tcp;

                    //
                    if (exists_counter == 0)
                    {
                        CzynnosciPojazdy cp = new CzynnosciPojazdy();

                        cp.Data = dt_format;
                        cp.Przebieg =przebieg;
                        cp.OpisCzynnosci = opis;
                        cp.IdPojazdu =Convert.ToInt32(pojazd);
                        cp.IdVehicle= Convert.ToInt32(pojazd);

                        ew.CzynnosciPojazdy.Add(cp);

                        ew.SaveChanges();

                        return "OK";
                    }
                    else
                    {
                        err = "Wpis już istnieje !";
                        return err;
                    }

                }
                catch (Exception ex)
                {
                    err = ex.ToString();
                    return err;
                }

               
            }
            else
            {

                return err;
            }

        }

        [HttpPost]
        public String SaveActivityGas(string data, string licznik)
        {

            if (data != "" && licznik != "")
            {
                try
                {
                    //pobieranie ostatniej wartości licznika i wyliczenie kwh

                 
                    ewidencjaContext ew = new ewidencjaContext();
                   var wsk= ew.TblZuzycieGazu.OrderByDescending(a => a.Data).Select(a =>new { a.WskLicznika}).FirstOrDefault();
                   

                    int licz = Convert.ToInt32(licznik);

                    int kwh_l = Convert.ToInt32(wsk.WskLicznika);


                    decimal difference = Math.Abs(licz - kwh_l);

                    System.Diagnostics.Trace.WriteLine("difference:  " + difference);
                    string kwh = "0";

                    kwh = difference.ToString();                   

                    TblZuzycieGazu gz = new TblZuzycieGazu();

                    gz.Data = Convert.ToDateTime(data);
                    gz.WskLicznika = Convert.ToDecimal(licznik);
                    gz.Kwh = Convert.ToDecimal(kwh);

                    ew.TblZuzycieGazu.Add(gz);
                    ew.SaveChanges();

                  
                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }
                return "OK";
            }
            else
            {

                return "Nie wypełniono danych ";
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
