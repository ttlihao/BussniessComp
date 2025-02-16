using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuYou.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AdjustName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeMixDetail_CoffeeMixes_CoffeeMixId",
                table: "CoffeeMixDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_CoffeeMixes_CoffeeMixId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Orders_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Packaging_PackagingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLikes_AspNetUsers_UserId",
                table: "ReviewLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLikes_Reviews_ReviewId",
                table: "ReviewLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_CoffeeBean_CoffeeBeanId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_CoffeeMixes_CoffeeMixId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetail_Orders_OrderId",
                table: "ShippingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewLikes",
                table: "ReviewLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeMixes",
                table: "CoffeeMixes");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "ReviewLikes",
                newName: "ReviewLike");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "CoffeeMixes",
                newName: "CoffeeMix");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CoffeeMixId",
                table: "Review",
                newName: "IX_Review_CoffeeMixId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_CoffeeBeanId",
                table: "Review",
                newName: "IX_Review_CoffeeBeanId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewLikes_UserId",
                table: "ReviewLike",
                newName: "IX_ReviewLike_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewLikes_ReviewId",
                table: "ReviewLike",
                newName: "IX_ReviewLike_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PackagingId",
                table: "Order",
                newName: "IX_Order_PackagingId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DiscountId",
                table: "Order",
                newName: "IX_Order_DiscountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewLike",
                table: "ReviewLike",
                column: "ReviewLikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "DiscountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeMix",
                table: "CoffeeMix",
                column: "CoffeeMixId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeMixDetail_CoffeeMix_CoffeeMixId",
                table: "CoffeeMixDetail",
                column: "CoffeeMixId",
                principalTable: "CoffeeMix",
                principalColumn: "CoffeeMixId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Discount_DiscountId",
                table: "Order",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Packaging_PackagingId",
                table: "Order",
                column: "PackagingId",
                principalTable: "Packaging",
                principalColumn: "PackagingId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_CoffeeMix_CoffeeMixId",
                table: "OrderDetail",
                column: "CoffeeMixId",
                principalTable: "CoffeeMix",
                principalColumn: "CoffeeMixId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Order_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_CoffeeBean_CoffeeBeanId",
                table: "Review",
                column: "CoffeeBeanId",
                principalTable: "CoffeeBean",
                principalColumn: "CoffeeBeanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_CoffeeMix_CoffeeMixId",
                table: "Review",
                column: "CoffeeMixId",
                principalTable: "CoffeeMix",
                principalColumn: "CoffeeMixId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserId",
                table: "ReviewLike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLike_Review_ReviewId",
                table: "ReviewLike",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetail_Order_OrderId",
                table: "ShippingDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeMixDetail_CoffeeMix_CoffeeMixId",
                table: "CoffeeMixDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Discount_DiscountId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Packaging_PackagingId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_CoffeeMix_CoffeeMixId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Order_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_CoffeeBean_CoffeeBeanId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_CoffeeMix_CoffeeMixId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserId",
                table: "ReviewLike");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLike_Review_ReviewId",
                table: "ReviewLike");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetail_Order_OrderId",
                table: "ShippingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewLike",
                table: "ReviewLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeMix",
                table: "CoffeeMix");

            migrationBuilder.RenameTable(
                name: "ReviewLike",
                newName: "ReviewLikes");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "CoffeeMix",
                newName: "CoffeeMixes");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewLike_UserId",
                table: "ReviewLikes",
                newName: "IX_ReviewLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewLike_ReviewId",
                table: "ReviewLikes",
                newName: "IX_ReviewLikes_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_CoffeeMixId",
                table: "Reviews",
                newName: "IX_Reviews_CoffeeMixId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_CoffeeBeanId",
                table: "Reviews",
                newName: "IX_Reviews_CoffeeBeanId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PackagingId",
                table: "Orders",
                newName: "IX_Orders_PackagingId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DiscountId",
                table: "Orders",
                newName: "IX_Orders_DiscountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewLikes",
                table: "ReviewLikes",
                column: "ReviewLikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "DiscountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeMixes",
                table: "CoffeeMixes",
                column: "CoffeeMixId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeMixDetail_CoffeeMixes_CoffeeMixId",
                table: "CoffeeMixDetail",
                column: "CoffeeMixId",
                principalTable: "CoffeeMixes",
                principalColumn: "CoffeeMixId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_CoffeeMixes_CoffeeMixId",
                table: "OrderDetail",
                column: "CoffeeMixId",
                principalTable: "CoffeeMixes",
                principalColumn: "CoffeeMixId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Orders_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_DiscountId",
                table: "Orders",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Packaging_PackagingId",
                table: "Orders",
                column: "PackagingId",
                principalTable: "Packaging",
                principalColumn: "PackagingId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLikes_AspNetUsers_UserId",
                table: "ReviewLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLikes_Reviews_ReviewId",
                table: "ReviewLikes",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_CoffeeBean_CoffeeBeanId",
                table: "Reviews",
                column: "CoffeeBeanId",
                principalTable: "CoffeeBean",
                principalColumn: "CoffeeBeanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_CoffeeMixes_CoffeeMixId",
                table: "Reviews",
                column: "CoffeeMixId",
                principalTable: "CoffeeMixes",
                principalColumn: "CoffeeMixId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetail_Orders_OrderId",
                table: "ShippingDetail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
