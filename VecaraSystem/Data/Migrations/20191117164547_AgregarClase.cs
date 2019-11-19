using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VecaraSystem.Data.Migrations
{
    public partial class AgregarClase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(maxLength: 11, nullable: false),
                    Direccion = table.Column<string>(maxLength: 200, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoParqueos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Longitud = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoParqueos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(maxLength: 11, nullable: false),
                    Direccion = table.Column<string>(maxLength: 200, nullable: false),
                    Id_Empleado = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Empleados_Id_Empleado",
                        column: x => x.Id_Empleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Marca = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_Id_Marca",
                        column: x => x.Id_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parqueos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Disponibilidad = table.Column<string>(maxLength: 10, nullable: false),
                    Id_TipoParqueo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parqueos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parqueos_TipoParqueos_Id_TipoParqueo",
                        column: x => x.Id_TipoParqueo,
                        principalTable: "TipoParqueos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anio = table.Column<string>(maxLength: 4, nullable: false),
                    Id_Cliente = table.Column<int>(nullable: false),
                    Id_Modelo = table.Column<int>(nullable: false),
                    Placa = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Clientes_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Modelos_Id_Modelo",
                        column: x => x.Id_Modelo,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlAcceso",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaEntrada = table.Column<DateTime>(type: "date", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "date", nullable: true),
                    Id_Empleado = table.Column<int>(nullable: false),
                    Id_Parqueo = table.Column<int>(nullable: false),
                    Id_Vehiculo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAcceso", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ControlAcceso_Empleados_Id_Empleado",
                        column: x => x.Id_Empleado,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlAcceso_Parqueos_Id_Parqueo",
                        column: x => x.Id_Parqueo,
                        principalTable: "Parqueos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlAcceso_Vehiculos_Id_Vehiculo",
                        column: x => x.Id_Vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Id_ControlAcceso = table.Column<int>(nullable: false),
                    Id_TipoPago = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_ControlAcceso_Id_ControlAcceso",
                        column: x => x.Id_ControlAcceso,
                        principalTable: "ControlAcceso",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_TipoPagos_Id_TipoPago",
                        column: x => x.Id_TipoPago,
                        principalTable: "TipoPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Id_Empleado",
                table: "Clientes",
                column: "Id_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAcceso_Id_Empleado",
                table: "ControlAcceso",
                column: "Id_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAcceso_Id_Parqueo",
                table: "ControlAcceso",
                column: "Id_Parqueo");

            migrationBuilder.CreateIndex(
                name: "IX_ControlAcceso_Id_Vehiculo",
                table: "ControlAcceso",
                column: "Id_Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Id_Marca",
                table: "Modelos",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Id_ControlAcceso",
                table: "Pagos",
                column: "Id_ControlAcceso");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Id_TipoPago",
                table: "Pagos",
                column: "Id_TipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Parqueos_Id_TipoParqueo",
                table: "Parqueos",
                column: "Id_TipoParqueo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Id_Cliente",
                table: "Vehiculos",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Id_Modelo",
                table: "Vehiculos",
                column: "Id_Modelo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "ControlAcceso");

            migrationBuilder.DropTable(
                name: "TipoPagos");

            migrationBuilder.DropTable(
                name: "Parqueos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "TipoParqueos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
