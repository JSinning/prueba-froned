using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace frontend__prueba
{
    public partial class Form1 : Form
    {
        public string url = "https://jsonplaceholder.typicode.com";
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string respuesta = await postGet();
            //Console.WriteLine(respuesta);
            List<petitionGET> lista = JsonConvert.DeserializeObject<List<petitionGET>>(respuesta);
            foreach(petitionGET dta in lista)
            {
                Console.WriteLine(dta.id);
                //item.SubItems.Add();
               listView1.Items.Add(dta.title);
                listView1.Items.Add(dta.id.ToString());

            }
        }

        public async Task<string> postGet()
        {
            WebRequest request = WebRequest.Create(url + "/posts/");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            return await stream.ReadToEndAsync();
        }

       
    }
}
