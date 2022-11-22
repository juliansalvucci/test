using ContratoTestWebApi.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;


namespace ContratoTestWebApi.Excel
{
    public class ExcelExporter
    {
        public void ExportarAExcel(List<Contrato> registros)
        {
            String pathFile = $"C:\\TEMP\\Excel.xlsx";

            SLThemeSettings stSettings = BuildTheme();
            SLDocument oSLDocument = new SLDocument(stSettings);
            oSLDocument.SetColumnWidth(1, 5, 12);

            System.Data.DataTable dt = new System.Data.DataTable();

            //// setting first row color & style
            SLStyle headerstyle = oSLDocument.CreateStyle();
            headerstyle.Font.Bold = true;
            headerstyle.Font.FontColor = System.Drawing.Color.IndianRed;
            headerstyle.Fill.SetPattern(PatternValues.Solid, SLThemeColorIndexValues.Light2Color, SLThemeColorIndexValues.Light2Color);
            oSLDocument.SetRowStyle(1, headerstyle);

            //columnas
            dt.Columns.Add("RazónSocial", typeof(String));
            dt.Columns.Add("InicioVigencia", typeof(String));
            dt.Columns.Add("FinVigencia", typeof(String));
            dt.Columns.Add("CUIT", typeof(String));

            foreach (var registro in registros)
            {
                //registros , rows
                dt.Rows.Add(
                    registro.RazonSocial,
                    registro.InicioVigencia,
                    registro.FinVigencia,
                    registro.Cuit
                    );
            }

            oSLDocument.ImportDataTable(1, 1, dt, true);

            oSLDocument.SaveAs(pathFile);
        }

        private SLThemeSettings BuildTheme()
        {
            SLThemeSettings theme = new SLThemeSettings();
            theme.ThemeName = "RDSColourTheme";
            //theme.MajorLatinFont = "Impact";
            //theme.MinorLatinFont = "Harrington";
            // this is recommended to be pure white
            theme.Light1Color = System.Drawing.Color.White;
            // this is recommended to be pure black
            theme.Dark1Color = System.Drawing.Color.Black;
            theme.Light2Color = System.Drawing.Color.LightGray;
            theme.Dark2Color = System.Drawing.Color.IndianRed;
            theme.Accent1Color = System.Drawing.Color.Red;
            theme.Accent2Color = System.Drawing.Color.Tomato;
            theme.Accent3Color = System.Drawing.Color.Yellow;
            theme.Accent4Color = System.Drawing.Color.LawnGreen;
            theme.Accent5Color = System.Drawing.Color.DeepSkyBlue;
            theme.Accent6Color = System.Drawing.Color.DarkViolet;
            theme.Hyperlink = System.Drawing.Color.Blue;
            theme.FollowedHyperlinkColor = System.Drawing.Color.Purple;
            return theme;
        }
    }
}
