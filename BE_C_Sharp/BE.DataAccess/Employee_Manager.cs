using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.DataAccess
{
    public class Employee_Manager
    {
        public int Employeer_Insert(string EmployeeIDInput, string EmployeeName, DateTime StartJoin)
        {
            List<BE.DataAccess.Struct.Employeer> employeers = new List<BE.DataAccess.Struct.Employeer>();
            var result = 0;
            try
            {
                //Kiểm tra dữ liệu đầu vào
                if(!BE.Common.ValidateDataInput.CheckValidateString(EmployeeIDInput)
                    || !BE.Common.ValidateDataInput.CheckXSSInput(EmployeeIDInput))
                {
                    result = (int)EmployeeManagerStatus.invalidID;
                }

                if (!BE.Common.ValidateDataInput.CheckValidateString(EmployeeName)
                    || !BE.Common.ValidateDataInput.CheckXSSInput(EmployeeName))
                {
                    result = (int)EmployeeManagerStatus.invalidName;
                }

                //Check trùng
                var isDuplicate = false;
                for (int i = 0; employeers.Count > 0; i++)
                {
                    if(employeers[i].EmployeeID == EmployeeIDInput)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if(isDuplicate)
                {
                    result = (int)EmployeeManagerStatus.duplicate;
                }

                //Thêm vào danh sách và nhận kết quả
                var newEmployeer = new BE.DataAccess.Struct.Employeer()
                {
                    EmployeeID = EmployeeIDInput,
                    EmployeeName = EmployeeName,
                    StartJoin = StartJoin
                };
                employeers.Add(newEmployeer);

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ngoại lệ: " + ex.Message);
            }
            return result;
        }
    }
}
