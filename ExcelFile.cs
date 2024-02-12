using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;
using _Excel = Microsoft.Office.Interop.Excel;

namespace MapABC
{
    class ExcelFile
    {

        string path = " ";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        _Excel.Range xlR;

        public ExcelFile(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
            xlR = ws.UsedRange;

        }
        public string ReadCell(int i, int j)
        {

            string result = " no data";
            _Excel.Range r = xlR.Cells[i, j];
            if (r.Value2 != null)
                result = r.Value2;

            return result;
        }

        public void writeXcelsheet(int i, int j, string Xvalue)
        {

            _Excel.Range r = xlR.Cells[i, j];
            ws.Cells[i, j] = Xvalue;
            r.Value2 = Xvalue;
        }
        public void ExcelSave()
        {
            wb.Save();
        }
        public void excelClose()
        {
            wb.Close();
        }
        public void excelclear()
        {
            ws.UsedRange.ClearContents();
        }
    }
}
