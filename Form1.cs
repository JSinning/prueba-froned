using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string usersrespueta = await usersGet();
            //Console.WriteLine(respuesta);
            List<petitionGET> lista = JsonConvert.DeserializeObject<List<petitionGET>>(respuesta);
            List<petitionUsersGet> userlist = JsonConvert.DeserializeObject<List<petitionUsersGet>>(usersrespueta);
            foreach (petitionGET dta in lista)
            {
                ListViewItem item = new ListViewItem(dta.id.ToString());
                foreach(petitionUsersGet dtusers in userlist)
                {
                    if(dtusers.id == dta.userid)
                    {
                        item.SubItems.Add(dtusers.name);
                    }
                }

                item.SubItems.Add(dta.title);
                item.SubItems.Add(dta.body);
                listView1.Items.Add(item);

            }
        }

        public async Task<string> postGet()
        {
            WebRequest request = WebRequest.Create(url + "/posts/");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            return await stream.ReadToEndAsync();
        }

        public async Task<string> usersGet()
        {
            WebRequest request = WebRequest.Create(url + "/users");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            return await stream.ReadToEndAsync();
        }
    }
}
