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
using Newtonsoft.Json;

namespace Weatherss
{
    public partial class Form1 : Form
    {
        const string APPID = "a7fd91410c0f31a52bbb77660bef5394";
        string cityID = "1566083";
        public Form1()
        {
            InitializeComponent();
            GetWeather("1566083");
            //geForcast("1566083");
        }
        void GetWeather(string city)
        {
            //&units=metric&cnt=6
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric&cnt=6", cityID, APPID);
            using (WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                WeatherInfo.root output = result;

                lbl_TextCity.Text = string.Format("{0}", output.name);
                lbl_Country.Text = string.Format("{0}", output.sys.country);
                lbl_DoCe.Text = string.Format("{0} \u00B0" + "C", output.main.temp);
            }


        }
        //void geForcast(string city)
        //{

        //    int day = 5;
        //        string url = string.Format("http://api.openweathermap.org/data/2.5/forcast/daily?id={0}&units=metric&cnt={1}&appid={2}", city, day, APPID); ;
        //        using (WebClient web = new WebClient())
        //        {

        //            var json = web.DownloadString(url);
        //            var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);
        //            WeatherForcast forcasts = Object;

        //            lbl_Con.Text = string.Format("{0}", forcasts.list[1].weather[0].main);
        //            lbl_Des.Text = string.Format("{0}", forcasts.list[1].weather[0].descriptions);
        //            lbl_Des2.Text = string.Format("{0} \u00B0" + "C", forcasts.list[1].temp);
        //            lbl_speed.Text = string.Format("{0}", forcasts.list[1].speed);

        //        }
            
        //}
    }
}


