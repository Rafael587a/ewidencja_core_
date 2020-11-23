using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using log4net;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace core_ewidencja.Models
{
    public class Model
    {

        public AppDataBase Db { get; }

       

        public void InsertIPIntoDB(string ip, string page)
        {
           
            try
            {

                ewidencjaContext ew = new ewidencjaContext();

                
                DateTime curr = DateTime.Now;
                TblStats ts = new TblStats();

                ts.DateVisited = curr;
                ts.VisitHostIp = ip;
                ts.Page = page;

                ew.TblStats.Add(ts);
                ew.SaveChanges();
                

            } catch (Exception ex) {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
               
            }

        }
        public List<Stat> GetStats()
        {
            List<Stat> statystyki_list = new List<Stat>();

            try
            {
                ewidencjaContext ew = new ewidencjaContext();

                var ts = ew.TblStats.Select(a => new { a.Id, a.VisitHostIp, a.DateVisited, a.Page });

                foreach (var entry in ts)
                {

                    Stat s = new Stat();
                    s.id = entry.Id;
                    s.visit_host_ip = entry.VisitHostIp;
                    s.date_visited = Convert.ToDateTime(entry.DateVisited);
                    s.page = entry.Page;

                    statystyki_list.Add(s);
                }

            }catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
         
            return statystyki_list;
        }

        public string InsertIntoDBCurrences(List<Currency> curr)
        {

            if (curr.Count > 0)
            {

                //checking if date exists in table

               

                try
                {


                    string mnt = "", day = "";

                    if (DateTime.Now.Month == 1)
                    {
                        mnt = "01";
                    }
                    else if (DateTime.Now.Month == 2)
                    {
                        mnt = "02";
                    }
                    else if (DateTime.Now.Month == 3)
                    {
                        mnt = "03";
                    }
                    else if (DateTime.Now.Month == 4)
                    {
                        mnt = "04";
                    }
                    else if (DateTime.Now.Month == 5)
                    {
                        mnt = "05";
                    }
                    else if (DateTime.Now.Month == 6)
                    {
                        mnt = "06";
                    }
                    else if (DateTime.Now.Month == 7)
                    {
                        mnt = "07";
                    }
                    else if (DateTime.Now.Month == 8)
                    {
                        mnt = "08";
                    }
                    else if (DateTime.Now.Month == 9)
                    {
                        mnt = "09";
                    }
                    else
                    {
                        mnt = DateTime.Now.Month.ToString();
                    }

                    if (DateTime.Now.Day == 1)
                    {
                        day = "01";
                    }
                    else if (DateTime.Now.Day == 2)
                    {
                        day = "02";
                    }
                    else if (DateTime.Now.Day == 3)
                    {
                        day = "03";
                    }
                    else if (DateTime.Now.Day == 4)
                    {
                        day = "04";
                    }
                    else if (DateTime.Now.Day == 5)
                    {
                        day = "05";
                    }
                    else if (DateTime.Now.Day == 6)
                    {
                        day = "06";
                    }
                    else if (DateTime.Now.Day == 7)
                    {
                        day = "07";
                    }
                    else if (DateTime.Now.Day == 8)
                    {
                        day = "08";
                    }
                    else if (DateTime.Now.Day == 9)
                    {
                        day = "09";
                    }
                    else
                    {
                        day = DateTime.Now.Day.ToString();
                    }

                    DateTime current_date = DateTime.Now;

                    DateTime exists = DateTime.MinValue;

                    DateTime exist_d = DateTime.MinValue;



                    ewidencjaContext ew = new ewidencjaContext();

                    DateTime cd = Convert.ToDateTime(current_date);
                    var tbw = ew.TblWaluty.Where(a => a.InsDate == cd).Select(x => new { x.InsDate }).FirstOrDefault();


                    exists = tbw.InsDate.Value;



                    if (exists != current_date)
                    {

                        string usd_value = "", jpy_value = "", bgn_value = "", czk_value = "", dkk_value = "", gbp_value = "", huf_value = "", pln_value = "", ron_value = "", sek_value = "", chf_value = "", isk_value = "", nok_value = "", hrk_value = "", rub_value = "0", try_value = "0", aud_value = "0", brl_value = "0", cad_value = "0", cny_value = "0", hkd_value = "0", idr_value = "0", ils_value = "0", inr_value = "0", krw_value = "0", mxn_value = "0", myr_value = "0", nzd_value = "0", php_value = "0", sgd_value = "0", thb_value = "0", zar_value = "0";
                        foreach (var cur in curr)
                        {

                            if (cur.Cur == "USD")
                            {
                                usd_value = cur.DayValue;
                            }
                            if (cur.Cur == "JPY")
                            {
                                jpy_value = cur.DayValue;
                            }
                            if (cur.Cur == "BGN")
                            {
                                bgn_value = cur.DayValue;
                            }
                            if (cur.Cur == "CZK")
                            {
                                czk_value = cur.DayValue;
                            }
                            if (cur.Cur == "DKK")
                            {
                                dkk_value = cur.DayValue;
                            }
                            if (cur.Cur == "GBP")
                            {
                                gbp_value = cur.DayValue;
                            }
                            if (cur.Cur == "HUF")
                            {
                                huf_value = cur.DayValue;
                            }
                            if (cur.Cur == "PLN")
                            {
                                pln_value = cur.DayValue;
                            }
                            if (cur.Cur == "RON")
                            {
                                ron_value = cur.DayValue;
                            }
                            if (cur.Cur == "SEK")
                            {
                                sek_value = cur.DayValue;
                            }
                            if (cur.Cur == "CHF")
                            {
                                chf_value = cur.DayValue;
                            }
                            if (cur.Cur == "ISK")
                            {
                                isk_value = cur.DayValue;
                            }
                            if (cur.Cur == "NOK")
                            {
                                nok_value = cur.DayValue;
                            }
                            if (cur.Cur == "HRK")
                            {
                                hrk_value = cur.DayValue;
                            }
                            if (cur.Cur == "RUB")
                            {
                                rub_value = cur.DayValue;
                            }
                            if (cur.Cur == "TRY")
                            {
                                try_value = cur.DayValue;
                            }

                            if (cur.Cur == "AUD")
                            {
                                aud_value = cur.DayValue;
                            }
                            if (cur.Cur == "BRL")
                            {
                                brl_value = cur.DayValue;
                            }
                            if (cur.Cur == "CAD")
                            {
                                cad_value = cur.DayValue;
                            }
                            if (cur.Cur == "CNY")
                            {
                                cny_value = cur.DayValue;
                            }
                            if (cur.Cur == "HKD")
                            {
                                hkd_value = cur.DayValue;
                            }

                            if (cur.Cur == "ILS")
                            {
                                ils_value = cur.DayValue;
                            }
                            if (cur.Cur == "INR")
                            {
                                inr_value = cur.DayValue;
                            }
                            if (cur.Cur == "KRW")
                            {
                                krw_value = cur.DayValue;
                            }
                            if (cur.Cur == "MXN")
                            {
                                mxn_value = cur.DayValue;
                            }
                            if (cur.Cur == "MYR")
                            {
                                myr_value = cur.DayValue;
                            }
                            if (cur.Cur == "NZD")
                            {
                                nzd_value = cur.DayValue;
                            }
                            if (cur.Cur == "PHP")
                            {
                                php_value = cur.DayValue;
                            }
                            if (cur.Cur == "SGD")
                            {
                                sgd_value = cur.DayValue;
                            }
                            if (cur.Cur == "THB")
                            {
                                thb_value = cur.DayValue;
                            }
                            if (cur.Cur == "ZAR")
                            {
                                zar_value = cur.DayValue;
                            }

                        }


                        TblWaluty tw = new TblWaluty();

                        tw.InsDate = current_date;
                        tw.UsdValue = Convert.ToDecimal(usd_value);
                        tw.JpyValue= Convert.ToDecimal(jpy_value);
                        tw.BgnValue = Convert.ToDecimal(bgn_value);
                        tw.CzkValue = Convert.ToDecimal(czk_value);
                        tw.DkkValue= Convert.ToDecimal(dkk_value);
                        tw.GbpValue = Convert.ToDecimal(gbp_value);
                        tw.HufValue = Convert.ToDecimal(huf_value);
                        tw.PlnValue= Convert.ToDecimal(pln_value);
                        tw.RonValue = Convert.ToDecimal(ron_value);
                        tw.SekValue = Convert.ToDecimal(sek_value);
                        tw.ChfValue = Convert.ToDecimal(chf_value);
                        tw.IskValue = Convert.ToDecimal(isk_value);
                        tw.NokValue = Convert.ToDecimal(nok_value);
                        tw.HrkValue= Convert.ToDecimal(hrk_value);
                        tw.RubValue = Convert.ToDecimal(rub_value);
                        tw.TryValue = Convert.ToDecimal(try_value);
                        tw.AudValue = Convert.ToDecimal(aud_value);
                        tw.BrlValue = Convert.ToDecimal(brl_value);
                        tw.CadValue = Convert.ToDecimal(cad_value);
                        tw.CnyValue= Convert.ToDecimal(cny_value);
                        tw.HkdValue = Convert.ToDecimal(hkd_value);
                        tw.IdrValue = Convert.ToDecimal(idr_value);
                        tw.IlsValue = Convert.ToDecimal(ils_value);
                        tw.InrValue= Convert.ToDecimal(inr_value);
                        tw.KrwValue = Convert.ToDecimal(krw_value);
                        tw.MxnValue = Convert.ToDecimal(mxn_value);
                        tw.MyrValue = Convert.ToDecimal(myr_value);
                        tw.NzdValue= Convert.ToDecimal(nzd_value);
                        tw.PhpValue= Convert.ToDecimal(php_value);
                        tw.SgdValue = Convert.ToDecimal(sgd_value);
                        tw.ThbValue = Convert.ToDecimal(thb_value);
                        tw.ZarValue = Convert.ToDecimal(zar_value);

                        

                        ew.TblWaluty.Add(tw);
                        ew.SaveChanges();

                      
                    }
                    else if (exists == current_date)
                    { //update if date exists in column table

                        string usd_value = "", jpy_value = "", bgn_value = "", czk_value = "", dkk_value = "", gbp_value = "", huf_value = "", pln_value = "", ron_value = "", sek_value = "", chf_value = "", isk_value = "", nok_value = "", hrk_value = "", rub_value = "0", try_value = "0", aud_value = "0", brl_value = "0", cad_value = "0", cny_value = "0", hkd_value = "0", idr_value = "0", ils_value = "0", inr_value = "0", krw_value = "0", mxn_value = "0", myr_value = "0", nzd_value = "0", php_value = "0", sgd_value = "0", thb_value = "0", zar_value = "0";


                        AssignationValuesCurrencies(ref curr, ref usd_value, ref jpy_value, ref bgn_value, ref czk_value, ref dkk_value, ref gbp_value, ref huf_value, ref pln_value, ref ron_value, ref sek_value, ref chf_value, ref isk_value, ref nok_value, ref hrk_value, ref rub_value, ref try_value, ref aud_value, ref brl_value, ref cad_value,ref cny_value,ref hkd_value,ref idr_value,ref ils_value,ref inr_value,ref krw_value,ref mxn_value,ref myr_value,ref nzd_value,ref php_value,ref sgd_value ,ref thb_value ,ref zar_value );

                       

                        var entity = ew.TblWaluty.FirstOrDefault(item => item.InsDate == exists);
                        entity.UsdValue = Convert.ToDecimal(usd_value);
                        entity.JpyValue= Convert.ToDecimal(jpy_value);
                        entity.BgnValue = Convert.ToDecimal(bgn_value);
                        entity.CzkValue= Convert.ToDecimal(czk_value);


                        ew.TblWaluty.Update(entity);
                        ew.SaveChanges();

                       


                    }


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                   
                }
            }

            return "OK";
        }



        private void AssignationValuesCurrencies(ref List<Currency> curr, ref string usd_value, ref string jpy_value, ref string bgn_value, ref string czk_value, ref string dkk_value, ref string gbp_value, ref string huf_value, ref string pln_value, ref string ron_value, ref string sek_value, ref string chf_value, ref string isk_value, ref string nok_value, ref string hrk_value, ref string rub_value, ref string try_value, ref string aud_value, ref string brl_value, ref string cad_value, ref string cny_value, ref string hkd_value, ref string idr_value, ref string ils_value, ref string inr_value,ref string krw_value, ref string mxn_value, ref string myr_value, ref string nzd_value, ref string php_value, ref string sgd_value , ref string thb_value , ref string zar_value )
        {
            foreach (var cur in curr)
            {

                if (cur.Cur == "USD")
                {
                    usd_value = cur.DayValue;
                }
                if (cur.Cur == "JPY")
                {
                    jpy_value = cur.DayValue;
                }
                if (cur.Cur == "BGN")
                {
                    bgn_value = cur.DayValue;
                }
                if (cur.Cur == "CZK")
                {
                    czk_value = cur.DayValue;
                }
                if (cur.Cur == "DKK")
                {
                    dkk_value = cur.DayValue;
                }
                if (cur.Cur == "GBP")
                {
                    gbp_value = cur.DayValue;
                }
                if (cur.Cur == "HUF")
                {
                    huf_value = cur.DayValue;
                }
                if (cur.Cur == "PLN")
                {
                    pln_value = cur.DayValue;
                }
                if (cur.Cur == "RON")
                {
                    ron_value = cur.DayValue;
                }
                if (cur.Cur == "SEK")
                {
                    sek_value = cur.DayValue;
                }
                if (cur.Cur == "CHF")
                {
                    chf_value = cur.DayValue;
                }
                if (cur.Cur == "ISK")
                {
                    isk_value = cur.DayValue;
                }
                if (cur.Cur == "NOK")
                {
                    nok_value = cur.DayValue;
                }
                if (cur.Cur == "HRK")
                {
                    hrk_value = cur.DayValue;
                }
                if (cur.Cur == "RUB")
                {
                    rub_value = cur.DayValue;
                }
                if (cur.Cur == "TRY")
                {
                    try_value = cur.DayValue;
                }

                if (cur.Cur == "AUD")
                {
                    aud_value = cur.DayValue;
                }
                if (cur.Cur == "BRL")
                {
                    brl_value = cur.DayValue;
                }
                if (cur.Cur == "CAD")
                {
                    cad_value = cur.DayValue;
                }
                if(cur.Cur=="CNY")
                {
                    cny_value = cur.DayValue;
                }
                if(cur.Cur == "HKD")
                {
                    hkd_value = cur.DayValue;
                }
                if (cur.Cur == "IDR")
                {
                    idr_value = cur.DayValue;
                }
                if (cur.Cur == "ILS")
                {
                    ils_value = cur.DayValue;
                }
                if (cur.Cur == "INR")
                {
                    inr_value = cur.DayValue;
                }
                if (cur.Cur == "KRW")
                {
                    krw_value = cur.DayValue;
                }
                if (cur.Cur == "MXN")
                {
                    mxn_value = cur.DayValue;
                }
                if (cur.Cur == "MYR")
                {
                    myr_value = cur.DayValue;
                }
                if (cur.Cur == "NZD")
                {
                    nzd_value = cur.DayValue;
                }
                if (cur.Cur == "PHP")
                {
                    php_value = cur.DayValue;
                }
                if (cur.Cur == "SGD")
                {
                    sgd_value = cur.DayValue;
                }
                if (cur.Cur == "THB")
                {
                    thb_value = cur.DayValue;
                }
                if (cur.Cur == "ZAR")
                {
                    zar_value = cur.DayValue;
                }


                


            }

        }


    }
}
