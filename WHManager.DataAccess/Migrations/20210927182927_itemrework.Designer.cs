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
    [Migration("20210927182927_itemrework")]
    partial class itemrework
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

            modelBuilder.Entity("WHManager.DataAccess.Models.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Deliveries");
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

                    b.Property<int?>("IncomingDocumentId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OutgoingDocumentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("IncomingDocumentId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("OutgoingDocumentId");

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

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryIt")
                        .HasColumnType("int");

                    b.Property<int?>("IncomingDocumentId")
                        .HasColumnType("int");

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

                    b.Property<int?>("IncomingDocumentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRealized")
                        .HasColumnType("bit");

                    b.Property<int?>("OutgoingDocumentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("IncomingDocumentId");

                    b.HasIndex("OutgoingDocumentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.OutgoingDocument", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("ContrahentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContrahentId");

                    b.HasIndex("OrderId");

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

                    b.Property<bool>("Reports")
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.IncomingDocument", "IncomingDocument")
                        .WithMany()
                        .HasForeignKey("IncomingDocumentId");

                    b.HasOne("WHManager.DataAccess.Models.Order", "Order")
                        .WithOne("Invoice")
                        .HasForeignKey("WHManager.DataAccess.Models.Invoice", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.OutgoingDocument", "OutgoingDocument")
                        .WithMany()
                        .HasForeignKey("OutgoingDocumentId");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.Item", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Delivery", null)
                        .WithMany("Items")
                        .HasForeignKey("DeliveryId");

                    b.HasOne("WHManager.DataAccess.Models.IncomingDocument", "IncomingDocument")
                        .WithMany()
                        .HasForeignKey("IncomingDocumentId");

                    b.HasOne("WHManager.DataAccess.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

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

                    b.HasOne("WHManager.DataAccess.Models.OutgoingDocument", "OutgoingDocument")
                        .WithMany()
                        .HasForeignKey("OutgoingDocumentId");
                });

            modelBuilder.Entity("WHManager.DataAccess.Models.OutgoingDocument", b =>
                {
                    b.HasOne("WHManager.DataAccess.Models.Client", "Contrahent")
                        .WithMany("OutgoingDocuments")
                        .HasForeignKey("ContrahentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("WHManager.DataAccess.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WHManager.DataAccess.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");
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
