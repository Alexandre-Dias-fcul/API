﻿// <auto-generated />
using System;
using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assembly.Projecto.Final.Data.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250602160356_UpdateListingStatus")]
    partial class UpdateListingStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AddressEntityLink", b =>
                {
                    b.Property<int>("AddressesId")
                        .HasColumnType("int");

                    b.Property<int>("EntityLinksId")
                        .HasColumnType("int");

                    b.HasKey("AddressesId", "EntityLinksId");

                    b.HasIndex("EntityLinksId");

                    b.ToTable("EntityLinkAddresses", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Common.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfTermination")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discriminator")
                        .HasColumnType("int");

                    b.Property<int?>("EntityLinkId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("HiredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoFileName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityLinkId")
                        .IsUnique()
                        .HasFilter("[EntityLinkId] IS NOT NULL");

                    b.ToTable("Employees", (string)null);

                    b.HasDiscriminator().HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("EntityLinkId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varbinary(500)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityLinkId")
                        .IsUnique();

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<TimeOnly>("HourEnd")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HourStart")
                        .HasColumnType("time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("EntityLinkId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("EntityLinkId");

                    b.ToTable("Contacts", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.EntityLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("EntityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EntityLinks", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBacks", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MainImageFileName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("NumberOfBathrooms")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfKitchens")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("OtherImagesFileNames")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Parking")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Listings", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Participants", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.PersonalContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Notes")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PersonalContacts", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.PersonalContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PersonalContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalContactId");

                    b.ToTable("PersonalContactDetails", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Reassign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<int>("NewEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("OlderEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ReassignBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReassignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Reassigns", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int?>("EntityLinkId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoFileName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntityLinkId")
                        .IsUnique()
                        .HasFilter("[EntityLinkId] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Agent", b =>
                {
                    b.HasBaseType("Assembly.Projecto.Final.Domain.Common.Employee");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasIndex("SupervisorId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Staff", b =>
                {
                    b.HasBaseType("Assembly.Projecto.Final.Domain.Common.Employee");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("AddressEntityLink", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assembly.Projecto.Final.Domain.Models.EntityLink", null)
                        .WithMany()
                        .HasForeignKey("EntityLinksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Common.Employee", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.EntityLink", "EntityLink")
                        .WithOne("Employee")
                        .HasForeignKey("Assembly.Projecto.Final.Domain.Common.Employee", "EntityLinkId");

                    b.OwnsOne("Assembly.Projecto.Final.Domain.Common.Name", "Name", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleNames")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MiddleNames");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("EntityLink");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Account", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.EntityLink", "EntityLink")
                        .WithOne("Account")
                        .HasForeignKey("Assembly.Projecto.Final.Domain.Models.Account", "EntityLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntityLink");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Contact", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.EntityLink", "EntityLink")
                        .WithMany("Contacts")
                        .HasForeignKey("EntityLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntityLink");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Favorite", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Listing", "Listing")
                        .WithMany("Favorites")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assembly.Projecto.Final.Domain.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.FeedBack", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Listing", "Listing")
                        .WithMany("FeedBacks")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assembly.Projecto.Final.Domain.Models.User", "User")
                        .WithMany("FeedBacks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Listing", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Agent", "Agent")
                        .WithMany("Listings")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Participant", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Appointment", "Appointment")
                        .WithMany("Participants")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assembly.Projecto.Final.Domain.Common.Employee", "Employee")
                        .WithMany("Participants")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.PersonalContact", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Common.Employee", "Employee")
                        .WithMany("PersonalContacts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.PersonalContactDetail", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.PersonalContact", "PersonalContact")
                        .WithMany("PersonalContactDetails")
                        .HasForeignKey("PersonalContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalContact");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Reassign", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Listing", "Listing")
                        .WithMany("Reassigns")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.User", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.EntityLink", "EntityLink")
                        .WithOne("User")
                        .HasForeignKey("Assembly.Projecto.Final.Domain.Models.User", "EntityLinkId");

                    b.OwnsOne("Assembly.Projecto.Final.Domain.Common.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleNames")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MiddleNames");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("EntityLink");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Agent", b =>
                {
                    b.HasOne("Assembly.Projecto.Final.Domain.Models.Agent", "Supervisor")
                        .WithMany("Agents")
                        .HasForeignKey("SupervisorId");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Common.Employee", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("PersonalContacts");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Appointment", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.EntityLink", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Contacts");

                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Listing", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("FeedBacks");

                    b.Navigation("Reassigns");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.PersonalContact", b =>
                {
                    b.Navigation("PersonalContactDetails");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("FeedBacks");
                });

            modelBuilder.Entity("Assembly.Projecto.Final.Domain.Models.Agent", b =>
                {
                    b.Navigation("Agents");

                    b.Navigation("Listings");
                });
#pragma warning restore 612, 618
        }
    }
}
