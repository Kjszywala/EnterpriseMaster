using EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Components;
using EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace EnterpriseMaster.DesktopApp.Helpers.PdfCreation
{
    public class CreatePdf
    {
        public string filePath { get; set; }
        public InvoiceModel model { get; set; }
        public Address sellerAddress { get; set; }
        public Address forAddress { get; set; }
        public List<OrderItem> orderItems { get; set; }

        public CreatePdf(string _filePath, InvoiceModel _model, Address _sellerAddress, Address _forAddress, List<OrderItem> _orderItems)
        {
            filePath = _filePath;
            model = _model;
            sellerAddress = _sellerAddress;
            forAddress = _forAddress;
            orderItems = _orderItems;
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
            var titleStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{model.InvoiceNumber}").Style(titleStyle);

                    column.Item().Text(text =>
                    {
                        text.Span("Issue date: ").SemiBold();
                        text.Span($"{model.IssueDate:d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("Due date: ").SemiBold();
                        text.Span($"{model.DueDate:d}");
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
                    row.RelativeItem().Component(new AddressComponent("From", model.SellerAddress));
                    row.ConstantItem(50);
                    row.RelativeItem().Component(new AddressComponent("For", model.CustomerAddress));
                });

                column.Item().Element(ComposeTable);

                var totalPrice = model.Items.Sum(x => x.Price * x.Quantity);
                column.Item().AlignRight().Text($"Grand total: {totalPrice}$").FontSize(14);

                if (!string.IsNullOrWhiteSpace(model.Comments))
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
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Black);
                    }
                });

                // step 3
                foreach (var item in model.Items)
                {
                    table.Cell().Element(CellStyle).Text(model.Items.IndexOf(item) + 1);
                    table.Cell().Element(CellStyle).Text(item.Name);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}$");
                    table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price * item.Quantity}$");

                    static QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        }

        void ComposeComments(QuestPDF.Infrastructure.IContainer container)
        {
            container.Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Comments").FontSize(14);
                column.Item().Text(model.Comments);
            });
        }
    }
}

