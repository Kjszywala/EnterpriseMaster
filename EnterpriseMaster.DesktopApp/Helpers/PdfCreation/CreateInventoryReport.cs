using EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EnterpriseMaster.DesktopApp.Helpers.PdfCreation
{
    public class CreateInventoryReport
    {
        public string filePath { get; set; }
        public InventoryReportModel model { get; set; }

        public CreateInventoryReport(string _filePath, InventoryReportModel _model)
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
                        text.Span("Purchase Order Report Number:").SemiBold().FontSize(20);
                        text.EmptyLine();
                        text.Span($"{model.ReportNumber}").FontSize(14);
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Date Created: ").SemiBold();
                        text.Span($"{model.CreationDate:d}");
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
                        text.Span("Haviest Weight: ").Bold();
                        text.Span($"{model.HaviestItem}");
                        text.EmptyLine();
                        text.Span("Largest Units In Stock: ").Bold();
                        text.Span($"{model.LargestUnitInStock}");
                    });

                    // Spacing
                    row.ConstantItem(50);

                    row.RelativeItem()
                    .Background(QuestPDF.Helpers.Colors.Grey.Lighten3)
                    .Padding(10)
                    .Text(text =>
                    {
                        text.Span("Total Units In Stock: ").Bold();
                        text.Span($"{model.TotalInStock}");
                        text.EmptyLine();
                        text.Span("Most Expensive Item: ").Bold();
                        text.Span($"{model.MostExpensiveItem}");
                    });
                });

                column.Item().Element(ComposeTable);

                var total = model.TotalInStock;
                column.Item().AlignRight().Text($"Total in stock: {total}$").FontSize(14);

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
                    header.Cell().Element(CellStyle).Text("Product Name");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity In stock");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Black);
                    }
                });

                // step 3
                foreach (var item in model.Products)
                {
                    table.Cell().Element(CellStyle).Text(model.Products.IndexOf(item) + 1);
                    table.Cell().Element(CellStyle).Text(item.ProductName);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}$");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.UnitsInStock);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price * item.UnitsInStock}$");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }

        void ComposeComments(QuestPDF.Infrastructure.IContainer container)
        {
            string purchaseOrdersAnalysisReportDescription = @"The Purchase Orders Analysis Report offers a comprehensive examination of the company's procurement activities during the specified time period. It provides insights into purchasing trends, vendor performance, and expenditure patterns, empowering stakeholders to make informed decisions.";

            container.Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14);
                column.Item().Text(purchaseOrdersAnalysisReportDescription);
            });
        }
    }
}
