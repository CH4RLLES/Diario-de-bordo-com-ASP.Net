using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace DiarioDeBordo.Dominio.Utils
{
    public class Util
    {
        public static ExcelWorksheet MontaCabecalho(Type classe, ExcelWorksheet planilha)
        {
            PropertyInfo[] propInfos = classe.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var col = 1;

            foreach (var propInfo in propInfos)
            {
                MemberInfo property = classe.GetProperty(propInfo.Name);
                var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                if (dd != null && !string.IsNullOrEmpty(dd.Name))
                {
                    planilha.Cells[1, col].Value = dd.Name;
                }
                else
                {
                    planilha.Cells[1, col].Value = propInfo.Name;
                }
                planilha.Cells[1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                planilha.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.CadetBlue);
                planilha.Cells[1, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                planilha.Cells[1, col].Style.Font.Bold = true;
                col++;
            }

            return planilha;
        }
    }
}
