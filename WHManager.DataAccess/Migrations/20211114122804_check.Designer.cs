﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WHManager.DataAccess;

namespace WHManager.DataAccess.Migrations
{
    [DbContext(typeof(WHManagerDBContext))]
    [Migration("20211114122804_check")]
    partial class check
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.8.20407.4");

            modelBuilder.Entity("WHManager.DataAccess.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Nip")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Field")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.ContrahentReports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ContrahentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContrahentReports");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRealized")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.Property<bool>("Realized")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.DeliveryOrderElements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DeliveryElements");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.DocumentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContrahentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContrahentNip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContrahentPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GrossValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxType")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DocumentData");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.IncomingDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("IncomingDocuments");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfAdmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfEmission")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int?>("IncomingDocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsInOrder")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OutgoingDocumentId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("IncomingDocumentId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("OrderId");

                    b.HasIndex("OutgoingDocumentId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Nip")
                        .HasMaxLength(20)
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRealized")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IncomingDocumentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRealized")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("IncomingDocumentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.OutgoingDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ContrahentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContrahentId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OutgoingDocuments");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PriceBuy")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceSell")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("TaxId");

                    b.HasIndex("TypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.ProductReports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("DateDeliveredFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeliveredTo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOrderedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOrderedTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductReports");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Nip")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("Business")
                        .HasColumnType("bit");

                    b.Property<bool>("Contractors")
                        .HasColumnType("bit");

                    b.Property<bool>("Documents")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Report")
                        .HasColumnType("bit");

                    b.Property<bool>("Warehouse")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Value")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Delivery", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.IncomingDocument", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Provider", "Provider")
                        .WithMany("IncomingDocuments")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Invoice", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.Order", null)
                        .WithOne("Invoice")
                        .HasForeignKey("WHManager.DataAccess.Models.Invoice", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Item", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Delivery", null)
                        .WithMany("Items")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.IncomingDocument", "IncomingDocument")
                        .WithMany()
                        .HasForeignKey("IncomingDocumentId");

                    b.HasOne("WHManager.DataAccess.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("WHManager.DataAccess.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("WHManager.DataAccess.Models.OutgoingDocument", "OutgoingDocument")
                        .WithMany()
                        .HasForeignKey("OutgoingDocumentId");

                    b.HasOne("WHManager.DataAccess.Models.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.Provider", "Provider")
                        .WithMany("Items")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Order", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WHManager.DataAccess.Models.IncomingDocument", "IncomingDocument")
                        .WithMany()
                        .HasForeignKey("IncomingDocumentId");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.OutgoingDocument", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Client", "Contrahent")
                        .WithMany("OutgoingDocuments")
                        .HasForeignKey("ContrahentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WHManager.DataAccess.Models.Order", null)
                        .WithOne("OutgoingDocument")
                        .HasForeignKey("WHManager.DataAccess.Models.OutgoingDocument", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Product", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.Tax", "Tax")
                        .WithMany("Products")
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.ProductType", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.User", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}