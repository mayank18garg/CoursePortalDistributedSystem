using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Runtime.Serialization;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ans;
            AddCoursesService.AddCoursesServiceClient addcourseservice = new AddCoursesService.AddCoursesServiceClient();
            try
            {
                ans = addcourseservice.addCourse(TextBox1.Text, TextBox2.Text, Convert.ToInt32(TextBox3.Text), TextBox4.Text);
            }
            catch
            {
                ans = "Please enter correct format";
            }
            Label6.Text = ans;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //            Uri baseUri = new Uri("http://localhost:54866/RegisterCourseService.svc");
            Uri baseUri = new Uri("http://webstrar71.fulton.asu.edu/page0/RegisterCourseService.svc");

            UriTemplate myTemplate = new UriTemplate("Registercourse?courseCode={courseCode}&userName={userName}");
            Uri completeUri = myTemplate.BindByPosition(baseUri, TextBox5.Text, TextBox6.Text);
            WebClient channel = new WebClient();
            byte[] abc = channel.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));

            string randString = obj.ReadObject(strm).ToString();
         
            Label10.Text = randString;
        }
    }
}