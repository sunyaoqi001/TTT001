using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NPOI.HSSF.UserModel;

namespace UnitZG6YKSYQ.DAL
{
   public class NPdao
    {
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public System.IO.MemoryStream DaoChu(DataTable dt)
        {
            var book = new HSSFWorkbook();
            var sheet = book.CreateSheet($"sheet");
            var rows = dt.Rows.Count;
            var colms = dt.Columns.Count;
            for (int i = 0; i < rows; i++)
            {
                var row = sheet.CreateRow(i);
                for (int d = 0; d < colms; d++)
                {
                    var colmn = row.CreateCell(d);
                    colmn.SetCellValue(Convert.ToString(dt.Rows[i][d]));
                }
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            return ms;
        }
    }
}
