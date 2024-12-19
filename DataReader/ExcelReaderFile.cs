using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace ExcelReader
{
    public class ExcelReaderFile : IDisposable
    {
        public string path;
        // public FileStream fs = null;
        private XSSFWorkbook workbook = null;
        //private ISheet sheet = null;
        //private IRow row = null;
        //private ICell cell = null;

        public ExcelReaderFile(string path)
        {
            this.path = path;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    workbook = new XSSFWorkbook(fs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetRowCount(string sheetName)
        {
            int index = workbook.GetSheetIndex(sheetName);
            if (index == -1)
            {
                return 0;
            }
            else
            {
                ISheet sheet = workbook.GetSheetAt(index);
                int number = sheet.LastRowNum + 1;
                return number;
            }
        }

        public int GetColumnCount(string sheetName)
        {
            if (!IsSheetExist(sheetName))
            {
                return -1;
            }

            ISheet sheet = workbook.GetSheet(sheetName);
            IRow row = sheet.GetRow(0);
            return (int)row?.LastCellNum;
        }

        public int GetRowNumber(string sheetName, int colNum, string value)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                workbook = new XSSFWorkbook(fs);
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    return 0;
                }

                ISheet sheet = workbook.GetSheetAt(index);
                for (int rw = 0; rw < sheet.LastRowNum; rw++)
                {
                    if (sheet.GetRow(rw) != null)
                    {
                        return (int)sheet.GetRow(rw)?.RowNum;
                    }
                }
            }
            return 0;
        }

        public string GetCellData(string sheetName, int colNum, int rowNum)
        {

            if (rowNum <= 0)
            {
                return "";
            }

            int index = workbook.GetSheetIndex(sheetName);
            if (index == -1)
            {
                return "";
            }

            ISheet sheet = workbook.GetSheetAt(index);
            IRow row = sheet.GetRow(rowNum - 1);
            if (row == null)
            {
                return "";
            }

            ICell cell = row.GetCell(colNum);
            if (cell == null)
            {
                return "";
            }

            if (cell.CellType == CellType.String)
            {
                return cell.StringCellValue;
            }
            else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
            {
                string cellText = Convert.ToString(cell.NumericCellValue);
                return cellText;
            }
            else if (cell.CellType == CellType.Blank)
            {
                return "";
            }
            else
            {
                return cell.BooleanCellValue.ToString();
            }
        }

        public string GetCellData(string sheetName, string colName, int rowNum)
        {
            if (rowNum <= 0)
            {
                return "";
            }

            int colNum = -1;
            int index = workbook.GetSheetIndex(sheetName);
            if (index == -1)
            {
                return "";
            }

            ISheet sheet = workbook.GetSheetAt(index);
            IRow row = sheet.GetRow(0);
            for (int i = 0; i < row.LastCellNum; i++)
            {
                if (row.GetCell(i).StringCellValue.Trim().Equals(colName.Trim()))
                {
                    colNum = i;
                }
            }
            if (colNum == -1)
            {
                return "";
            }

            sheet = workbook.GetSheetAt(index);
            row = sheet.GetRow(rowNum - 1);
            if (row == null)
            {
                return "";
            }

            ICell cell = row.GetCell(colNum);
            if (cell == null)
            {
                return "";
            }

            if (cell.CellType == CellType.String)
            {
                return cell.StringCellValue;
            }
            else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
            {
                string cellText = Convert.ToString(cell.NumericCellValue);
                return cellText;
            }
            else if (cell.CellType == CellType.Blank)
            {
                return "";
            }
            else
            {
                return cell.BooleanCellValue.ToString();
            }
        }

        public string SetCellData(string sheetName, string colName, int rowNum, string data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fs);
                if (rowNum <= 0)
                {
                    return "";
                }

                int colNum = -1;
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    return "";
                }

                ISheet sheet = workbook.GetSheetAt(index);
                IRow row = sheet.GetRow(0);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (row.GetCell(i).StringCellValue.Equals(colName))
                    {
                        colNum = i;
                    }
                }
                if (colNum == -1)
                {
                    return "";
                }

                row = sheet.GetRow(rowNum - 1);
                if (row == null)
                {
                    row = sheet.CreateRow(rowNum - 1);
                }

                ICell cell = row.GetCell(colNum - 1);
                if (cell == null)
                {
                    cell = row.CreateCell(colNum);
                }

                ICellStyle cs = workbook.CreateCellStyle();
                cs.WrapText = true;
                cell.CellStyle = cs;
                cell.SetCellValue(data);

                using (FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    workbook.Write(f);
                }
            }
            return data;

        }

        public string SetCellData(string sheetName, int colNum, int rowNum, string data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                workbook = new XSSFWorkbook(fs);
                if (rowNum <= 0)
                {
                    return "";
                }

                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    return "";
                }

                ISheet sheet = workbook.GetSheetAt(index);
                IRow row = sheet.GetRow(rowNum - 1);
                if (row == null)
                {
                    row = sheet.CreateRow(rowNum - 1);
                }

                ICell cell = row.GetCell(colNum - 1);
                if (cell == null)
                {
                    cell = row.CreateCell(colNum - 1);
                }

                ICellStyle cs = workbook.CreateCellStyle();
                cs.WrapText = true;
                cell.CellStyle = cs;
                cell.SetCellValue(data);

                using (FileStream f = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    workbook.Write(f);
                }
            }
            return data;
        }

        public bool AddSheet(string sheetName)
        {
            try
            {
                workbook.CreateSheet(sheetName);
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    workbook.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool RemoveSheet(string sheetName)
        {
            int index = workbook.GetSheetIndex(sheetName);
            if (index == -1)
            {
                return false;
            }

            try
            {
                workbook.RemoveSheetAt(index);
                using (FileStream fs = new FileStream(path, FileMode.Truncate))
                {
                    workbook.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool AddColumn(string sheetName, string colName)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook = new XSSFWorkbook(fs);
                int index = workbook.GetSheetIndex(sheetName);
                if (index == -1)
                {
                    return false;
                }

                ICellStyle cs = workbook.CreateCellStyle();
                ISheet sheet = workbook.GetSheetAt(index);
                IRow row = sheet.GetRow(0);
                if (row == null)
                {
                    row = sheet.CreateRow(0);
                }

                ICell cell = row.GetCell(0);
                if (cell == null)
                {
                    cell = row.CreateCell(0);
                }
                else
                {
                    cell = row.CreateCell(row.LastCellNum);
                }

                cell.SetCellValue(colName);
                cell.CellStyle = cs;

                using (FileStream f = new FileStream(path, FileMode.Create))
                {
                    workbook.Write(f);
                }
            }
            return true;
        }

        public bool RemoveColumn(string sheetName, int colNum)
        {
            if (!IsSheetExist(sheetName))
            {
                return false;
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheet(sheetName);
                ICellStyle cs = workbook.CreateCellStyle();
                for (int i = 0; i < GetRowCount(sheetName); i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row != null)
                    {
                        ICell cell = row.GetCell(colNum - 1);
                        if (cell != null)
                        {
                            cell.CellStyle = cs;
                            row.RemoveCell(cell);
                        }
                    }
                }
                using (FileStream f = new FileStream(path, FileMode.Truncate))
                {
                    workbook.Write(f);
                }
            }
            return true;
        }

        public bool IsSheetExist(string sheetName)
        {
            if (workbook.GetSheetIndex(sheetName) != -1)
            {
                return true;
            }

            return (workbook.GetSheetIndex(sheetName.ToUpper()) != -1);
        }

        public int GetCellRowNum(string sheetName, string colName, string cellValue)
        {
            for (int i = 0; i < GetRowCount(sheetName); i++)
            {
                if (GetCellData(sheetName, colName, i).Equals(cellValue))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                workbook?.Dispose();
            }

        }
    }
}

