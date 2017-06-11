using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MathsExpressionEvaluator;

namespace WebMathsExpEvaluator
{
    public class ExpressionController : ApiController
    {
        // GET api/<controller>
        public List<KeyValuePair<string, string>> Get()
        {
            return SessionBag.Current.ImportData;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
       public HttpResponseMessage Post([FromBody]string value)
       {
            ExpressionEvaluator eg = new ExpressionEvaluator();
            string reps = "";
            try
            {
                reps = eg.Evaluate(value).ToString();
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("Sorry this is too complex"))
                {
                    reps= "Sorry this is too complex";
                }
                else
                {
                    reps = "Error";
                }
            }

            //List<KeyValuePair<string, string>> ExpressionHistory = System.Web.HttpContext.Current.Session["ExpressionHistory"] as List<KeyValuePair<string, string>>;
            //if(ExpressionHistory == null)
            //{
            //    ExpressionHistory = new List<KeyValuePair<string, string>>();
            //}
            List<KeyValuePair<string, string>> ExpressionHistory = SessionBag.Current.ImportData;
            if (ExpressionHistory == null) ExpressionHistory = new List<KeyValuePair<string, string>>();

            KeyValuePair<string, string> exPressionValue = new KeyValuePair<string, string>(value,reps);
            // exPressionValue.a = value;
            ExpressionHistory.Add(exPressionValue);
            //System.Web.HttpContext.Current.Session["ExpressionHistory"] = ExpressionHistory;
            SessionBag.Current.ImportData = ExpressionHistory;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, reps);
            return response;
        }

        
        
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    //internal class ImportDataViewModel
    //{
    //    public ImportDataViewModel()
    //    {
    //        ExpressionHistory = new List<ImportDataFile>();
    //    }

    //    public List<KeyValuePair<string, string>> ExpressionHistory { get; set; }
    //}
}