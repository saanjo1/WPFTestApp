﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfAppv1.Models
{
    public partial class possectorContext : DbContext
    {
       
        public possectorContext()
        {
        }

        public possectorContext(DbContextOptions<possectorContext> options)
            : base(options)
        {
     
        }

        public  DbSet<Article> Articles { get; set; } = null!;
        public  DbSet<ArticleGood> ArticleGoods { get; set; } = null!;
        public  DbSet<ArticleModifier> ArticleModifiers { get; set; } = null!;
        public  DbSet<ArticlesYedek> ArticlesYedeks { get; set; } = null!;
        public  DbSet<Category> Categories { get; set; } = null!;
        public  DbSet<Customer> Customers { get; set; } = null!;
        public  DbSet<Einvoice> Einvoices { get; set; } = null!;
        public  DbSet<EinvoiceOrderFormFile> EinvoiceOrderFormFiles { get; set; } = null!;
        public  DbSet<EinvoiceParty> EinvoiceParties { get; set; } = null!;
        public  DbSet<Good> Goods { get; set; } = null!;
        public  DbSet<InventoryDocument> InventoryDocuments { get; set; } = null!;
        public  DbSet<InventoryItemBasis> InventoryItemBases { get; set; } = null!;
        public  DbSet<Invoice> Invoices { get; set; } = null!;
        public  DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public  DbSet<InvoiceItemModifier> InvoiceItemModifiers { get; set; } = null!;
        public  DbSet<Log> Logs { get; set; } = null!;
        public  DbSet<MeasureUnit> MeasureUnits { get; set; } = null!;
        public  DbSet<Message> Messages { get; set; } = null!;
        public  DbSet<NewPrice> NewPrices { get; set; } = null!;
        public  DbSet<Novi> Novis { get; set; } = null!;
        public  DbSet<OrdersPerDate> OrdersPerDates { get; set; } = null!;
        public  DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public  DbSet<Person> People { get; set; } = null!;
        public  DbSet<Primka> Primkas { get; set; } = null!;
        public  DbSet<Print> Prints { get; set; } = null!;
        public  DbSet<PrintJob> PrintJobs { get; set; } = null!;
        public  DbSet<Rule> Rules { get; set; } = null!;
        public  DbSet<RuleItem> RuleItems { get; set; } = null!;
        public  DbSet<Sector> Sectors { get; set; } = null!;
        public  DbSet<Station> Stations { get; set; } = null!;
        public  DbSet<StationArticle> StationArticles { get; set; } = null!;
        public  DbSet<Storage> Storages { get; set; } = null!;
        public  DbSet<SubCategory> SubCategories { get; set; } = null!;
        public  DbSet<Supplier> Suppliers { get; set; } = null!;
        public  DbSet<Table> Tables { get; set; } = null!;
        public  DbSet<TaxArticle> TaxArticles { get; set; } = null!;
        public  DbSet<Taxis> Taxes { get; set; } = null!;
        public  DbSet<User> Users { get; set; } = null!;
        public  DbSet<UserGroup> UserGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=.;Database=possector;Trusted_Connection=True;");
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.EnableSensitiveDataLogging();

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ReturnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_Id");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.SubCategoryId);
            });

            modelBuilder.Entity<ArticleGood>(entity =>
            {
                entity.HasIndex(e => e.ArticleId, "IX_Article_Id");

                entity.HasIndex(e => new { e.ArticleId, e.GoodId }, "IX_FirstDpuReportOptimization");

                entity.HasIndex(e => e.GoodId, "IX_Good_Id");

                entity.HasIndex(e => new { e.GoodId, e.ArticleId }, "IX_SecondDpuReportOptimization");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.GoodId).HasColumnName("Good_Id");

                entity.Property(e => e.Quantity).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidUntil).HasColumnType("datetime");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.ArticleGoods)
                    .HasForeignKey(d => d.GoodId);
            });

            modelBuilder.Entity<ArticleModifier>(entity =>
            {
                entity.HasIndex(e => e.ArticleId, "IX_Article_Id");

                entity.HasIndex(e => e.ModifierId, "IX_Modifier_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.ModifierId).HasColumnName("Modifier_Id");
            });

            modelBuilder.Entity<ArticlesYedek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Articles_yedek");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ReturnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_Id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.StorageId, "IX_Storage_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.StorageId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Einvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK_dbo.EInvoices")
                    .IsClustered(false);

                entity.ToTable("EInvoices");

                entity.HasIndex(e => new { e.StatusCode, e.RegisterId, e.InvoiceId }, "CLIX_FirstQueryOptimization")
                    .IsClustered();

                entity.HasIndex(e => e.InvoiceId, "IX_InvoiceId");

                entity.HasIndex(e => e.OrderFormFileId, "IX_OrderFormFileId");

                entity.HasIndex(e => e.ReceiverId, "IX_ReceiverId");

                entity.HasIndex(e => e.SenderId, "IX_SenderId");

                entity.Property(e => e.InvoiceId).ValueGeneratedNever();

                entity.Property(e => e.RegisterId)
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatusCode).HasColumnName("Status_Code");

                entity.Property(e => e.StatusNote).HasColumnName("Status_Note");

                entity.Property(e => e.StatusTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Status_Timestamp");

                entity.Property(e => e.WaiterName).HasDefaultValueSql("('')");

                entity.HasOne(d => d.Invoice)
                    .WithOne(p => p.Einvoice)
                    .HasForeignKey<Einvoice>(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EInvoices_dbo.Invoices_InvoiceId");

                entity.HasOne(d => d.OrderFormFile)
                    .WithMany(p => p.Einvoices)
                    .HasForeignKey(d => d.OrderFormFileId)
                    .HasConstraintName("FK_dbo.EInvoices_dbo.EInvoiceOrderFormFiles_OrderFormFileId");

                //entity.HasOne(d => d.Receiver)
                //    .WithMany(p => p.EinvoiceReceivers)
                //    .HasForeignKey(d => d.ReceiverId)
                //    .HasConstraintName("FK_dbo.EInvoices_dbo.EInvoiceParties_ReceiverId");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.EinvoiceSenders)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_dbo.EInvoices_dbo.EInvoiceParties_SenderId");
            });

            modelBuilder.Entity<EinvoiceOrderFormFile>(entity =>
            {
                entity.ToTable("EInvoiceOrderFormFiles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GzippedContents)
                    .HasColumnType("image")
                    .HasColumnName("GZippedContents");
            });

            modelBuilder.Entity<EinvoiceParty>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_dbo.EInvoiceParties")
                    .IsClustered(false);

                entity.ToTable("EInvoiceParties");

                entity.HasIndex(e => e.CompanyId, "CLIX_FirstQueryOptimization")
                    .IsClustered();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasMaxLength(11);

                entity.Property(e => e.PostalAddressCityName).HasColumnName("PostalAddress_CityName");

                entity.Property(e => e.PostalAddressPostalCode).HasColumnName("PostalAddress_PostalCode");

                entity.Property(e => e.PostalAddressStreetName).HasColumnName("PostalAddress_StreetName");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasIndex(e => e.UnitId, "IX_Unit_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LatestPrice).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.Refuse).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("Unit_Id");

                entity.Property(e => e.Volumen)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.UnitId);
            });

            modelBuilder.Entity<InventoryDocument>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.Type }, "IX_FourthStockOptimization");

                entity.HasIndex(e => e.SourceInvoiceId, "IX_SourceInvoice_Id");

                entity.HasIndex(e => e.StorageId, "IX_Storage_Id");

                entity.HasIndex(e => e.SupplierId, "IX_Supplier_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.SourceInvoiceId).HasColumnName("SourceInvoice_Id");

                entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

                entity.HasOne(d => d.SourceInvoice)
                    .WithMany(p => p.InverseSourceInvoice)
                    .HasForeignKey(d => d.SourceInvoiceId)
                    .HasConstraintName("FK_dbo.InventoryDocuments_dbo.InventoryDocuments_SourceInvoice_Id");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.InventoryDocuments)
                    .HasForeignKey(d => d.StorageId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.InventoryDocuments)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<InventoryItemBasis>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.HasIndex(e => new { e.Discriminator, e.StorageId }, "IX_FirstStockOptimization");

                entity.HasIndex(e => e.GoodId, "IX_Good_Id")
                    .IsClustered();

                entity.HasIndex(e => e.InventoryDocumentId, "IX_InventoryDocument_Id");

                entity.HasIndex(e => e.InvoiceItemId, "IX_InvoiceItem_Id");

                entity.HasIndex(e => new { e.InventoryDocumentId, e.Discriminator, e.StorageId, e.Created }, "IX_SecondStockOptimization")
                    .HasFilter("([Discriminator]='InventoryDocumentItem')");

                entity.HasIndex(e => e.StorageId, "IX_Storage_Id");

                entity.HasIndex(e => new { e.InventoryDocumentId, e.Discriminator, e.StorageId }, "IX_ThirdStockOptimization")
                    .HasFilter("([Discriminator]='InventoryDocumentItem' AND [Quantity]<(0))");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CurrentQuantity).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.Discriminator).HasMaxLength(128);

                entity.Property(e => e.GoodId).HasColumnName("Good_Id");

                entity.Property(e => e.InventoryDocumentId).HasColumnName("InventoryDocument_Id");

                entity.Property(e => e.InvoiceItemId).HasColumnName("InvoiceItem_Id");

                entity.Property(e => e.NormativQuantity).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.Refuse).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(14, 3)");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.InventoryItemBases)
                    .HasForeignKey(d => d.GoodId);

                entity.HasOne(d => d.InventoryDocument)
                    .WithMany(p => p.InventoryItemBases)
                    .HasForeignKey(d => d.InventoryDocumentId);

                entity.HasOne(d => d.InvoiceItem)
                    .WithMany(p => p.InventoryItemBases)
                    .HasForeignKey(d => d.InvoiceItemId);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.InventoryItemBases)
                    .HasForeignKey(d => d.StorageId);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => new { e.IsOrder, e.IsDeleted }, "IDX_Opt1");

                entity.HasIndex(e => e.DateCreated, "IDX_Opt2");

                entity.HasIndex(e => e.CustomerId, "IX_Customer_Id");

                entity.HasIndex(e => new { e.InvoiceNumber, e.WorkingDay }, "IX_NextInvoiceNumberOptimization")
                    .HasFilter("([IsProformaInvoice]=(0) AND [IsOrder]=(0))");

                entity.HasIndex(e => new { e.InvoiceNumber, e.WorkingDay }, "IX_NextProformaInvoiceNumberOptimization")
                    .HasFilter("([IsProformaInvoice]=(1))");

                entity.HasIndex(e => e.OrderByWaiterId, "IX_OrderByWaiter_Id");

                entity.HasIndex(e => e.PaymentTypeId, "IX_PaymentType_Id");

                entity.HasIndex(e => e.StationId, "IX_Station_Id");

                entity.HasIndex(e => e.TableId, "IX_Table_Id");

                entity.HasIndex(e => e.WaiterId, "IX_Waiter_Id");

                entity.HasIndex(e => new { e.IsDeleted, e.DateCreated }, "idx_DeleteDate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmmount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Jir).HasColumnName("JIR");

                entity.Property(e => e.OrderByWaiterId).HasColumnName("OrderByWaiter_Id");

                entity.Property(e => e.OrderCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentType_Id");

                entity.Property(e => e.ReturnChange).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.StationId).HasColumnName("Station_Id");

                entity.Property(e => e.TableId).HasColumnName("Table_Id");

                entity.Property(e => e.Total).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.WaiterId).HasColumnName("Waiter_Id");

                entity.Property(e => e.WorkingDay).HasColumnType("datetime");

                entity.Property(e => e.Zki).HasColumnName("ZKI");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.OrderByWaiter)
                    .WithMany(p => p.InvoiceOrderByWaiters)
                    .HasForeignKey(d => d.OrderByWaiterId)
                    .HasConstraintName("FK_dbo.Invoices_dbo.Users_OrderByWaiter_Id");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentTypeId);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.StationId);

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.TableId);

                entity.HasOne(d => d.Waiter)
                    .WithMany(p => p.InvoiceWaiters)
                    .HasForeignKey(d => d.WaiterId);
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasIndex(e => e.ArticleId, "IX_Article_Id");

                entity.HasIndex(e => e.InvoiceId, "IX_Invoice_Id");

                entity.HasIndex(e => new { e.IsDeleted, e.TaxTag }, "IdxTaxCalc");

                entity.HasIndex(e => new { e.IsDeleted, e.TaxTag }, "IdxTaxTags");

                entity.HasIndex(e => new { e.IsDeleted, e.TaxTag }, "IdxTaxTags1");

                entity.HasIndex(e => new { e.IsDeleted, e.TaxTag }, "IdxTaxTags2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.BasePrice).HasColumnType("decimal(14, 8)");

                entity.Property(e => e.BasePriceWithoutDiscount).HasColumnType("decimal(14, 8)");

                entity.Property(e => e.DiscountAmmount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.InvoiceId).HasColumnName("Invoice_Id");

                entity.Property(e => e.Price).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.PriceWithoutDiscount).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.ReturnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxAmmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxTag).HasMaxLength(50);

                entity.Property(e => e.TaxVal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(14, 4)");

                entity.Property(e => e.TotalTaxes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalWithoutDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalWithoutTax).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.InvoiceId);
            });

            modelBuilder.Entity<InvoiceItemModifier>(entity =>
            {
                entity.HasIndex(e => e.InvoiceItemId, "IX_InvoiceItem_Id");

                entity.HasIndex(e => e.ModifierId, "IX_Modifier_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InvoiceItemId).HasColumnName("InvoiceItem_Id");

                entity.Property(e => e.ModifierId).HasColumnName("Modifier_Id");

                entity.Property(e => e.PriceWithoutDiscount).HasColumnType("decimal(14, 4)");

                entity.HasOne(d => d.InvoiceItem)
                    .WithMany(p => p.InvoiceItemModifiers)
                    .HasForeignKey(d => d.InvoiceItemId)
                    .HasConstraintName("FK_dbo.InvoiceItemModifiers_dbo.InvoiceItems_InvoiceItem_Id");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasIndex(e => e.CreatedYear, "IX_CreatedYear");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedYear).HasComputedColumnSql("(datepart(year,[Created]))", true);
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.FromId, "IX_From_Id");

                entity.HasIndex(e => e.ToId, "IX_To_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.FromId).HasColumnName("From_Id");

                entity.Property(e => e.ToId).HasColumnName("To_Id");

                entity.HasOne(d => d.From)
                    .WithMany(p => p.MessageFroms)
                    .HasForeignKey(d => d.FromId)
                    .HasConstraintName("FK_dbo.Messages_dbo.Users_From_Id");

                entity.HasOne(d => d.To)
                    .WithMany(p => p.MessageTos)
                    .HasForeignKey(d => d.ToId)
                    .HasConstraintName("FK_dbo.Messages_dbo.Users_To_Id");
            });

            modelBuilder.Entity<NewPrice>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Ad).HasMaxLength(255);

                entity.Property(e => e.Tttt)
                    .HasColumnType("ntext")
                    .HasColumnName("TTTT");
            });

            modelBuilder.Entity<Novi>(entity =>
            {
                entity.ToTable("Novi");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ReturnFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_Id");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Novis)
                    .HasForeignKey(d => d.SubCategoryId);
            });

            modelBuilder.Entity<OrdersPerDate>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK_dbo.OrdersPerDate");

                entity.ToTable("OrdersPerDate");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Customer_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Primka>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Primka");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(255)
                    .HasColumnName("BARCODE");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Item)
                    .HasMaxLength(255)
                    .HasColumnName("ITEM");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .HasColumnName("naziv");

                entity.Property(e => e.SoPrice).HasColumnName("SO_PRICE");
            });

            modelBuilder.Entity<Print>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<PrintJob>(entity =>
            {
                entity.HasIndex(e => e.Created, "IX_Created");

                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasMany(d => d.Taxes)
                    .WithMany(p => p.Rules)
                    .UsingEntity<Dictionary<string, object>>(
                        "RuleTaxis",
                        l => l.HasOne<Taxis>().WithMany().HasForeignKey("TaxId").HasConstraintName("FK_dbo.RuleTaxes_dbo.Taxes_Tax_Id"),
                        r => r.HasOne<Rule>().WithMany().HasForeignKey("RuleId").HasConstraintName("FK_dbo.RuleTaxes_dbo.Rules_Rule_Id"),
                        j =>
                        {
                            j.HasKey("RuleId", "TaxId").HasName("PK_dbo.RuleTaxes");

                            j.ToTable("RuleTaxes");

                            j.HasIndex(new[] { "RuleId" }, "IX_Rule_Id");

                            j.HasIndex(new[] { "TaxId" }, "IX_Tax_Id");

                            j.IndexerProperty<Guid>("RuleId").HasColumnName("Rule_Id");

                            j.IndexerProperty<Guid>("TaxId").HasColumnName("Tax_Id");
                        });
            });

            modelBuilder.Entity<RuleItem>(entity =>
            {
                entity.HasIndex(e => e.ArticleId, "IX_Article_Id");

                entity.HasIndex(e => e.RuleId, "IX_Rule_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RuleId).HasColumnName("Rule_Id");

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.RuleItems)
                    .HasForeignKey(d => d.RuleId)
                    .HasConstraintName("FK_dbo.RuleItems_dbo.Rules_Rule_Id");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCurrencyMark).HasDefaultValueSql("('EUR')");

                entity.Property(e => e.AdditionalCurrencyRate)
                    .HasColumnType("decimal(14, 4)")
                    .HasDefaultValueSql("((7))");

                entity.Property(e => e.DisplayAutomaticallyModifiers)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.InvoiceMark).HasDefaultValueSql("('R1')");

                entity.Property(e => e.IsEinvoiceEnabled).HasColumnName("IsEInvoiceEnabled");

                entity.Property(e => e.IsVat).HasColumnName("IsVAT");

                entity.Property(e => e.ShowTaxesOnInvoice)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowWaiterNameOnA4invoice)
                    .IsRequired()
                    .HasColumnName("ShowWaiterNameOnA4Invoice")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WorkDayStartAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<StationArticle>(entity =>
            {
                entity.HasKey(e => new { e.StationId, e.ArticleId });

                entity.HasIndex(e => e.ArticleId, "IX_Article_Id");

                entity.HasIndex(e => e.StationId, "IX_Station_Id");

                entity.Property(e => e.StationId).HasColumnName("Station_Id");

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationArticles)
                    .HasForeignKey(d => d.StationId);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Category_Id");

                entity.HasIndex(e => e.StorageId, "IX_Storage_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.StorageId);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasIndex(e => e.SectorId, "IX_Sector_Id");

                entity.HasIndex(e => e.WaiterId, "IX_Waiter_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SectorId).HasColumnName("Sector_Id");

                entity.Property(e => e.WaiterId).HasColumnName("Waiter_Id");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.SectorId);

                entity.HasOne(d => d.Waiter)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.WaiterId);
            });

            modelBuilder.Entity<TaxArticle>(entity =>
            {
                entity.HasKey(e => new { e.TaxId, e.ArticleId });

                entity.HasIndex(e => e.ArticleId, "IX_Article_Id");

                entity.HasIndex(e => e.TaxId, "IX_Tax_Id");

                entity.Property(e => e.TaxId).HasColumnName("Tax_Id");

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.TaxArticles)
                    .HasForeignKey(d => d.TaxId);
            });

            modelBuilder.Entity<Taxis>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.GroupId, "IX_Group_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AllowAccesToStorage)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowAccestToReports)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowCancelOrderItems)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowDiscount)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowMoveToTable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AllowVoidInvoice)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
