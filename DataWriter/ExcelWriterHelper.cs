using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Spaidy.DataWriter
{
    class ExcelWriterHelper
    {

        public static void WriteInToExcel(string xlpath, string sheet, int row, int col, string value)
        {
            try
            {

                XSSFWorkbook wb;
                using (FileStream file = new FileStream(xlpath, FileMode.Open, FileAccess.Read))
                {
                    wb = new XSSFWorkbook(file);
                }
                ISheet s = wb.GetSheet(sheet);
                IRow r = null;
                if (s.GetRow(row) == null)
                {
                    wb.GetSheet(sheet).CreateRow(row).CreateCell(col).SetCellValue(value);
                }
                else
                {
                    r = s.GetRow(row);
                    if (r.GetCell(col) == null)
                    {
                        wb.GetSheet(sheet).GetRow(row).CreateCell(col).SetCellValue(value);
                    }
                    else
                    {
                        wb.GetSheet(sheet).GetRow(row).GetCell(col).SetCellValue(value);
                    }

                }

                using (FileStream file = new FileStream(xlpath, FileMode.Create, FileAccess.Write))
                {
                    wb.Write(file);
                    // file.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Sheet is Not Available in Workbook , Please add " + sheet + "before Writting any thing on Workbook");

            }

        }


        public static void DeleteRow(String excelPath, String sheetName, int rowNo)
        {

            XSSFWorkbook workbook = null;
            XSSFSheet sheet = null;
            try
            {
                using (FileStream file = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }

                sheet = (XSSFSheet)workbook.GetSheet(sheetName);
                int lastRowNum = sheet.LastRowNum;
                XSSFRow removingRow = (XSSFRow)sheet.GetRow(rowNo);
                if (removingRow != null)
                {
                    sheet.RemoveRow(removingRow);
                }
                using (FileStream file = new FileStream(excelPath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);

                }

            }
            catch
            {

                throw;

            }
        }
    }
}


