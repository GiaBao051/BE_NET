using BE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var employeerManager = new Employee_Manager();

            var result = employeerManager.Employeer_Insert("<applet", "Hoàn Kim", DateTime.Now);

            switch (result)
            {
                case (int)EmployeeManagerStatus.success:
                    Console.WriteLine("Thêm thành công!");
                    break;

                case (int)EmployeeManagerStatus.invalidID:
                    Console.WriteLine("Mã nhân viên không hợp lê!");
                    break;

                case (int)EmployeeManagerStatus.invalidName:
                    Console.WriteLine("Tên nhân viên không hợp lê!");
                    break;
            }
        }
    }
}
