using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LisbrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_AspNetUsers_UserId",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_AspNetUsers_UserId",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Books_BookId",
                table: "Buy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buy",
                table: "Buy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Borrow",
                table: "Borrow");

            migrationBuilder.RenameTable(
                name: "Buy",
                newName: "Buys");

            migrationBuilder.RenameTable(
                name: "Borrow",
                newName: "Borrows");

            migrationBuilder.RenameIndex(
                name: "IX_Buy_UserId",
                table: "Buys",
                newName: "IX_Buys_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Buy_BookId",
                table: "Buys",
                newName: "IX_Buys_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_UserId",
                table: "Borrows",
                newName: "IX_Borrows_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_BookId",
                table: "Borrows",
                newName: "IX_Borrows_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buys",
                table: "Buys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Borrows",
                table: "Borrows",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd02275e-a243-415c-9c53-b67c7cbd06bd", "AQAAAAIAAYagAAAAEFyZrCpRv87GqiFkJ+BHpUxCzhsWvs8/hCdt4cgzZWI1+g1vurrlIO4LovtSl7Z0DA==", "3551e135-5427-4917-8b52-501f127f30e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "042792c8-a642-494d-989d-64477719dcc3", "AQAAAAIAAYagAAAAEIPDmUHlRp95LyyVe635gg6pQAKYRV3LiUpghbkxRJimiyc1xtLo5JKZtpTP/kMv4Q==", "889b5c0b-c75b-4b95-b96f-2af64c8cafb8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_AspNetUsers_UserId",
                table: "Borrows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_AspNetUsers_UserId",
                table: "Buys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Books_BookId",
                table: "Buys",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_AspNetUsers_UserId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_AspNetUsers_UserId",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Books_BookId",
                table: "Buys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buys",
                table: "Buys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Borrows",
                table: "Borrows");

            migrationBuilder.RenameTable(
                name: "Buys",
                newName: "Buy");

            migrationBuilder.RenameTable(
                name: "Borrows",
                newName: "Borrow");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_UserId",
                table: "Buy",
                newName: "IX_Buy_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_BookId",
                table: "Buy",
                newName: "IX_Buy_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_UserId",
                table: "Borrow",
                newName: "IX_Borrow_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_BookId",
                table: "Borrow",
                newName: "IX_Borrow_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buy",
                table: "Buy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Borrow",
                table: "Borrow",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7c41d08-5b1f-4843-b12a-5b72394d4c49", "AQAAAAIAAYagAAAAEKwLCtq0fg17fFIckt8rm1wI5QvIndiIwbAcND7D66Vd1WCIYUeke/rB5SCZ90XliA==", "c99a6f0b-ef09-4602-942e-14284f2b101a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebdfee3d-093e-4b8c-8af5-0a4087d7765e", "AQAAAAIAAYagAAAAEA6qQghHZU2xVGHMZyPSaymtD6nr71t0Rp0LvZ61Ac/AismzUz+FnjVtEtH6Mkhq5Q==", "e2db1e7f-8213-4f29-b2c8-45d1e3d9d570" });

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_AspNetUsers_UserId",
                table: "Borrow",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Books_BookId",
                table: "Borrow",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_AspNetUsers_UserId",
                table: "Buy",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Books_BookId",
                table: "Buy",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
