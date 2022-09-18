using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppv1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleModifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modifier_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Article_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleModifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles_yedek",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleNumber = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SubCategory_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeModifiers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityAndPostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ExtraNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EInvoiceOrderFormFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GZippedContents = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EInvoiceOrderFormFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EInvoiceParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EndpointId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndpointIdSchemeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyIdentificationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessBranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress_StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress_CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.EInvoiceParties", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedYear = table.Column<int>(type: "int", nullable: false, computedColumnSql: "(datepart(year,[Created]))", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewPrices",
                columns: table => new
                {
                    Ad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: true),
                    TTTT = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrdersPerDate",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberOfOrders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.OrdersPerDate", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Primka",
                columns: table => new
                {
                    ITEM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GENDER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BARCODE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SO_PRICE = table.Column<double>(type: "float", nullable: true),
                    Cenakune = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PrintJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsExecuted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTableService = table.Column<bool>(type: "bit", nullable: false),
                    PrintPreview = table.Column<bool>(type: "bit", nullable: false),
                    PrintOrder = table.Column<bool>(type: "bit", nullable: false),
                    PrintReceiptAfterOrder = table.Column<bool>(type: "bit", nullable: false),
                    LogOffUserAfterInvoice = table.Column<bool>(type: "bit", nullable: false),
                    IsFiscal = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceFooter1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceFooter2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkDayStartAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UseProformaInvoice = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityPostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForbidAccessToTakenTables = table.Column<bool>(type: "bit", nullable: false),
                    IsVAT = table.Column<bool>(type: "bit", nullable: false),
                    IsInvoiceDailyCounter = table.Column<bool>(type: "bit", nullable: false),
                    LocationMark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceMark = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('R1')"),
                    InvoiceFooter3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceFooter4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRetail = table.Column<bool>(type: "bit", nullable: false),
                    AllowCancelOrderItems = table.Column<bool>(type: "bit", nullable: false),
                    PrintOnA4 = table.Column<bool>(type: "bit", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfIssueOfInvoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseAdditionalCurrency = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalCurrencyMark = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('EUR')"),
                    AdditionalCurrencyRate = table.Column<decimal>(type: "decimal(14,4)", nullable: false, defaultValueSql: "((7))"),
                    AreInvoiceItemsGrouped = table.Column<bool>(type: "bit", nullable: false),
                    UseChangeCalculator = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxAddedOnPrice = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayAutomaticallyModifiers = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UsePrintAllOrders = table.Column<bool>(type: "bit", nullable: false),
                    PrintAfterDeleteArticles = table.Column<bool>(type: "bit", nullable: false),
                    ShowGrossInsteadOfNettPrice = table.Column<bool>(type: "bit", nullable: false),
                    Reserved01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceChargePercentage = table.Column<int>(type: "int", nullable: false),
                    ShowTaxesOnInvoice = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    IsEInvoiceEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ShowWaiterNameOnA4Invoice = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ForbidEndShiftIfThereAreAnyOrders = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LatestPrice = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    Volumen = table.Column<decimal>(type: "decimal(18,4)", nullable: true, defaultValueSql: "((1))"),
                    Refuse = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_MeasureUnits_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RuleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Article_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rule_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.RuleItems_dbo.Rules_Rule_Id",
                        column: x => x.Rule_Id,
                        principalTable: "Rules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StationArticles",
                columns: table => new
                {
                    Station_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationArticles", x => new { x.Station_Id, x.Article_Id });
                    table.ForeignKey(
                        name: "FK_StationArticles_Stations_Station_Id",
                        column: x => x.Station_Id,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Printer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Storage_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraPrinter1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraPrinter2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Storages_Storage_Id",
                        column: x => x.Storage_Id,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Storage_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Supplier_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SourceInvoice_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.InventoryDocuments_dbo.InventoryDocuments_SourceInvoice_Id",
                        column: x => x.SourceInvoice_Id,
                        principalTable: "InventoryDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryDocuments_Storages_Storage_Id",
                        column: x => x.Storage_Id,
                        principalTable: "Storages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryDocuments_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RuleTaxes",
                columns: table => new
                {
                    Rule_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tax_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RuleTaxes", x => new { x.Rule_Id, x.Tax_Id });
                    table.ForeignKey(
                        name: "FK_dbo.RuleTaxes_dbo.Rules_Rule_Id",
                        column: x => x.Rule_Id,
                        principalTable: "Rules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.RuleTaxes_dbo.Taxes_Tax_Id",
                        column: x => x.Tax_Id,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxArticles",
                columns: table => new
                {
                    Tax_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Article_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxArticles", x => new { x.Tax_Id, x.Article_Id });
                    table.ForeignKey(
                        name: "FK_TaxArticles_Taxes_Tax_Id",
                        column: x => x.Tax_Id,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowBackoffice = table.Column<bool>(type: "bit", nullable: false),
                    AllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserNumber = table.Column<int>(type: "int", nullable: false),
                    Group_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AllowViewInvoices = table.Column<bool>(type: "bit", nullable: false),
                    AllowEndShift = table.Column<bool>(type: "bit", nullable: false),
                    AllowAccessToTakenTables = table.Column<bool>(type: "bit", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AllowDiscount = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    AllowSettings = table.Column<bool>(type: "bit", nullable: false),
                    AllowCancelOrderItems = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    OnlyMyRevenue = table.Column<bool>(type: "bit", nullable: false),
                    AllowAccesToStorage = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    AllowAccestToReports = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    AllowVoidInvoice = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    AllowMoveToTable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_Group_Id",
                        column: x => x.Group_Id,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleGoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime", nullable: false),
                    Article_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Good_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleGoods_Goods_Good_Id",
                        column: x => x.Good_Id,
                        principalTable: "Goods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Printer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Storage_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Category_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraPrinter1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraPrinter2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubCategories_Storages_Storage_Id",
                        column: x => x.Storage_Id,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    From_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    To_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Messages_dbo.Users_From_Id",
                        column: x => x.From_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Messages_dbo.Users_To_Id",
                        column: x => x.To_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    Rotation = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Waiter_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sector_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Sectors_Sector_Id",
                        column: x => x.Sector_Id,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tables_Users_Waiter_Id",
                        column: x => x.Waiter_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleNumber = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SubCategory_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeModifiers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_SubCategories_SubCategory_Id",
                        column: x => x.SubCategory_Id,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Novi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleNumber = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SubCategory_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreeModifiers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novi_SubCategories_SubCategory_Id",
                        column: x => x.SubCategory_Id,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    IsOrder = table.Column<bool>(type: "bit", nullable: false),
                    IsProformaInvoice = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    WorkingDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Waiter_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentType_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Table_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Station_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DiscountAmmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStorned = table.Column<bool>(type: "bit", nullable: false),
                    JIR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZKI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnChange = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    CashPayed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumberFormatted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    OrderByWaiter_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceChargePercentage = table.Column<int>(type: "int", nullable: false),
                    FiscalReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Invoices_dbo.Users_OrderByWaiter_Id",
                        column: x => x.OrderByWaiter_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_PaymentTypes_PaymentType_Id",
                        column: x => x.PaymentType_Id,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Stations_Station_Id",
                        column: x => x.Station_Id,
                        principalTable: "Stations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Tables_Table_Id",
                        column: x => x.Table_Id,
                        principalTable: "Tables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Users_Waiter_Id",
                        column: x => x.Waiter_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EInvoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status_Code = table.Column<int>(type: "int", nullable: false),
                    Status_Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status_Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderBankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderFormFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsStationVat = table.Column<bool>(type: "bit", nullable: false),
                    WaiterName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "('')"),
                    OrderFormReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderFormFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDue = table.Column<int>(type: "int", nullable: true),
                    PaymentIdModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIdReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.EInvoices", x => x.InvoiceId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_dbo.EInvoices_dbo.EInvoiceOrderFormFiles_OrderFormFileId",
                        column: x => x.OrderFormFileId,
                        principalTable: "EInvoiceOrderFormFiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.EInvoices_dbo.EInvoiceParties_SenderId",
                        column: x => x.SenderId,
                        principalTable: "EInvoiceParties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.EInvoices_dbo.Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EInvoices_EInvoiceParties_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "EInvoiceParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(14,8)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    Article_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Invoice_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DiscountAmmount = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    PriceWithoutDiscount = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    BasePriceWithoutDiscount = table.Column<decimal>(type: "decimal(14,8)", nullable: false),
                    TotalWithoutDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTaxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalWithoutTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    ReturnFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxTag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxVal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_Invoice_Id",
                        column: x => x.Invoice_Id,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryItemBases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(14,4)", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(14,3)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InventoryDocument_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Storage_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Good_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceItem_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NormativQuantity = table.Column<decimal>(type: "decimal(14,4)", nullable: true),
                    CurrentQuantity = table.Column<decimal>(type: "decimal(14,4)", nullable: true),
                    Refuse = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItemBases", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_InventoryItemBases_Goods_Good_Id",
                        column: x => x.Good_Id,
                        principalTable: "Goods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryItemBases_InventoryDocuments_InventoryDocument_Id",
                        column: x => x.InventoryDocument_Id,
                        principalTable: "InventoryDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryItemBases_InvoiceItems_InvoiceItem_Id",
                        column: x => x.InvoiceItem_Id,
                        principalTable: "InvoiceItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryItemBases_Storages_Storage_Id",
                        column: x => x.Storage_Id,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItemModifiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceWithoutDiscount = table.Column<decimal>(type: "decimal(14,4)", nullable: false),
                    Modifier_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceItem_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItemModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.InvoiceItemModifiers_dbo.InvoiceItems_InvoiceItem_Id",
                        column: x => x.InvoiceItem_Id,
                        principalTable: "InvoiceItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id",
                table: "ArticleGoods",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FirstDpuReportOptimization",
                table: "ArticleGoods",
                columns: new[] { "Article_Id", "Good_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Good_Id",
                table: "ArticleGoods",
                column: "Good_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SecondDpuReportOptimization",
                table: "ArticleGoods",
                columns: new[] { "Good_Id", "Article_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id1",
                table: "ArticleModifiers",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_Id",
                table: "ArticleModifiers",
                column: "Modifier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SubCategory_Id",
                table: "Articles",
                column: "SubCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Id",
                table: "Categories",
                column: "Storage_Id");

            migrationBuilder.CreateIndex(
                name: "CLIX_FirstQueryOptimization1",
                table: "EInvoiceParties",
                column: "CompanyId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "CLIX_FirstQueryOptimization",
                table: "EInvoices",
                columns: new[] { "Status_Code", "RegisterId", "InvoiceId" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceId",
                table: "EInvoices",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderFormFileId",
                table: "EInvoices",
                column: "OrderFormFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverId",
                table: "EInvoices",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderId",
                table: "EInvoices",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_Id",
                table: "Goods",
                column: "Unit_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FourthStockOptimization",
                table: "InventoryDocuments",
                columns: new[] { "Id", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_SourceInvoice_Id",
                table: "InventoryDocuments",
                column: "SourceInvoice_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Id1",
                table: "InventoryDocuments",
                column: "Storage_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Id",
                table: "InventoryDocuments",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FirstStockOptimization",
                table: "InventoryItemBases",
                columns: new[] { "Discriminator", "Storage_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Good_Id1",
                table: "InventoryItemBases",
                column: "Good_Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDocument_Id",
                table: "InventoryItemBases",
                column: "InventoryDocument_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_Id",
                table: "InventoryItemBases",
                column: "InvoiceItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SecondStockOptimization",
                table: "InventoryItemBases",
                columns: new[] { "InventoryDocument_Id", "Discriminator", "Storage_Id", "Created" },
                filter: "([Discriminator]='InventoryDocumentItem')");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Id2",
                table: "InventoryItemBases",
                column: "Storage_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdStockOptimization",
                table: "InventoryItemBases",
                columns: new[] { "InventoryDocument_Id", "Discriminator", "Storage_Id" },
                filter: "([Discriminator]='InventoryDocumentItem' AND [Quantity]<(0))");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_Id1",
                table: "InvoiceItemModifiers",
                column: "InvoiceItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_Id1",
                table: "InvoiceItemModifiers",
                column: "Modifier_Id");

            migrationBuilder.CreateIndex(
                name: "IdxTaxCalc",
                table: "InvoiceItems",
                columns: new[] { "IsDeleted", "TaxTag" });

            migrationBuilder.CreateIndex(
                name: "IdxTaxTags",
                table: "InvoiceItems",
                columns: new[] { "IsDeleted", "TaxTag" });

            migrationBuilder.CreateIndex(
                name: "IdxTaxTags1",
                table: "InvoiceItems",
                columns: new[] { "IsDeleted", "TaxTag" });

            migrationBuilder.CreateIndex(
                name: "IdxTaxTags2",
                table: "InvoiceItems",
                columns: new[] { "IsDeleted", "TaxTag" });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id2",
                table: "InvoiceItems",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Id",
                table: "InvoiceItems",
                column: "Invoice_Id");

            migrationBuilder.CreateIndex(
                name: "idx_DeleteDate",
                table: "Invoices",
                columns: new[] { "IsDeleted", "DateCreated" });

            migrationBuilder.CreateIndex(
                name: "IDX_Opt1",
                table: "Invoices",
                columns: new[] { "IsOrder", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IDX_Opt2",
                table: "Invoices",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                table: "Invoices",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NextInvoiceNumberOptimization",
                table: "Invoices",
                columns: new[] { "InvoiceNumber", "WorkingDay" },
                filter: "([IsProformaInvoice]=(0) AND [IsOrder]=(0))");

            migrationBuilder.CreateIndex(
                name: "IX_NextProformaInvoiceNumberOptimization",
                table: "Invoices",
                columns: new[] { "InvoiceNumber", "WorkingDay" },
                filter: "([IsProformaInvoice]=(1))");

            migrationBuilder.CreateIndex(
                name: "IX_OrderByWaiter_Id",
                table: "Invoices",
                column: "OrderByWaiter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_Id",
                table: "Invoices",
                column: "PaymentType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Station_Id",
                table: "Invoices",
                column: "Station_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Table_Id",
                table: "Invoices",
                column: "Table_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Waiter_Id",
                table: "Invoices",
                column: "Waiter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedYear",
                table: "Logs",
                column: "CreatedYear");

            migrationBuilder.CreateIndex(
                name: "IX_From_Id",
                table: "Messages",
                column: "From_Id");

            migrationBuilder.CreateIndex(
                name: "IX_To_Id",
                table: "Messages",
                column: "To_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Novi_SubCategory_Id",
                table: "Novi",
                column: "SubCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id1",
                table: "People",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Created",
                table: "PrintJobs",
                column: "Created");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id3",
                table: "RuleItems",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_Id1",
                table: "RuleItems",
                column: "Rule_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_Id",
                table: "RuleTaxes",
                column: "Rule_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_Id",
                table: "RuleTaxes",
                column: "Tax_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id4",
                table: "StationArticles",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Station_Id1",
                table: "StationArticles",
                column: "Station_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                table: "SubCategories",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Id3",
                table: "SubCategories",
                column: "Storage_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Id",
                table: "Tables",
                column: "Sector_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Waiter_Id1",
                table: "Tables",
                column: "Waiter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Id5",
                table: "TaxArticles",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tax_Id1",
                table: "TaxArticles",
                column: "Tax_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Id",
                table: "Users",
                column: "Group_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleGoods");

            migrationBuilder.DropTable(
                name: "ArticleModifiers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Articles_yedek");

            migrationBuilder.DropTable(
                name: "EInvoices");

            migrationBuilder.DropTable(
                name: "InventoryItemBases");

            migrationBuilder.DropTable(
                name: "InvoiceItemModifiers");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NewPrices");

            migrationBuilder.DropTable(
                name: "Novi");

            migrationBuilder.DropTable(
                name: "OrdersPerDate");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Primka");

            migrationBuilder.DropTable(
                name: "PrintJobs");

            migrationBuilder.DropTable(
                name: "Prints");

            migrationBuilder.DropTable(
                name: "RuleItems");

            migrationBuilder.DropTable(
                name: "RuleTaxes");

            migrationBuilder.DropTable(
                name: "StationArticles");

            migrationBuilder.DropTable(
                name: "TaxArticles");

            migrationBuilder.DropTable(
                name: "EInvoiceOrderFormFiles");

            migrationBuilder.DropTable(
                name: "EInvoiceParties");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "InventoryDocuments");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "MeasureUnits");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
