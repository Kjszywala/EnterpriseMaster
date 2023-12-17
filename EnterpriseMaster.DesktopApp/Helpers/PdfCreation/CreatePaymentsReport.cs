using EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EnterpriseMaster.DesktopApp.Helpers.PdfCreation
{
    public class CreatePaymentsReport
    {
        public string filePath { get; set; }
        public PaymentsReportModel model { get; set; }

        public CreatePaymentsReport(string _filePath, PaymentsReportModel _model)
        {
            filePath = _filePath;
            model = _model;
        }

        public void Create()
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            var document = Document.Create(container =>
            {
                container
                    .Page(page =>
                    {
                        page.Margin(50);

                        page.Header().Element(ComposeHeader);
                        page.Content().Element(ComposeContent);


                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                        });
                    });
            });

            document.GeneratePdf(filePath);
        }

        void ComposeHeader(QuestPDF.Infrastructure.IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(10).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(text =>
                    {
                        text.Span("Payments Report Number:").SemiBold().FontSize(20);
                        text.EmptyLine();
                        text.Span($"{model.ReportNumber}").FontSize(14);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Date From: ").SemiBold();
                        text.Span($"{model.DateFrom:d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Date To: ").SemiBold();
                        text.Span($"{model.DateTo:d}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        void ComposeContent(QuestPDF.Infrastructure.IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(5);

                column.Item().Row(row =>
                {
                    row.RelativeItem()
                    .Background(QuestPDF.Helpers.Colors.Grey.Lighten3)
                    .Padding(10)
                    .Text(text =>
                    {
                        text.Span("Max single Quantity: ").Bold();
                        text.Span($"{model.LargestQuantity}");
                        text.EmptyLine();
                        text.Span("Largest Single Payment: ").Bold();
                        text.Span($"{model.LargestSinglePayment}");
                        text.EmptyLine();
                        text.Span("Most Ordered Part: ").Bold();
                        text.Span($"{model.MostFrequentlySellPart}");
                    });

                    // Spacing
                    row.ConstantItem(50);

                    row.RelativeItem()
                    .Background(QuestPDF.Helpers.Colors.Grey.Lighten3)
                    .Padding(10)
                    .Text(text =>
                    {
                        text.Span("Total Quantity: ").Bold();
                        text.Span($"{model.QuantityTotal}");
                        text.EmptyLine();
                        text.Span("Most Frequently Payment Method: ").Bold();
                        text.Span($"{model.MostFrequentlyPaymentMethod}");
                        text.EmptyLine();
                        text.Span("Payments Total: ").Bold();
                        text.Span($"{model.PaymentsTotal}");
                    });
                });

                column.Item().Element(ComposeTable);

                var totalPrice = model.PaymentsTotal;
                column.Item().AlignRight().Text($"Grand total: {totalPrice}$").FontSize(14);

                column.Item().PaddingTop(25).Element(ComposeComments);
            });
        }
        void ComposeTable(QuestPDF.Infrastructure.IContainer container)
        {
            container.Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).Text("Part Name");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Black);
                    }
                });

                // step 3
                foreach (var item in model.Payments)
                {
                    table.Cell().Element(CellStyle).Text(model.Payments.IndexOf(item) + 1);
                    table.Cell().Element(CellStyle).Text(item.Product);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.UnitPrice}$");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.UnitPrice * item.Quantity}$");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }

        void ComposeComments(QuestPDF.Infrastructure.IContainer container)
        {
            string purchaseOrdersAnalysisReportDescription = @"The Payments Report Analysis provides a detailed overview of the company's financial transactions over the specified time frame. It includes insights into payment trends, vendor relationships, and overall expenditure patterns, enabling stakeholders to make well-informed financial decisions.";

            container.Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14);
                column.Item().Text(purchaseOrdersAnalysisReportDescription);
            });
        }
    }
}
