using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_train
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }
       
        public CefSharp.WinForms.ChromiumWebBrowser br;

        private void loadall()
        {
            string reffer = "";
            count = 2;
            string postData = "javascriptEnabled=true&_csrf=" + _csrf + "&passwordType=NORMAL&username=" + _license + "&password=" + _reference + "&alternativePassword=&booking-login=Continue";
            //   PostData("https://driverpracticaltest.dvsa.gov.uk/login", PostData);
            link = "https://driverpracticaltest.dvsa.gov.uk/login";
            byte[] bytes = Encoding.ASCII.GetBytes(postData);
            //  string x = await Post(link, bytes, _browser);
            //LoadPost(link, postData);


            Thread.Sleep(5000);
            //edit date
            count = 3;
            link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=editTestDateTime";
            reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
            _executionSerial = "";

           
         //   br.(link,reffer)
            br.Load(link);



            Thread.Sleep(5000);
            while (!(_executionSerial.Length > 1))
            {
                Thread.Sleep(200);

            }

            //change date
            count = 4;
                            link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=proceed";
            reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
            _executionSerial = "";
                         postData = "_csrf=" + _csrf + "&testChoice=DATE&preferredTestDate=09/04/22&drivingLicenceSubmit=Continue";
                        bytes = Encoding.ASCII.GetBytes(postData);
                        LoadPost(link, postData, reffer);

          //  LoadGet(link, reffer);
            Thread.Sleep(5000);

            while (!(_executionSerial.Length > 1))
            {
                Thread.Sleep(200);

            }

            //change center
            count = 5;
                         link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=changeTestCentre";
            reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
            _executionSerial = "";
                         br.Load(link);
           

            Thread.Sleep(5000);
            while (!(_executionSerial.Length > 1))
            {
                Thread.Sleep(200);

            }

            //search center
            count = 6;
                        Random rnd = new Random();
                        while (true)
                        {
                            link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=search";
                              reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
                            _executionSerial = "";
                             postData = "_csrf=" + _csrf + "&testCentreName=" + _testCenter + "&testCentreSubmit=Find+test+centres";

                            bytes = Encoding.ASCII.GetBytes(postData);
                                 LoadPost(link, postData, reffer);
              
                          

                           

                            if (_centerId.Length > 1)
                            { count = 7;
                                break;
                            }

                            Thread.Sleep(5000 + rnd.Next(0, Convert.ToInt32(textBox7.Text)));

                        }
           // Thread.Sleep(2000);
            while (!(_executionSerial.Length > 1))
            {
                Thread.Sleep(200);

            }

            // in center find slot
            link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=proceed&centreID=" + _centerId;
            reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
            _executionSerial = "";
                         br.Load(link);


            //      Thread.Sleep(2000);

            while (!(_executionSerial.Length > 1))
            {
                Thread.Sleep(200);

            }

            while (true)
            {

                if (_slot.Length > 1)
                {
                    count = 8;




                    link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=proceed";
                    reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
                    _executionSerial = "";
                    postData = "_csrf=" + _csrf + "&slotWarningAcknowledged=true&slotTime=" + _slot;
                    bytes = Encoding.ASCII.GetBytes(postData);
                    LoadPost(link, postData, reffer);
                  

                    Thread.Sleep(2000);

                    while (!(_executionSerial.Length > 1))
                    {
                        Thread.Sleep(200);

                    }

                    count = 9;
                    link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=candidate";
                    reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
                    _executionSerial = "";
                    br.Load(link);
                  

              //      Thread.Sleep(2000);
                    //    _slot = findslot(Text, "July 2022");
                    while (!(_executionSerial.Length > 1))
                    {
                        Thread.Sleep(200);

                    }
                    // return;
                    Debug.WriteLine("Came Here");
                    //confirm
            
                            count = 10;
                    link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=proceed";
                    reffer = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial;
                    _executionSerial = "";
                    postData = "_csrf=" + _csrf + "&isConfirm=true";
                    bytes = Encoding.ASCII.GetBytes(postData);
                    //  link = "https://driverpracticaltest.dvsa.gov.uk/manage?execution=" + _executionSerial + "&_eventId=abandon";
                     LoadPost(link, postData, reffer);
                  //  WriteLog(x.ToString(), "10th page", 1010);

                }
                Thread.Sleep(1000);

            }



        }


        string findcenter(string text, string subdate, string nocenter)
        {
            if (!text.Contains(subdate))
            {
                return "";

            }

            text = text.Substring(text.IndexOf(subdate) - 450, 450);
            if (text.Contains(nocenter))
            {
                return "";
            }
            string first = "centreID=";
            string last = "\" id";
            string x = text.Substring(text.IndexOf(first) + first.Length);
            string output = x.Substring(0, x.IndexOf(last));

            return output;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _license = textBox1.Text;
            _reference = textBox2.Text;
            _testCenter = textBox3.Text;
             subdate = textBox4.Text;
            nocenter = textBox5.Text;
            DateTime dt = DateTime.ParseExact("01" + subdate, "dd/MM/yyyy", null);
            submonthyear = dt.ToString("MMMM") + " " + dt.ToString("yyyy");


            Thread tr = new Thread(loadall);
            tr.Start();

     
        }
        string _license = "";
        string _reference = "";
        string _executionSerial = "";
        string _centerId = "";
        string _slot = "";
        string _testCenter = "";
        string subdate = "";
        string submonthyear = "";
        string nocenter = "";
        string link = "";
        int count = 0;
        string _csrf = "";
        string currentUrl = "";

        public void LoadPost(string url, string postData, string referer)
        {
            var frame = br.GetMainFrame();

            //Create a new request knowing we'd like to use PostData
            var request = frame.CreateRequest(initializePostData: true);
            request.Method = "POST";
            request.Url = url;
            //Set AllowStoredCredentials so cookies are sent with Request
            request.Flags = UrlRequestFlags.AllowStoredCredentials;
            request.PostData.AddData(postData);
            request.Headers.Add("Referer", referer);
            frame.LoadRequest(request);
        }
      
        private void test_Load(object sender, EventArgs e)
        {
        
           
            loadbr();

           //
            string lnk = "https://driverpracticaltest.dvsa.gov.uk/login";

            br.Load(lnk);

            
        }
        void loadbr()
        {
            br = new CefSharp.WinForms.ChromiumWebBrowser()
            {

                Dock = DockStyle.Fill,
                BrowserSettings = new BrowserSettings()

     


            };
           
            br.BrowserSettings.ImageLoading = CefState.Enabled;
            br.BrowserSettings.Javascript = CefState.Enabled;
         

            br.AddressChanged += Browser_AddressChanged;
            br.FrameLoadEnd += Browser_FrameLoadEnd;
          
            this.panel1.Controls.Add(br);

        }
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            currentUrl = e.Address;
           
        }
        async void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            //  Debug.WriteLine("cef-" + e.Url);

            //   if (e.Frame.IsMain)
            //   {
            string test = await e.Frame.GetSourceAsync();
            if (_csrf.Length > 1)
            {
                Debug.WriteLine(test);
            }
            else
            {
                _csrf = findcsrf(test);
                if (_csrf.Length > 1)
                {
                    WriteLog(test.ToString(), "1st page", 1010);

                    if (textBox6.InvokeRequired)

                    {

                        textBox6.Invoke((MethodInvoker)delegate { textBox6.Text = textBox6.Text + "Ready To Start :" + _csrf + Environment.NewLine; });

                    }
               
                }

            }

            
                if (_executionSerial.Length > 1)
                {

                }
                else
                {
                    _executionSerial = findit(test, "execution=", "&amp;");
                    if (_executionSerial.Length > 1)
                    {
                        WriteLog(test.ToString(), count + " page", 1010);
                        if (textBox6.InvokeRequired)

                        {
                        
                            textBox6.Invoke((MethodInvoker)delegate { textBox6.Text = textBox6.Text + "Logged In :" + _executionSerial + Environment.NewLine; });

                        }
                      
                    }
                }
            

            if (count == 6)
            {

               

                if (_centerId.Length > 1)
                {

                }
                else
                {
                    _centerId = findcenter(test, subdate, nocenter);
                    if (_centerId.Length > 1)
                    {
                        WriteLog(test.ToString(), count + " page", 1010);
                        if (textBox6.InvokeRequired)

                        {
                            
                            textBox6.Invoke((MethodInvoker)delegate { textBox6.Text = textBox6.Text + "Got Center  :" + _centerId + " Logged In :" + _executionSerial +  Environment.NewLine; });

                        }
                        
                    }
                }
              

            }
            if(count == 7)
            {
              

                if (_slot.Length > 1)
                {

                }
                else
                {
                    _slot = findslot(test, submonthyear);
                    if (_slot.Length > 1)
                    {
                        WriteLog(test.ToString(), count + " page", 1010);
                        if (textBox6.InvokeRequired)

                        {
                            //   count = 3;
                            textBox6.Invoke((MethodInvoker)delegate { textBox6.Text = textBox6.Text + "Got Slot  :" + _slot + " Got Center  :" + _centerId + " Logged In :" + _executionSerial + Environment.NewLine; });

                        }
                      
                    }
                }
            }
           
        }

        string findslot(string text, string subdate)
        {
            if (!text.Contains(subdate))
            {
                return "";

            }

            text = text.Substring(text.IndexOf(subdate) + subdate.Length, 200);

            string first = "\" for=\"slot-";
            string last = "\">";
            string x = text.Substring(text.IndexOf(first) + first.Length);
            string output = x.Substring(0, x.IndexOf(last));

            return output;

        }
        string findcsrf(string text)
        {
            if (!text.Contains("_csrf\" value=\""))
            {
                return "";
            }
            string x = text.Substring(text.IndexOf("_csrf\" value=\"") + "_csrf\" value=\"".Length);
            string csrf = x.Substring(0, x.IndexOf("\">"));

            return csrf;

        }
        string findit(string text, string first, string last)
        {
            if (!text.Contains(first))
            {
                return "";
            }
            string x = text.Substring(text.IndexOf(first) + first.Length);
            string output = x.Substring(0, x.IndexOf(last));

            return output;

        }

        public static void WriteLog(string strLog, string name, int i)
        {
            try
            {
                if (name.Length > 0)
                {
                    name = name + "-";
                }
                string logFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Logs\\Log-" + name.ToString() + i.ToString() + "_" + DateTime.Now.ToString("yyyyMMddTHHmmssfff").ToString() + "." + "txt";
               
                FileInfo logFileInfo = new FileInfo(logFilePath);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + strLog);
                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lnk = "https://driverpracticaltest.dvsa.gov.uk/login";

            br.Load(lnk);
        }
    }
}
