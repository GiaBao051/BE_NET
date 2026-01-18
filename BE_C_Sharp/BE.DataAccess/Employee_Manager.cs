using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

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
                if (!BE.Common.ValidateDataInput.CheckValidateString(EmployeeIDInput)
                    || !BE.Common.ValidateDataInput.CheckXSSInput(EmployeeIDInput))
                {
                    result = (int)EmployeeManagerStatus.invalidID;
                    return result;
                }

                if (!BE.Common.ValidateDataInput.CheckValidateString(EmployeeName)
                    || !BE.Common.ValidateDataInput.CheckXSSInput(EmployeeName))
                {
                    result = (int)EmployeeManagerStatus.invalidName;
                    return result;
                }

                //Check trùng
                var isDuplicate = false;
                for (int i = 0; employeers.Count > 0; i++)
                {
                    if (employeers[i].EmployeeID == EmployeeIDInput)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (isDuplicate)
                {
                    result = (int)EmployeeManagerStatus.duplicate;
                    return result;
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

        public string Employeer_Insert_FromExcelFile(string filePath)
        {
            var result = string.Empty;
            var errName = new StringBuilder();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {

                        var code = worksheet.Cells[row, 1].Text;
                        var name = worksheet.Cells[row, 2].Text;
                        var startDate = worksheet.Cells[row, 3].Text;

                        if (!BE.Common.ValidateDataInput.CheckValidateString(code)
                    || !BE.Common.ValidateDataInput.CheckXSSInput(code)
                    )
                        {
                            errName.Append("Hàng : " + row + "| Cột 0 dữ liệu không hợp lệ");
                            continue;
                        }
                        if (!BE.Common.ValidateDataInput.CheckValidateString(name)
                 || !BE.Common.ValidateDataInput.CheckXSSInput(name)
                 )
                        {
                            errName.Append("Hàng : " + row + "| Cột 1 dữ liệu không hợp lệ");
                            continue;
                        }
                    }

                    Console.WriteLine();
                }

                if (errName != null)
                {
                    return errName.ToString();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
