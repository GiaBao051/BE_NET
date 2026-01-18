using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE.Common
{
    public static class ValidateDataInput
    {
        //Kiểm tra số nguyên
        public static bool CheckValidInputNumber(string inputNumber)
        {
            if (string.IsNullOrEmpty(inputNumber))
            {
                return false;
            }

            inputNumber = inputNumber.Trim();

            if (!int.TryParse(inputNumber, out int num))
            {
                return false;
            }

            return true;
        }

        //Kiểm tra chuỗi không phải là số và không quá 200 ký tự
        public static bool CheckValidateString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }

            if (int.TryParse(inputString, out int num))
            {
                return false;
            }

            if (inputString.Length > 200)
            {
                return false;
            }

            return true;
        }

        //Kiểm tra kí tự đặt biệt ( không được có kí tự đặc biệt)
        public static bool CheckSpecicalCharacter(string inputString)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(inputString)) { return false; }
            return true;
        }

        //Kiểm tra các từ khóa nguy hiểm trong XSS
        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };

                if (string.IsNullOrEmpty(input)) return false;

                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
