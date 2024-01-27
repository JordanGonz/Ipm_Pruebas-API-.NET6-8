using IPM.Core.Contracts.Services.Reportes.Excel;
using IPM.Core.Dtos;
using System.Globalization;
using ClosedXML.Excel;
namespace IPM.Infraestructure.Services.Reportes.Excel;

public class ExcelService : IExcelService
{
   

    public async Task<string> CrearExcel(IEnumerable<object> datos, string rutaExcel, int numeroMes)
    {
        var data = datos as List<ReporteExcelTimeReport>;
        if (data is null)
        {
            throw new ArgumentException("Los datos no se han enviado.");
        }

        var diasDelMesCabecera = await ObtenerEstructuraTimeReportDiasDelMes(numeroMes);

        using var workbook = new XLWorkbook();

        var worksheet = workbook.AddWorksheet("Time Report");
        ConfigurarEncabezadoEspecial(diasDelMesCabecera, worksheet);

        // Encabezados
        worksheet.Cell("A1").Value = " TIME REPORT";
        worksheet.Cell("A3").Value = " Cliente:";
        worksheet.Cell("A4").Value = "Nombre:";

        worksheet.Cell("A7").Value = "N°";
        worksheet.Cell("B7").Value = "TIPOde DE ACTIVIDAD";
        worksheet.Cell("C7").Value = "LIDER DE PROYECTO";
        worksheet.Cell("D7").Value = "CODIGO DE REQUERIMIENTO";
        worksheet.Cell("E7").Value = "DESCRIPCION DE TRABAJOS REALIZADOS";
        worksheet.Cell("F7").Value = "HORAS POR ACT.";

        //tamañp de letra
        worksheet.Cell("A1").Style.Font.FontSize = 22;
        worksheet.Cell("A3").Style.Font.FontSize = 9;
        worksheet.Cell("A4").Style.Font.FontSize = 9;
        worksheet.Range("A5:F5").Style.Font.FontSize = 9;


        int diasEnMes = DateTime.DaysInMonth(DateTime.Now.Year, numeroMes);
        int posicionUltimaColumna = diasEnMes + 6;
        string ultimaColumna = GetColumnLetter(posicionUltimaColumna);
        //obtener la ultima columna 
        worksheet.Range($"{ultimaColumna}5:{ultimaColumna}7").Merge();
        worksheet.Cell($"{GetColumnLetter(posicionUltimaColumna)}5").Value = "HORAS POR ACT.";
        worksheet.Cell($"{GetColumnLetter(posicionUltimaColumna)}5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell($"{GetColumnLetter(posicionUltimaColumna)}5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell($"{GetColumnLetter(posicionUltimaColumna)}5").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        SetBordeCelda($"{ultimaColumna}5:{ultimaColumna}7", worksheet);
        worksheet.Cell($"{GetColumnLetter(posicionUltimaColumna)}5").Style.Font.FontSize = 9;



        //Usando combinacion posicionUltimaColumna  para que se ajuste en el excel
        worksheet.Range($"A1:{GetColumnLetter(posicionUltimaColumna)}1").Merge();
        worksheet.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Range($"A2:{GetColumnLetter(posicionUltimaColumna)}2").Merge();
        worksheet.Cell("A2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


        // Establecer el ancho de las celdas individuales


        worksheet.Column(GetColumnLetter(posicionUltimaColumna)).Width = 15;
        worksheet.Column(1).Width = 15;
        worksheet.Column(2).Width = 15;
        worksheet.Column(3).Width = 15;
        worksheet.Column(4).Width = 25;
        worksheet.Column(5).Width = 35;
        worksheet.Column(6).Width = 15;


        // Aplicar NEGRITA
        worksheet.Cell("A1").Style.Font.Bold = true;
        worksheet.Cell("A2").Style.Font.Bold = true;
        worksheet.Cell("A3").Style.Font.Bold = true;
        worksheet.Cell("A4").Style.Font.Bold = true;
        worksheet.Cell("B3").Style.Font.Bold = true;
        worksheet.Cell("B4").Style.Font.Bold = true;
        worksheet.Range("A5:F5").Style.Font.Bold = true;
        worksheet.Cell($"{GetColumnLetter(posicionUltimaColumna)}5").Style.Font.Bold = true;

        // COLORES
        worksheet.Cell("A5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell("B5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell("C5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell("D5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell("E5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell("F5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell("G5").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");



        //BORDES


        SetBordeCelda("A5:F5", worksheet);
        SetBordeCelda("A6:F6", worksheet);
        SetBordeCelda("A7:F7", worksheet);

        // Datos
        int row = 8;
        int numero = 1;

        foreach (var actividad in data)
        {

            // Aqui el registro de la API, dado por la base de datos
            worksheet.Cell($"A{row}").Value = numero;
            worksheet.Cell("A2").Value = $" Fecha Desde:{actividad.FechaDesde.ToString("dd-MM-yyyy")}  Fecha Hasta:{actividad.FechaHasta.ToString("dd-MM-yyyy")} ";
            worksheet.Cell($"B{row}").Value = actividad.TipoActividad;
            worksheet.Cell($"B3").Value = actividad.cliente;
            worksheet.Cell($"B4").Value = actividad.Nombre;
            worksheet.Cell($"C{row}").Value = string.Join(", ", actividad.NombreLideres);
            worksheet.Cell($"D{row}").Value = actividad.CodigoProyecto;
            worksheet.Cell($"E{row}").Value = actividad.DescripcionActividad;
            worksheet.Cell($"F{row}").Value = actividad.CantidadHoras;
            worksheet.Cell($"{ultimaColumna}{row}").Value = actividad.CantidadHoras;


            //tamaño de letra
            worksheet.Cell("A2").Style.Font.FontSize = 12;
            worksheet.Cell($"A{row}").Style.Font.FontSize = 9;
            worksheet.Cell($"B{row}").Style.Font.FontSize = 9;
            worksheet.Cell($"C{row}").Style.Font.FontSize = 9;
            worksheet.Cell($"D{row}").Style.Font.FontSize = 8;
            worksheet.Cell($"E{row}").Style.Font.FontSize = 9;
            worksheet.Cell($"F{row}").Style.Font.FontSize = 9;
            worksheet.Cell($"{ultimaColumna}{row}").Style.Font.FontSize = 9;


            //color y negrita
            worksheet.Cell($"A{row}").Style.Font.Bold = true;
            worksheet.Cell($"A{row}").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");


            // Aplicar el estilo a una celda específica
            worksheet.Cell($"B{row}").Style.Alignment.WrapText = true;
            worksheet.Cell($"C{row}").Style.Alignment.WrapText = true;
            worksheet.Cell($"D{row}").Style.Alignment.WrapText = true;
            worksheet.Cell($"E{row}").Style.Alignment.WrapText = true;
            worksheet.Cell($"F{row}").Style.Alignment.WrapText = true;
            worksheet.Cell($"{ultimaColumna}{row}").Style.Alignment.WrapText = true;



            //centrado del texto

            worksheet.Cell($"A{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"A{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell($"B{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"B{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell($"B3{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            worksheet.Cell($"B4{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

            worksheet.Cell($"C{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"C{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell($"D{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"D{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell($"E{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"E{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell($"F{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"F{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            worksheet.Cell($"{ultimaColumna}{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"{ultimaColumna}{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


            //Bordes para numero
            SetBordeCelda($"A{row}", worksheet);
            SetBordeCelda($"B{row}", worksheet);
            SetBordeCelda($"C{row}", worksheet);
            SetBordeCelda($"D{row}", worksheet);
            SetBordeCelda($"E{row}", worksheet);
            SetBordeCelda($"F{row}", worksheet);
            SetBordeCelda($"{ultimaColumna}{row}", worksheet);

            for (int i = 0; i < diasDelMesCabecera.Count; i++)
            {
                var currentDay = diasDelMesCabecera[i];
                var columnLetter = GetColumnLetter(i + 6);

                if (currentDay.LetraSemana == "S" || currentDay.LetraSemana == "D")
                {
                    var lastRow = ObtenerUltimaFilaNecesaria(worksheet);
                    var rangeToColor = worksheet.Range($"{columnLetter}{row}");

                    SetBordeCelda($"{columnLetter}{row}", worksheet);
                    rangeToColor.Style.Fill.BackgroundColor = XLColor.FromHtml("#8DB4E2"); // Establecer el color de fondo
                    rangeToColor.Style.Alignment.WrapText = true; // Habilitar el ajuste de texto
                    rangeToColor.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Alinear horizontalmente al centro
                    rangeToColor.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center; // Alinear verticalmente al centro
                }
            }



            // Verificar que la fecha de la actividad no sea nula
            // Verificar que la fecha de la actividad no sea nula
            if (actividad.FechaActividad.HasValue)
            {
                // Encontrar el CalendarioDto correspondiente a la fecha de la actividad
                var calendarioDto = diasDelMesCabecera.FirstOrDefault(dia =>
                    dia.LetraSemana == actividad.FechaActividad.Value.ToString("ddd", CultureInfo.GetCultureInfo("es-ES")).Substring(0, 1).ToUpper() &&
                    dia.NumeroSemana == actividad.FechaActividad.Value.Day);

                if (calendarioDto != null)
                {
                    var columna = calendarioDto.NumeroSemana + 5; // Sumar 5 porque empezamos desde la columna G (7 en términos de Excel)
                    string nombreCelda = GetColumnLetter(columna) + $"{row}";

                    worksheet.Cell(nombreCelda).Value = actividad.CantidadHoras;

                    SetBordeCelda(nombreCelda, worksheet);
                    worksheet.Cell(nombreCelda).Style.Font.FontSize = 9;
                    worksheet.Cell(nombreCelda).Style.Alignment.WrapText = true;
                    worksheet.Cell(nombreCelda).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(nombreCelda).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                    for (int i = 1; i <= diasDelMesCabecera.Count; i++)
                    {
                        var nombreCeldaActual = GetColumnLetter(i + 5) + $"{row}";
                        SetBordeCelda(nombreCeldaActual, worksheet);
                        worksheet.Cell(nombreCeldaActual).Style.Font.FontSize = 9;
                        worksheet.Cell(nombreCeldaActual).Style.Alignment.WrapText = true;
                        worksheet.Cell(nombreCeldaActual).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(nombreCeldaActual).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    }
                }
            }

            numero++;
            row++;
        }

        //para para ultima de la columna del excel

        int ultimaFilaDatos = row - 1;

        // Agregar el valor "Totales" en las celdas fusionadas de A a E para la última fila con datos
    
        worksheet.Cell($"A{row}").Value = "Totales";
        worksheet.Range($"A{row}:E{row}").Merge();

        SetBordeCelda($"A{row}:E{row}", worksheet);
        worksheet.Cell($"A{row}").Style.Fill.BackgroundColor = XLColor.FromHtml("#BFBFBF");
        worksheet.Cell($"A{row}").Style.Font.Bold = true;
        worksheet.Cell($"A{row}").Style.Alignment.WrapText = true;
        worksheet.Cell($"A{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell($"A{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Cell($"A{row}").Style.Font.FontSize = 9;

        row++;

        // Ajuste de centrado y negrita para la celda en la columna E 
        worksheet.Cell($"E{row}").Style.Font.Bold = true;
        worksheet.Cell($"E{row}").Style.Font.FontColor = XLColor.FromHtml("#00B050");
        worksheet.Cell($"E{row}").Style.Font.FontSize = 9;
        worksheet.Cell($"E{row}").Style.Alignment.WrapText = true;
        worksheet.Cell($"E{row}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell($"E{row}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;


        //  SUMA DE TOTAL HORAS ARTC  en la columna F para la fila de "Totales"
        decimal? totalHoras = data.Sum(x => x.CantidadHoras);
        worksheet.Cell($"F{row - 1}").Value = totalHoras;
        worksheet.Cell($"F{row - 1}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell($"F{row - 1}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Cell($"F{row - 1}").Style.Font.Bold = true;
        worksheet.Cell($"F{row - 1}").Style.Font.FontColor = XLColor.FromHtml("#00B050");
        worksheet.Cell($"F{row - 1}").Style.Alignment.WrapText = true;
        SetBordeCelda($"F{row - 1}", worksheet);
        worksheet.Cell($"F{row - 1}").Style.Font.FontSize = 9;


        //  SUMA DE TOTAL HORAS ARTC donde se ajusta la parte final
        decimal? acumuladorHoras = data.Sum(x => x.CantidadHoras);
        worksheet.Cell($"{ultimaColumna}{row - 1}").Value = acumuladorHoras;
        worksheet.Cell($"{ultimaColumna}{row - 1}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        worksheet.Cell($"{ultimaColumna}{row - 1}").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        worksheet.Cell($"{ultimaColumna}{row - 1}").Style.Font.Bold = true;
        worksheet.Cell($"{ultimaColumna}{row - 1}").Style.Font.FontColor = XLColor.FromHtml("#00B050");
        SetBordeCelda($"{ultimaColumna}{row - 1}", worksheet);
        worksheet.Cell($"{ultimaColumna}{row - 1}").Style.Font.FontSize = 9;
        worksheet.Cell($"{ultimaColumna}{row - 1}").Style.Alignment.WrapText = true;



        for (int i = 0; i < diasDelMesCabecera.Count; i++)
        {
            var currentDay = diasDelMesCabecera[i];
            var columnLetter = GetColumnLetter(i + 6);
            decimal acumuladorColumna = 0;

            // Sumar las horas en cada columna
            for (int j = 8; j <= ultimaFilaDatos; j++)
            {
                var cellValue = worksheet.Cell($"{columnLetter}{j}").Value;

                if ( decimal.TryParse(cellValue.ToString(), out decimal horas))
                {
                    acumuladorColumna += horas;
                }
            }

            worksheet.Cell($"{columnLetter}{row - 1}").Value = acumuladorColumna;
            worksheet.Cell($"{columnLetter}{row - 1}").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell($"{columnLetter}{row - 1}").Style.Font.Bold = true;
            worksheet.Cell($"{columnLetter}{row - 1}").Style.Font.FontColor = XLColor.FromHtml ("#00B050");
            SetBordeCelda($"{columnLetter}{row - 1}", worksheet);
            worksheet.Cell($"{columnLetter}{row - 1}").Style.Font.FontSize = 9;
            worksheet.Cell($"{columnLetter}{row - 1}").Style.Alignment.WrapText = true;
        }

        var downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var downloadsFolderPath = Path.Combine(downloadsPath, "Downloads");

        // Asegúrate de que la carpeta "Downloads" exista
        if (!Directory.Exists(downloadsFolderPath))
        {
            Directory.CreateDirectory(downloadsFolderPath);
        }

        var filePath = Path.Combine(downloadsFolderPath, "TimeReport.xlsx");
        workbook.SaveAs(filePath);
        return filePath;
    }



    public async Task<List<CalendarioDto>> ObtenerEstructuraTimeReportDiasDelMes(int numeroMes)
    {
        List<CalendarioDto> listaCalendarioDto = new();
        //TODO: obtener los dias de la semana a partir del numero de mes 
        //Crear un DateTime a partir del ese numero de mes
        var fechaInicioCabecera = new DateTime(DateTime.Now.Year, numeroMes, 1);
        //como obtener el ultimo dia de un datetime en c#
        var ultimoDiaMes = DateTime.DaysInMonth(fechaInicioCabecera.Year, fechaInicioCabecera.Month);
        for (int i = 1; i <= ultimoDiaMes; i++)
        {
            var fechaActual = fechaInicioCabecera.AddDays(i - 1);

            var calendarioRow = new CalendarioDto
            {
                //como obtener el nombre de la semana a partir de un datetime
                LetraSemana = fechaActual.ToString("ddd", CultureInfo.GetCultureInfo("es-ES")).Substring(0, 1).ToUpper(),
                NumeroSemana = i
            };
            listaCalendarioDto.Add(calendarioRow);
        }

        return listaCalendarioDto;
    }

    //para bordes
    private void SetBordeCelda(string nombreCeldas, IXLWorksheet worksheet)
    {
        var encabezadosRange = worksheet.Range(nombreCeldas);
        encabezadosRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
        encabezadosRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        encabezadosRange.Style.Border.DiagonalBorder = XLBorderStyleValues.Thin;
        encabezadosRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
        encabezadosRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;
    }
    private int ObtenerUltimaFilaNecesaria(IXLWorksheet worksheet)
    {
        var lastRowUsed = worksheet.LastRowUsed();

        // Si la última fila utilizada es nula, entonces la hoja está vacía
        // y puedes devolver el número de fila inicial
        if (lastRowUsed == null)
        {
            return 1; // O el número de fila que desees como predeterminado
        }

        // Devolver el número de la última fila utilizada
        return lastRowUsed.RowNumber();
    }

    // Método para configurar el encabezado especial
    private void ConfigurarEncabezadoEspecial(List<CalendarioDto> calendarioDtos, IXLWorksheet worksheet)
    {
        // Agregar días del mes desde la columna G, en la fila 3
        for (int i = calendarioDtos.FirstOrDefault().NumeroSemana; i <= calendarioDtos.LastOrDefault().NumeroSemana; i++)

        {
            worksheet.Cell(GetColumnLetter(i + 5) + "6").Style.Font.FontColor = XLColor.FromHtml("#BFBFBF");
            worksheet.Cell(GetColumnLetter(i + 5) + "6").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(GetColumnLetter(i + 5) + "6").Value = i.ToString("D2");
            worksheet.Cell(GetColumnLetter(i + 5) + "6").Style.Font.Bold = true;
            worksheet.Column(GetColumnLetter(i + 5)).Width = 5;
            SetBordeCelda(GetColumnLetter(i + 5) + "6", worksheet);
            worksheet.Cell(GetColumnLetter(i + 5) + "6").Style.Font.FontSize = 9;
        }


        string ultimaColumnaConDatos = String.Empty;
        for (int i = 0; i < calendarioDtos.Count; i++)
        {
            worksheet.Cell(GetColumnLetter(i + 6) + "7").Style.Font.FontColor = XLColor.FromHtml("#BFBFBF");
            worksheet.Cell(GetColumnLetter(i + 6) + "7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(GetColumnLetter(i + 6) + "7").Value = calendarioDtos[i].LetraSemana;
            worksheet.Cell(GetColumnLetter(i + 6) + "7").Style.Font.Bold = true;
            ultimaColumnaConDatos = GetColumnLetter(i + 6);
            worksheet.Column(GetColumnLetter(i + 5)).Width = 5;
            SetBordeCelda(GetColumnLetter(i + 6) + "7", worksheet);
            worksheet.Cell(GetColumnLetter(i + 6) + "7").Style.Font.FontSize = 9;
        }

        if (worksheet != null && !string.IsNullOrEmpty(ultimaColumnaConDatos))
        {
            worksheet.Range($"G5:{ultimaColumnaConDatos}5").Merge();
            worksheet.Cell("G5").Value = "DISTRIBUCION DE TIEMPO POR DIA";
            worksheet.Cell("G5").Style.Font.Bold = true;
            worksheet.Cell("G5").Style.Font.FontSize = 9;
            SetBordeCelda($"G5:{ultimaColumnaConDatos}5", worksheet);


        }

        // COMBINACION DE CELDAS
        worksheet.Range("B3:E3").Merge();
        worksheet.Range("B4:E4").Merge();

        worksheet.Range("A5:A7").Merge();
        worksheet.Cell("A5").Value = "N°";

        worksheet.Range("B5:B7").Merge();
        worksheet.Cell("B5").Value = "TIPO DE ACTIVIDAD";

        worksheet.Range("C5:C7").Merge();
        worksheet.Cell("C5").Value = "LIDER DE PROYECTO";

        worksheet.Range("D5:D7").Merge();
        worksheet.Cell("D5").Value = "CODIGO DE REQUERIMIENTO";

        worksheet.Range("E5:E7").Merge();
        worksheet.Cell("E5").Value = "DESCRIPCION DE TRABAJOS REALIZADOS";

        worksheet.Range("F5:F7").Merge();
        worksheet.Cell("F5").Value = "TOTAL DE HORAS";




        //PARA CENTAR LOS TEXTOS
        // Definir el rango de celdas que deseas centrar
        var rangoACentrar = worksheet.Range("A5:G5");

        // Aplicar la alineación horizontal y vertical centrada al rango
        rangoACentrar.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        rangoACentrar.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

    }


    // Método para obtener la letra de la columna según el índice
    private string GetColumnLetter(int columnIndex)
    {
        int dividend = columnIndex + 1;
        string columnLetter = "";

        while (dividend > 0)
        {
            int modulo = (dividend - 1) % 26;
            columnLetter = Convert.ToChar(65 + modulo).ToString() + columnLetter;
            dividend = (dividend - modulo) / 26;
        }

        return columnLetter;
    }



}