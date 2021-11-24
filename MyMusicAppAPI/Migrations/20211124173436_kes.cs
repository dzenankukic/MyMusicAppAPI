using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMusicAppAPI.Migrations
{
    public partial class kes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Song",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hip Hop" },
                    { 2, "Blues" },
                    { 3, "Rock" },
                    { 4, "Dance" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "Id", "ArtistName", "CategoryID", "EditDate", "EntredDAte", "Name", "Rating", "SongUrl", "isFavourite" },
                values: new object[,]
                {
                    { 1, "Eminem", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), "Lose Yourself", 5, "https://www.youtube.com/watch?v=_Yhyp-_hX2s", true },
                    { 2, "50 Cent", 1, new DateTime(2021, 8, 2, 9, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "In Da Club", 3, "https://www.youtube.com/watch?v=5qm8PH4xAss", true },
                    { 8, "Eminem", 1, new DateTime(2021, 4, 3, 4, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 3, 2, 30, 52, 0, DateTimeKind.Unspecified), "Not Afraid", 3, "https://www.youtube.com/watch?v=j5-yKhDd64s", false },
                    { 6, "Freddy Cole", 2, new DateTime(2021, 5, 3, 2, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 3, 2, 30, 52, 0, DateTimeKind.Unspecified), "This Time I'm Gone for Good", 5, "https://www.youtube.com/watch?v=5lrSdW8p4u4", true },
                    { 7, "The White Buffalo", 2, new DateTime(2021, 5, 3, 2, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 3, 2, 30, 52, 0, DateTimeKind.Unspecified), "House of the Rising Sun", 3, "https://www.youtube.com/watch?v=MOqm0qGJhpw", false },
                    { 3, "The Rolling Stones", 3, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "Paint It, Black", 5, "https://www.youtube.com/watch?v=O4irXQhgMqg", false },
                    { 4, "The Rolling Stones", 3, new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "Miss You", 5, "https://www.youtube.com/watch?v=KuRxXRuAz-I", false },
                    { 5, "Stromae", 4, new DateTime(2020, 1, 3, 5, 30, 52, 0, DateTimeKind.Unspecified), new DateTime(2012, 2, 2, 1, 30, 52, 0, DateTimeKind.Unspecified), "Alors On Danse", 3, "https://www.youtube.com/watch?v=VHoT4N43jK8", true }
                });
        }
    }
}
