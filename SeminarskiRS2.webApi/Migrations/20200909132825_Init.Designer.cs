﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeminarskiRS2.webApi.Database;

namespace SeminarskiRS2.webApi.Migrations
{
    [DbContext(typeof(_170120Context))]
    [Migration("20200909132825_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Drzave", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DrzavaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.HasKey("DrzavaId");

                    b.ToTable("Drzave");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Gradovi", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GradID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnName("DrzavaID");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.HasKey("GradId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("KorisnikID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumRodjenja")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(35);

                    b.Property<int>("GradId")
                        .HasColumnName("GradID");

                    b.Property<string>("Ime")
                        .HasMaxLength(35);

                    b.Property<string>("KorisnickoIme")
                        .HasMaxLength(60);

                    b.Property<string>("LozinkaHash");

                    b.Property<string>("LozinkaSalt");

                    b.Property<string>("Prezime")
                        .HasMaxLength(35);

                    b.Property<string>("Telefon")
                        .HasMaxLength(35);

                    b.HasKey("KorisnikId");

                    b.HasIndex("GradId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Lige", b =>
                {
                    b.Property<int>("LigaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("LigaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnName("DrzavaID");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("LigaId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Lige");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Preporuke", b =>
                {
                    b.Property<int>("PreporukaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PreporukaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojKupljenihUlaznica");

                    b.Property<int>("KorisnikId")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("TimId")
                        .HasColumnName("TimID");

                    b.HasKey("PreporukaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TimId");

                    b.ToTable("Preporuke");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Sektori", b =>
                {
                    b.Property<int>("SektorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SektorID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("TribinaId")
                        .HasColumnName("TribinaID");

                    b.HasKey("SektorId");

                    b.HasIndex("TribinaId");

                    b.ToTable("Sektori");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Sjedala", b =>
                {
                    b.Property<int>("SjedaloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SjedaloID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Oznaka")
                        .IsRequired();

                    b.Property<int>("SektorId")
                        .HasColumnName("SektorID");

                    b.Property<bool>("Status");

                    b.HasKey("SjedaloId");

                    b.HasIndex("SektorId");

                    b.ToTable("Sjedala");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Stadioni", b =>
                {
                    b.Property<int>("StadionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StadionID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradId")
                        .HasColumnName("GradID");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<string>("Opis");

                    b.Property<byte[]>("Slika");

                    b.Property<byte[]>("SlikaThumb");

                    b.HasKey("StadionId");

                    b.HasIndex("GradId");

                    b.ToTable("Stadioni");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Timovi", b =>
                {
                    b.Property<int>("TimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TimID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LigaId")
                        .HasColumnName("LigaID");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<string>("Opis");

                    b.Property<byte[]>("Slika")
                        .IsRequired();

                    b.Property<byte[]>("SlikaThumb")
                        .IsRequired();

                    b.Property<int>("StadionId")
                        .HasColumnName("StadionID");

                    b.HasKey("TimId");

                    b.HasIndex("LigaId");

                    b.HasIndex("StadionId");

                    b.ToTable("Timovi");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Tribine", b =>
                {
                    b.Property<int>("TribinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TribinaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<int>("StadionId")
                        .HasColumnName("StadionID");

                    b.HasKey("TribinaId");

                    b.HasIndex("StadionId");

                    b.ToTable("Tribine");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Ulaznice", b =>
                {
                    b.Property<int>("UlaznicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UlaznicaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Barcodeimg");

                    b.Property<DateTime>("DatumKupnje");

                    b.Property<int>("KorisnikId")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("SjedaloId")
                        .HasColumnName("SjedaloID");

                    b.Property<int>("UtakmicaId")
                        .HasColumnName("UtakmicaID");

                    b.Property<DateTime>("VrijemeKupnje");

                    b.HasKey("UlaznicaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SjedaloId");

                    b.HasIndex("UtakmicaId");

                    b.ToTable("Ulaznice");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Uplate", b =>
                {
                    b.Property<int>("UplataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UplataID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Iznos");

                    b.Property<int>("UlaznicaId")
                        .HasColumnName("UlaznicaID");

                    b.HasKey("UplataId");

                    b.HasIndex("UlaznicaId");

                    b.ToTable("Uplate");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Utakmice", b =>
                {
                    b.Property<int>("UtakmicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UtakmicaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateonly");

                    b.Property<DateTime>("DatumOdigravanja");

                    b.Property<int>("DomaciTimId")
                        .HasColumnName("DomaciTimID");

                    b.Property<int>("GostujuciTimId")
                        .HasColumnName("GostujuciTimID");

                    b.Property<int>("LigaId")
                        .HasColumnName("LigaID");

                    b.Property<byte[]>("Slika");

                    b.Property<byte[]>("SlikaThumb");

                    b.Property<int>("StadionId")
                        .HasColumnName("StadionID");

                    b.Property<DateTime>("VrijemeOdigravanja");

                    b.HasKey("UtakmicaId");

                    b.HasIndex("DomaciTimId");

                    b.HasIndex("GostujuciTimId");

                    b.HasIndex("LigaId");

                    b.HasIndex("StadionId");

                    b.ToTable("Utakmice");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Gradovi", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Drzave", "Drzava")
                        .WithMany("Gradovi")
                        .HasForeignKey("DrzavaId")
                        .HasConstraintName("FK__Gradovi__DrzavaI__398D8EEE");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Korisnici", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Gradovi", "Grad")
                        .WithMany("Korisnici")
                        .HasForeignKey("GradId")
                        .HasConstraintName("FK__Korisnici__GradI__3C69FB99");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Lige", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Drzave", "Drzava")
                        .WithMany("Lige")
                        .HasForeignKey("DrzavaId")
                        .HasConstraintName("FK__Lige__DrzavaID__3F466844");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Preporuke", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Korisnici", "Korisnik")
                        .WithMany("Preporuke")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK__Preporuke__Koris__48CFD27E");

                    b.HasOne("SeminarskiRS2.webApi.Database.Timovi", "Tim")
                        .WithMany("Preporuke")
                        .HasForeignKey("TimId")
                        .HasConstraintName("FK__Preporuke__TimID__49C3F6B7");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Sektori", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Tribine", "Tribina")
                        .WithMany("Sektori")
                        .HasForeignKey("TribinaId")
                        .HasConstraintName("FK__Sektori__Tribina__4F7CD00D");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Sjedala", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Sektori", "Sektor")
                        .WithMany("Sjedala")
                        .HasForeignKey("SektorId")
                        .HasConstraintName("FK__Sjedala__SektorI__52593CB8");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Stadioni", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Gradovi", "Grad")
                        .WithMany("Stadioni")
                        .HasForeignKey("GradId")
                        .HasConstraintName("FK__Stadioni__GradID__4222D4EF");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Timovi", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Lige", "Liga")
                        .WithMany("Timovi")
                        .HasForeignKey("LigaId")
                        .HasConstraintName("FK__Timovi__LigaID__45F365D3");

                    b.HasOne("SeminarskiRS2.webApi.Database.Stadioni", "Stadion")
                        .WithMany("Timovi")
                        .HasForeignKey("StadionId")
                        .HasConstraintName("FK__Timovi__StadionI__44FF419A");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Tribine", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Stadioni", "Stadion")
                        .WithMany("Tribine")
                        .HasForeignKey("StadionId")
                        .HasConstraintName("FK__Tribine__Stadion__4CA06362");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Ulaznice", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Korisnici", "Korisnik")
                        .WithMany("Ulaznice")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK__Ulaznice__Korisn__5CD6CB2B");

                    b.HasOne("SeminarskiRS2.webApi.Database.Sjedala", "Sjedalo")
                        .WithMany("Ulaznice")
                        .HasForeignKey("SjedaloId")
                        .HasConstraintName("FK__Ulaznice__Sjedal__5AEE82B9");

                    b.HasOne("SeminarskiRS2.webApi.Database.Utakmice", "Utakmica")
                        .WithMany("Ulaznice")
                        .HasForeignKey("UtakmicaId")
                        .HasConstraintName("FK__Ulaznice__Utakmi__5BE2A6F2");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Uplate", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Ulaznice", "Ulaznica")
                        .WithMany("Uplate")
                        .HasForeignKey("UlaznicaId")
                        .HasConstraintName("FK__Uplate__Ulaznica__5FB337D6");
                });

            modelBuilder.Entity("SeminarskiRS2.webApi.Database.Utakmice", b =>
                {
                    b.HasOne("SeminarskiRS2.webApi.Database.Timovi", "DomaciTim")
                        .WithMany("UtakmiceDomaciTim")
                        .HasForeignKey("DomaciTimId")
                        .HasConstraintName("FK__Utakmice__Domaci__5535A963");

                    b.HasOne("SeminarskiRS2.webApi.Database.Timovi", "GostujuciTim")
                        .WithMany("UtakmiceGostujuciTim")
                        .HasForeignKey("GostujuciTimId")
                        .HasConstraintName("FK__Utakmice__Gostuj__5629CD9C");

                    b.HasOne("SeminarskiRS2.webApi.Database.Lige", "Liga")
                        .WithMany("Utakmice")
                        .HasForeignKey("LigaId")
                        .HasConstraintName("FK__Utakmice__LigaID__571DF1D5");

                    b.HasOne("SeminarskiRS2.webApi.Database.Stadioni", "Stadion")
                        .WithMany("Utakmice")
                        .HasForeignKey("StadionId")
                        .HasConstraintName("FK__Utakmice__Stadio__5812160E");
                });
#pragma warning restore 612, 618
        }
    }
}