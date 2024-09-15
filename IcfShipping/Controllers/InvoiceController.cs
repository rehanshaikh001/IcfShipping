using System;
using System.Drawing.Printing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace IcfShipping.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult InvoiceView()
        {
            return View();
        }

        // Action to generate and download PDF
        public class PdfGenerator : PdfPageEventHelper
        {
            // Create a new PDF document
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                // Add content to the document
                document.Add(new Paragraph("Invoice"));
                document.Add(new Paragraph("Date: " + DateTime.Now.ToShortDateString()));
                document.Add(new Paragraph(" ")); // Blank line for spacing

                // Sample table for invoice items
                PdfPTable table = new PdfPTable(3);
                table.AddCell("Item");
                table.AddCell("Quantity");
                table.AddCell("Price");

                table.AddCell("Sample Item 1");
                table.AddCell("2");
                table.AddCell("$10.00");

                table.AddCell("Sample Item 2");
                table.AddCell("1");
                table.AddCell("$20.00");

                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();

                // Set the content type and headers for the response
                byte[] fileBytes = ms.ToArray();
                return File(fileBytes, "application/pdf", "Invoice.pdf");
            }
        }
    }
}
