using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Presentation.Utilidades
{
    public static class ReporteGenerator
    {
        // El método recibe: la lista de datos, el título, las cabeceras de texto, los anchos de columna y cómo pintar la fila
        public static void GenerarReportePdf<T>(
            List<T> listaDatos,
            string tituloReporte,
            string[] cabeceras,
            float[] anchosColumnas,
            Action<T, PdfPTable, iTextSharp.text.Font> mapearFila)
        {
            Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            try
            {
                // Configurar el diálogo para guardar
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                sfd.FileName = $"{tituloReporte.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                // Fuentes explícitas controladas
                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont("Helvetica-Bold", 14f, BaseColor.BLACK);
                iTextSharp.text.Font fuenteSub = FontFactory.GetFont("Helvetica", 9f, BaseColor.DARK_GRAY);
                iTextSharp.text.Font fuenteCabecera = FontFactory.GetFont("Helvetica-Bold", 9f, BaseColor.WHITE);
                iTextSharp.text.Font fuenteCuerpo = FontFactory.GetFont("Helvetica", 9f, BaseColor.BLACK);

                // Encabezado institucional
                Paragraph institucional = new Paragraph("UNIVERSIDAD MARIANO GÁLVEZ DE GUATEMALA", fuenteSub);
                institucional.Alignment = Element.ALIGN_CENTER;
                doc.Add(institucional);

                Paragraph titulo = new Paragraph(tituloReporte.ToUpper(), fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 15f;
                doc.Add(titulo);

                // Inicializar Tabla dinámicamente según los parámetros enviados
                PdfPTable tabla = new PdfPTable(cabeceras.Length);
                tabla.WidthPercentage = 100;
                if (anchosColumnas != null) tabla.SetWidths(anchosColumnas);

                // Imprimir Cabeceras
                foreach (string cabecera in cabeceras)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(cabecera, fuenteCabecera));
                    cell.BackgroundColor = new BaseColor(41, 128, 185); // Azul académico elegante
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5f;
                    tabla.AddCell(cell);
                }

                // Imprimir el contenido delegando la responsabilidad al formulario
                foreach (T item in listaDatos)
                {
                    mapearFila(item, tabla, fuenteCuerpo);
                }

                doc.Add(tabla);
                MessageBox.Show("¡Reporte PDF creado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }
    }
}