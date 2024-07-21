using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _20240712_Ideagen.Controllers
{
    [Route("api/[controller]")]
    public class ideagenController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<string> Get(string value)
        {
            //step 01 : remove the space to make it all the same
            string valueRemoveSpace = value.Replace(" ", "");

            //step 02 : only space in front of capital letter.
            string newValue = Regex.Replace(valueRemoveSpace, "([a-z])([A-Z])", "$1 $2");

            //step 03 : put all string in a list 
            List<string> valuesList = new List<string>();
            foreach (string a in newValue.Split(" "))
            {
                valuesList.Add(a);
            }

            //step 04 : arrange the sequence
            List<returnValueWithNumber> returnValueList = valuesList.GroupBy(s => s)
                .Select(s => new returnValueWithNumber
                {
                    text2 = s.Key,
                    numberApper = s.Count()
                })
                .OrderByDescending(o => o.numberApper).ThenByDescending(o => o.text2).ToList();

            //step 05 : display it based on request format.
            List<string> valueReturn = returnValueList.Select(s => string.Concat(s.text2, " ", s.numberApper)).ToList();

            return valueReturn;
        }
    }

    public class returnValueWithNumber
    {
        public string text2 { get; set; }
        public int numberApper { get; set; }
    }
}

