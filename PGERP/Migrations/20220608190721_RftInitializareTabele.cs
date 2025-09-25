using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGERP.Migrations
{
    public partial class RftInitializareTabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RftModelAutentificariSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataAutentificare = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Utilizator = table.Column<string>(type: "TEXT", nullable: true),
                    IP = table.Column<string>(type: "TEXT", nullable: true),
                    DNS = table.Column<string>(type: "TEXT", nullable: true),
                    Stare = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelAutentificariSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelBugetSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Total = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Nealocat = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cumparaturi = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Divertisment = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Educatie = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Facturi = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Sanatate = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Transport = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    CumparaturiAlimente = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    CumparaturiElectronice = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    CumparaturiImbracaminte = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    DivertismentFilme = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    DivertismentJocuri = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    DivertismentMuzica = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    EducatieCartiElectronice = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    EducatieEvenimente = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    EducatieInvatamant = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    FacturiApa = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    FacturiCurent = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    FacturiTelefonie = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    SanatateActivitatiSportive = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    SanatateMedical = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    TransportComun = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    TransportPersonal = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelBugetSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelCumparaturiAlimenteSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    GramajTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelCumparaturiAlimenteSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelCumparaturiElectroniceSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatorare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelCumparaturiElectroniceSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelCumparaturiImbracaminteSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelCumparaturiImbracaminteSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelDivertismentFilmeSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelDivertismentFilmeSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelDivertismentJocuriSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelDivertismentJocuriSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelDivertismentMuzicaSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelDivertismentMuzicaSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelEducatieCartiElectroniceset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelEducatieCartiElectroniceset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelEducatieEvenimenteSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelEducatieEvenimenteSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelEducatieInvatamantSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireInstitutie = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelEducatieInvatamantSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelFacturiApaSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    CantitateMetriiCubi = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelFacturiApaSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelFacturiCurentSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    CantitateKW = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelFacturiCurentSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelFacturiTelefonieSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelFacturiTelefonieSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelSanatateActivitatiSportiveSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelSanatateActivitatiSportiveSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelSanatateMedicalSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Cantitate = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    DenumireMagazin = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPaginaInternet = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelSanatateMedicalSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelTemaCuloriSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CuloriInchise = table.Column<bool>(type: "INTEGER", nullable: false),
                    CuloriDeschise = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelTemaCuloriSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelTransportComunSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    DistantaKm = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieInitiala = table.Column<string>(type: "TEXT", nullable: true),
                    Destinatie = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelTransportComunSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelTransportPersonalSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categorie = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pret = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    CantitateLitri = table.Column<int>(type: "INTEGER", nullable: false),
                    DistantaKm = table.Column<int>(type: "INTEGER", nullable: false),
                    Tranzactie = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaProducatoare = table.Column<string>(type: "TEXT", nullable: true),
                    MetodaPlata = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutiaFinanciara = table.Column<string>(type: "TEXT", nullable: true),
                    LocatieDocumente = table.Column<string>(type: "TEXT", nullable: true),
                    Notite = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelTransportPersonalSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RftModelUtilizatoriSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInregistrare = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Utilizator = table.Column<string>(type: "TEXT", nullable: true),
                    Parola = table.Column<string>(type: "TEXT", nullable: true),
                    Prenume = table.Column<string>(type: "TEXT", nullable: true),
                    Nume = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelUtilizatoriSet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RftModelAutentificariSet");

            migrationBuilder.DropTable(
                name: "RftModelBugetSet");

            migrationBuilder.DropTable(
                name: "RftModelCumparaturiAlimenteSet");

            migrationBuilder.DropTable(
                name: "RftModelCumparaturiElectroniceSet");

            migrationBuilder.DropTable(
                name: "RftModelCumparaturiImbracaminteSet");

            migrationBuilder.DropTable(
                name: "RftModelDivertismentFilmeSet");

            migrationBuilder.DropTable(
                name: "RftModelDivertismentJocuriSet");

            migrationBuilder.DropTable(
                name: "RftModelDivertismentMuzicaSet");

            migrationBuilder.DropTable(
                name: "RftModelEducatieCartiElectroniceset");

            migrationBuilder.DropTable(
                name: "RftModelEducatieEvenimenteSet");

            migrationBuilder.DropTable(
                name: "RftModelEducatieInvatamantSet");

            migrationBuilder.DropTable(
                name: "RftModelFacturiApaSet");

            migrationBuilder.DropTable(
                name: "RftModelFacturiCurentSet");

            migrationBuilder.DropTable(
                name: "RftModelFacturiTelefonieSet");

            migrationBuilder.DropTable(
                name: "RftModelSanatateActivitatiSportiveSet");

            migrationBuilder.DropTable(
                name: "RftModelSanatateMedicalSet");

            migrationBuilder.DropTable(
                name: "RftModelTemaCuloriSet");

            migrationBuilder.DropTable(
                name: "RftModelTransportComunSet");

            migrationBuilder.DropTable(
                name: "RftModelTransportPersonalSet");

            migrationBuilder.DropTable(
                name: "RftModelUtilizatoriSet");
        }
    }
}
