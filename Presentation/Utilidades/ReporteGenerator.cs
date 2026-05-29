using iTextSharp.text;
using iTextSharp.text.pdf;
using Presentation.ViewModels;
using System.Reflection;


namespace Presentation.Utilidades
{
    public static class ReporteGenerator
    {
        public static void GenerarPdfProductos(List<ProductoVM> listaProductos, string rutaArchivo)
        {
            // 1. Crear el documento base
            Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // 2. Definir fuentes explícitas (Evita el error de referencia ambigua)
                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont("Helvetica-Bold", 14f, BaseColor.BLACK);
                iTextSharp.text.Font fuenteCuerpo = FontFactory.GetFont("Helvetica", 9f, BaseColor.BLACK);
                iTextSharp.text.Font fuenteCabecera = FontFactory.GetFont("Helvetica-Bold", 9f, BaseColor.WHITE);

                // 3. Agregar el título del reporte
                Paragraph titulo = new Paragraph("REPORTE GENERAL DE PRODUCTOS", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 15f;
                doc.Add(titulo);

                // 4. Crear la tabla con exactamente 4 columnas (las que vas a mostrar)
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;

                // Definir el ancho proporcional de cada columna: Categoría (25%), Nombre (25%), Descripción (35%), Precio (15%)
                tabla.SetWidths(new float[] { 25f, 25f, 35f, 15f });

                // 5. Escribir las cabeceras manualmente
                tabla.AddCell(new PdfPCell(new Phrase("Categoría", fuenteCabecera)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Producto", fuenteCabecera)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Descripción", fuenteCabecera)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Precio", fuenteCabecera)) { BackgroundColor = BaseColor.DARK_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                // 6. Recorrer la lista de productos e insertar fila por fila
                foreach (var prod in listaProductos)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(prod.nombre_categoria, fuenteCuerpo)));
                    tabla.AddCell(new PdfPCell(new Phrase(prod.nombre, fuenteCuerpo)));
                    tabla.AddCell(new PdfPCell(new Phrase(prod.descripcion, fuenteCuerpo)));

                    // Alinear el precio a la derecha
                    PdfPCell celdaPrecio = new PdfPCell(new Phrase($"Q {prod.precio:N2}", fuenteCuerpo));
                    celdaPrecio.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tabla.AddCell(celdaPrecio);
                }

                // 7. Guardar la tabla en el documento
                doc.Add(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar siempre el documento
                doc.Close();
            }
        }
    }
}
