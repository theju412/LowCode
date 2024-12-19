
using ExcelDataReader;
using System.Data;

namespace Spaidy.DataReader
{
    public class ExcelReaderHelper
    {
        private static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        private static IExcelDataReader GetExcelReader(string fileLocation, string sheetName)
        {
            if (_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName, reader);
            }
            return reader;
        }

        public static int GetTotalRows(string fileLocation, string sheetName)
        {
            IExcelDataReader _reader = GetExcelReader(fileLocation, sheetName);
            return _reader.AsDataSet().Tables[sheetName].Rows.Count;

        }

        public static object GetCellData(string fileLocation, string sheetName, int row, int column)
        {
            //need to add in master below line.
            _cache.Clear();
            IExcelDataReader _reader = GetExcelReader(fileLocation, sheetName);
            DataTable table = _reader.AsDataSet().Tables[sheetName];
            return table.Rows[row][column];
        }


        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            }
        }
    }
}
