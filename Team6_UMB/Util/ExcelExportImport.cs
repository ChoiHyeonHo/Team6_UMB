using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team6_UMB
{
    public class ExcelExportImport
    {
        public static string ExportToDataGridView<T>(List<T> dataList, string exceptColumns, int colorA, int colorR, int colorG, int colorB)
        {
            Excel.Application excel = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            Excel.Range range = null;
            string strHeaderStart = "A1";
            string strDataStart = "A2";
            object optionalValue = Missing.Value;
            try
            {
                excel = new Excel.Application();
                workBook = excel.Workbooks.Add(); // 워크북 추가 
                workSheet = workBook.Worksheets.get_Item(1);// as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기
                //excel.Application.Workbooks.Add(true);

                Dictionary<string, string> objHeaders = new Dictionary<string, string>();

                int columnIndex = 0;

                PropertyInfo[] headerInfo = typeof(T).GetProperties();

                foreach (PropertyInfo property in headerInfo)
                {
                    if (!exceptColumns.Contains(property.Name))
                    {
                        var attribute = property.GetCustomAttributes(typeof(T), false)
                                                .Cast<T>().FirstOrDefault();
                        objHeaders.Add(property.Name, attribute == null ?
                                            property.Name : attribute.ToString());
                    }
                }

                range = workSheet.get_Range(strHeaderStart, optionalValue);
                range = range.get_Resize(1, objHeaders.Count);

                range.set_Value(optionalValue, objHeaders.Values.ToArray());
                range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
                range.Interior.Color = Color.FromArgb(colorA, colorR, colorG, colorB);
                range.Font.Color = Color.White;

                int rowIndex = 0;
                object[,] objData = new object[rowIndex, objHeaders.Count];

                foreach (T data in dataList)
                {
                    rowIndex++;
                    columnIndex = 0;
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        if (!exceptColumns.Contains(prop.Name))
                        {
                            columnIndex++;
                            if (prop.GetValue(data, null) != null)
                            {
                                excel.Cells[rowIndex + 1, columnIndex] = prop.GetValue(data, null).ToString();
                            }
                        }
                    }
                }
                range = workSheet.get_Range(strDataStart, optionalValue);
                range = range.get_Resize(rowIndex, objHeaders.Count);

                range.set_Value(optionalValue, objData);
                range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

                range = workSheet.get_Range(strHeaderStart, optionalValue);
                range = range.get_Resize(rowIndex + 1, objHeaders.Count);
                range.WrapText = false;
                range.Columns.AutoFit();

                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                worksheet.Activate();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
