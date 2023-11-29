﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservices.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponID", "CouponCode", "DiscountAmount", "LastUpdated", "MinAmount" },
                values: new object[,]
                {
                    { 1, "1G0FF", 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2, "2CB45", 20.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponID",
                keyValue: 2);
        }
    }
}
