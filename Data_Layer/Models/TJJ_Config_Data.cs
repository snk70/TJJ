using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;


namespace Data_Layer
{
    public static class TJJ_Config_Data
    {
        public static string deposit_img_Svae_Path = "~/Areas/Admin/files/deposit_info";

        public static string Get_Uniq_File_Name(string IMG_File_Name)
        {
            return Guid.NewGuid() + Path.GetExtension(IMG_File_Name);
        }

        public static string Get_Full_Path_Deposit_File(string File_Name)
        {
            return deposit_img_Svae_Path + "/" + File_Name;
        }


        public static bool StringIsNumberDouble(string NumberValue)
        {
            try
            {
                double d = double.Parse(NumberValue);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public static class Mail_Sender_Info
        {
            //public MailMessage Mail_Message = new MailMessage();
            public static SmtpClient Smtm_Server = new SmtpClient("mail.sorenmedical.ir", 587);
            public static MailAddress Mail_Address = new MailAddress("tjj@sorenmedical.ir", "TJJ تجارت آنلاین طلا");
            public static System.Net.NetworkCredential Crendential = new System.Net.NetworkCredential("tjj@sorenmedical.ir", "653@Rayan");
        }

        public static bool IsTradeOpen;
        public static float GoldPriceRial;
        public static void InitializeTradeValues()
        {
            if (GoldPriceRial <= 0)
            {
                GoldPriceRial = 10000000;
                IsTradeOpen = false;
            }
        }
        #region جداکننده سه رقم سه رقم
        public static string GetGoldPriceClear(string PriceValue)
        {
            InitializeTradeValues();
            if (PriceValue == "" || PriceValue == "0")
            {
                return "";
            }
            else
            {
                PriceValue = string.Format("{0:N0}", double.Parse(PriceValue.Replace(",", "")));
                return PriceValue;
            }
        }
        public static string GetGoldPriceClear()
        {
            InitializeTradeValues();
            return GetGoldPriceClear(GoldPriceRial.ToString());
        }
        #endregion
        public static double RequestGoldPriceToRial(double GoldGramReq)
        {
            return GoldGramReq * GoldPriceRial;
        }

        public static double RequestRialToGram(double RialCharge)
        {
            return RialCharge / GoldPriceRial;
        }

        public static double GetGoldValueWithDecrease(double GoldValue, double TValue)
        {
            return GoldValue - (GoldValue * TValue);
        }


    }
}
