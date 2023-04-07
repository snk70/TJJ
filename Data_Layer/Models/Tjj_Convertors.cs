using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Data_Layer
{
    public class Tjj_Convertors
    {

        private static string Persian_Date;
        private static string Time;
        private static string Date_and_Time;
        private static PersianCalendar pc = new PersianCalendar();
        public static string Get_Date_and_Time(DateTime dt)
        {
            Persian_Date = pc.GetYear(dt) + "/" + pc.GetMonth(dt).ToString("00") + "/" + pc.GetDayOfMonth(dt).ToString("00");
            Time = pc.GetHour(dt).ToString("00") + ":" + pc.GetMinute(dt).ToString("00") + ":" + pc.GetSecond(dt).ToString("00");
            Date_and_Time = Persian_Date + " - " + Time;

            return Date_and_Time;
        }


        //0 => Registered only, 1 => verify Email,  => 2 Verify SMS, => Verify Email and SMS, -1 => Rejected
        private static string str_status = "وضعیت";
        public static string Get_User_Status(int u_Stat)
        {
            switch (u_Stat)
            {
                case 0:
                    str_status = ("ثبت نام شده");
                    break;

                case 1:
                    str_status = ("ایمیل تأیید شده");
                    break;

                case 2:
                    str_status = ("شماره موبایل تأیید شده");
                    break;

                case 3:
                    str_status = ("شماره موبایل و ایمیل تأیید شده");
                    break;
            }
            return str_status;
        }

        //0 => Customer  , 1 => Seller ,  => 2 Seller and Customer
        public static string Get_User_Type(int u_type)
        {
            switch (u_type)
            {
                case 0:
                    return "سرمایه گذار";
                case 1:
                    return "فروشنده";
                case 2:
                    return "فروشنده و سرمایه گذار";
                default:
                    return "";
            }
        }

        //0 => Requested  , 1 => Confirmed ,  => -1 Rejected
        public static string Get_Deposit_Status(int u_type)
        {
            switch (u_type)
            {
                case 0:
                    return "ثبت شده";
                case 1:
                    return "تأیید شده";
                case -1:
                    return "مردود";
                default:
                    return "";
            }
        }


        public static string GetClearNumber(string PriceValue)
        {
            if (PriceValue == "")
            {
                return "";
            }else if(PriceValue == "0")
            {
                return "0";
            }
            else
            {
                PriceValue = string.Format("{0:N0}", double.Parse(PriceValue.Replace(",", "")));
                return PriceValue;
            }
        }



    }

}