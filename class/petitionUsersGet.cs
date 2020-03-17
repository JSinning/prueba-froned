using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend__prueba
{
    class petitionUsersGet
{
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
       public string email { get; set; }   
        public address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public company company { get; set; }
}

    class address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public geo geo { get; set; }

    }
    class geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }
    class company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
            
    }
}
