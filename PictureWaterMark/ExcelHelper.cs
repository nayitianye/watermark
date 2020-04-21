using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureWaterMark
{
    class ExcelHelper
    {
        private static ExcelHelper _instance;
        public static ExcelHelper Instance()
        {
            if (_instance == null)
            {
                _instance = new ExcelHelper();
            }
            return _instance;
        }
        private ExcelHelper() { }
        //打开Excel类型
        private Application _app = new Application();
        //Excel文件 Excel返回类型
        private Workbook _workbook;
        //保存行和列
        private Worksheet _worksheet;
        //打开Excel            路径
        public void OpenExcel(string path)
        {
            //需要打开Excel的路径
            _workbook = _app.Workbooks.Open(path);
        }
        //打开浏览的页数
        public void OpenSelectPage(int Page = 1)
        {
            //获取所有的页数
            Sheets sheets = _workbook.Worksheets;
            //返回出去要打开的页数
            _worksheet = sheets.get_Item(Page);
        }
        //获取行
        public int GetRow()
        {
            return _worksheet.Cells.Row;
        }
        //获取列
        public int GetLine()
        {
            return _worksheet.Cells.Column;
        }
        //获取指定的单元格 从1开始
        public string GetCell(int row, int colunm)
        {
            Range cell = _worksheet.Cells[row, colunm];
            return (string)cell.Text;
        }
    }
}
