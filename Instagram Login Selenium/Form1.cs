using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Instagram_Login_Selenium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        ChromeDriver drv; Thread th;
        // usrn =nzmslym_rec
        string url = "https://www.instagram.com/accounts/login/";
        private void TestNullTxtBox(object sender, EventArgs e)
        {
            string username = username_txtBox.Text;
            string password= password_txtBox.Text;

            if (username != "" && password != "")
            {
                Login_BTN.ForeColor = Color.Lime;
                Login_BTN.Cursor = Cursors.Hand;
            }
            else
            {
                Login_BTN.ForeColor = Color.Red;
                Login_BTN.Cursor = Cursors.No;
            }
        }
        // Tested true login

        private void Form1_Load(object sender, EventArgs e)
        {
            drv = new ChromeDriver();
            drv.Navigate().GoToUrl(url);
        }

        private void Login_BTN_Click(object sender, EventArgs e)
        {
            if (Login_BTN.ForeColor == Color.Lime)
            {
                th = new Thread(Login_Instagram); th.Start();
            }
        }

        private void Login_Instagram()
        {
            try
            {
                drv.FindElements(By.XPath("//input[@class='_2hvTZ pexuQ zyHYP']"))[0].SendKeys(username_txtBox.Text); Thread.Sleep(2000);
                drv.FindElement(By.XPath("//article[@class='agXmL']")).Click(); Thread.Sleep(2000);
                // Focused Exception
                drv.FindElements(By.XPath("//input[@class='_2hvTZ pexuQ zyHYP']"))[1].SendKeys(password_txtBox.Text); Thread.Sleep(2000);

                drv.FindElement(By.XPath("//button[@class='sqdOP  L3NKy   y3zKF     ']")).Click(); Thread.Sleep(2000);
                if(drv.Url== "https://www.instagram.com/")
                    MessageBox.Show("Login !");
                else
                    MessageBox.Show("Error !");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            // button class = sqdOP  L3NKy   y3zKF     
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            drv.Quit();
        }
        // THANKS FOR WATCHING :)
    }
}
