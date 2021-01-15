using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team6_UMB
{
    public class CommonUtil
    {
        //public static void ProdNameDBinding(ComboBox cbo, List<ProdNameVO> list, bool blankItem = true, string blankText = "")
        //{
        //    var codeList = (from item in list
        //                    select item).ToList();

        //    if (blankItem)
        //    {
        //        ProdNameVO blank = new ProdNameVO
        //        { ProdID = null, ProdName = blankText };
        //        codeList.Insert(0, blank);
        //    }
        //    cbo.DisplayMember = "ProdName";
        //    cbo.ValueMember = "ProdID";
        //    cbo.DataSource = codeList;
        //}

        #region 데이터그리드뷰
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void AddGridTextColumn(
                            DataGridView dgv,
                            string headerText,
                            string dataPropertyName,
                            int colWidth = 100,
                            bool visibility = true,
                            DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = dataPropertyName;
            col.HeaderText = headerText;
            col.DataPropertyName = dataPropertyName;
            col.Width = colWidth;
            col.DefaultCellStyle.Alignment = textAlign;
            col.Visible = visibility;
            col.ReadOnly = true;

            dgv.Columns.Add(col);
        }

        #endregion

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        /// <summary>
        /// 엑셀 파일 저장
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void ExcelExport<T>(List<T> list) //엑셀 파일 저장
        {
            Excel.Application excelApp = null;
            Excel.Workbook workBook = null;
            Excel.Worksheet workSheet = null;
            Excel.Range range = null;
            string strHeaderStart = "A2";
            string strDataStart = "A3";
            object optionalValue = Missing.Value;
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel Files(*.xlsx)|*.xlsx";
                dlg.Title = "엑셀파일 저장";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성 
                    workBook = excelApp.Workbooks.Add(); // 워크북 추가 

                    workSheet = workBook.Worksheets.get_Item(1);// as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기

                    Dictionary<string, string> objHeaders = new Dictionary<string, string>();

                    PropertyInfo[] headerInfo = typeof(T).GetProperties();

                    foreach (var property in headerInfo)
                    {
                        var attribute = property.GetCustomAttributes(typeof(T), false)
                                                .Cast<T>().FirstOrDefault();
                        objHeaders.Add(property.Name, attribute == null ?
                                            property.Name : attribute.ToString());
                    }

                    range = workSheet.get_Range(strHeaderStart, optionalValue);
                    range = range.get_Resize(1, objHeaders.Count);

                    range.set_Value(optionalValue, objHeaders.Values.ToArray());
                    range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);
                    range.Interior.Color = Color.LightGray.ToArgb();

                    #region 실패
                    //int count = list.Count;
                    //object[,] objData = new object[count, objHeaders.Count];

                    //for (int i = 0; i < count; i++)
                    //{
                    //    var item = list[i];
                    //    int k = 0;
                    //    foreach (KeyValuePair<string, string> entry in objHeaders)
                    //    {
                    //        var y = typeof(T).InvokeMember(entry.Key.ToString(), BindingFlags.GetProperty, null, item, null);
                    //        objData[k, i++] = (y == null) ? "" : y.ToString();
                    //    }
                    //    //for (int k = 0; k < list.   ; k++)
                    //    //{
                    //    //workSheet.Cells[i + 1, k + 1] = dt.Rows[i][k]; //dt.Columns["iopCode"];
                    //    //workSheet.Cells[i + 1, k + 1] = dt.Rows[i][k];//dt.Columns["inoutDate"];
                    //    //workSheet.Cells[i + 1, k + 1] = dt.Rows[i][k];//dt.Columns["name"];
                    //    //workSheet.Cells[i + 1, k + 1] = dt.Rows[i][k];//dt.Columns["sum"];
                    //    //}
                    //}

                    //range = workSheet.get_Range(strHeaderStart, optionalValue);
                    //range = range.get_Resize(count, objHeaders.Count);

                    //range.set_Value(optionalValue, objData);
                    //range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

                    //range = workSheet.get_Range(strHeaderStart, optionalValue);
                    //range = range.get_Resize(count + 1, objHeaders.Count);
                    //range.Columns.AutoFit();
                    #endregion
                    int count = list.Count;
                    object[,] objData = new object[count, objHeaders.Count];

                    for (int j = 0; j < count; j++)
                    {
                        var item = list[j];
                        int i = 0;
                        foreach (KeyValuePair<string, string> entry in objHeaders)
                        {
                            var y = typeof(T).InvokeMember(entry.Key.ToString(), BindingFlags.GetProperty, null, item, null);
                            objData[j, i++] = (y == null) ? "" : y.ToString();
                        }
                    }

                    range = workSheet.get_Range(strDataStart, optionalValue);
                    range = range.get_Resize(count, objHeaders.Count);

                    range.set_Value(optionalValue, objData);
                    range.BorderAround(Type.Missing, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

                    range = workSheet.get_Range(strHeaderStart, optionalValue);
                    range = range.get_Resize(count + 1, objHeaders.Count);
                    range.Columns.AutoFit();

                    workBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookDefault); // 엑셀 파일 저장 
                    workBook.Close(true);
                    excelApp.Quit();
                    MessageBox.Show("저장 완료");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        public static void ReleaseObject(object obj) //엑셀 Release
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
}
            catch (Exception err)
{
    obj = null;
    throw err;
}
finally
{
    GC.Collect();
}
        }
    }
}
