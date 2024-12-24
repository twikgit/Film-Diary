using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country_code = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Country_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__73B286F47544956F", x => x.Country_code);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Genre_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Genre_PK", x => x.Genre_Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Language_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Language_PK", x => x.Language_Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Rating",
                columns: table => new
                {
                    Movie_Rating_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Movie_Rating_PK", x => x.Movie_Rating_Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__D80BB0938ABB21FC", x => x.Role_id);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Role",
                columns: table => new
                {
                    Staff_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff_Ro__337A625B3241C4E4", x => x.Staff_role_id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Status_code = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__A3EABA77740422EB", x => x.Status_code);
                });

            migrationBuilder.CreateTable(
                name: "User_List_Status",
                columns: table => new
                {
                    User_List_Status_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_List_Status_PK", x => x.User_List_Status_Id);
                });

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Actor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Last_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    Height = table.Column<short>(type: "smallint", nullable: true),
                    Bio = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Nationality = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    Photo_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Actor__E5771745101C27C0", x => x.Actor_id);
                    table.ForeignKey(
                        name: "FK__Actor__Nationali__59FA5E80",
                        column: x => x.Nationality,
                        principalTable: "Country",
                        principalColumn: "Country_code");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Pass = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    First_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Last_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Bio = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    Country_code = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    Role_id = table.Column<short>(type: "smallint", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Created_by = table.Column<int>(type: "int", nullable: true),
                    Updated_by = table.Column<int>(type: "int", nullable: true),
                    Deleted_by = table.Column<int>(type: "int", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Banner = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__8CB382B17C1748B9", x => x.Customer_id);
                    table.ForeignKey(
                        name: "FK__Customer__Countr__3E52440B",
                        column: x => x.Country_code,
                        principalTable: "Country",
                        principalColumn: "Country_code");
                    table.ForeignKey(
                        name: "FK__Customer__Create__4316F928",
                        column: x => x.Created_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Customer__Delete__44FF419A",
                        column: x => x.Deleted_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Customer__Role_i__3F466844",
                        column: x => x.Role_id,
                        principalTable: "Role",
                        principalColumn: "Role_id");
                    table.ForeignKey(
                        name: "FK__Customer__Update__440B1D61",
                        column: x => x.Updated_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Last_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    Bio = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Nationality = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: true),
                    Staff_role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Staff__32D2E85B7C4AD946", x => x.Staff_id);
                    table.ForeignKey(
                        name: "FK__Staff__Nationali__0B91BA14",
                        column: x => x.Nationality,
                        principalTable: "Country",
                        principalColumn: "Country_code");
                    table.ForeignKey(
                        name: "FK__Staff__Staff_rol__0C85DE4D",
                        column: x => x.Staff_role_id,
                        principalTable: "Staff_Role",
                        principalColumn: "Staff_role_id");
                });

            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    Requester_id = table.Column<int>(type: "int", nullable: false),
                    Addressee_id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Friendsh__D58EA5D95B7E0C5D", x => new { x.Requester_id, x.Addressee_id });
                    table.ForeignKey(
                        name: "FK__Friendshi__Addre__48CFD27E",
                        column: x => x.Addressee_id,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Friendshi__Reque__47DBAE45",
                        column: x => x.Requester_id,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Movie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Release_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Budget = table.Column<long>(type: "bigint", nullable: true),
                    Revenue = table.Column<long>(type: "bigint", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Created_by = table.Column<int>(type: "int", nullable: true),
                    Updated_by = table.Column<int>(type: "int", nullable: true),
                    Deleted_by = table.Column<int>(type: "int", nullable: true),
                    Poster_url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Is_Airing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movie__7A89F80D328DAFCC", x => x.Movie_id);
                    table.ForeignKey(
                        name: "FK__Movie__Created_b__619B8048",
                        column: x => x.Created_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Movie__Deleted_b__6383C8BA",
                        column: x => x.Deleted_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Movie__Updated_b__628FA481",
                        column: x => x.Updated_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "Movie_FK1",
                        column: x => x.Rating,
                        principalTable: "Movie_Rating",
                        principalColumn: "Movie_Rating_Id");
                });

            migrationBuilder.CreateTable(
                name: "Friendship_Status",
                columns: table => new
                {
                    Requester_id = table.Column<int>(type: "int", nullable: false),
                    Addressee_id = table.Column<int>(type: "int", nullable: false),
                    Specified_datetime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status_code = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Specified_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Friendsh__48CE34DB9DA1E626", x => new { x.Requester_id, x.Addressee_id, x.Specified_datetime });
                    table.ForeignKey(
                        name: "FK__Friendshi__Speci__5070F446",
                        column: x => x.Specified_id,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Friendshi__Statu__778AC167",
                        column: x => x.Status_code,
                        principalTable: "Status",
                        principalColumn: "Status_code");
                    table.ForeignKey(
                        name: "FriendshipStatusToFriendship_FK",
                        columns: x => new { x.Requester_id, x.Addressee_id },
                        principalTable: "Friendship",
                        principalColumns: new[] { "Requester_id", "Addressee_id" });
                });

            migrationBuilder.CreateTable(
                name: "Movie_Cast",
                columns: table => new
                {
                    Actor_id = table.Column<int>(type: "int", nullable: false),
                    Movie_id = table.Column<int>(type: "int", nullable: false),
                    Character_name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movie_Ca__22DF88C5305CD3F4", x => new { x.Actor_id, x.Movie_id });
                    table.ForeignKey(
                        name: "FK__Movie_Cas__Actor__6B24EA82",
                        column: x => x.Actor_id,
                        principalTable: "Actor",
                        principalColumn: "Actor_id");
                    table.ForeignKey(
                        name: "FK__Movie_Cas__Movie__6C190EBB",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                });

            migrationBuilder.CreateTable(
                name: "Movie_Genres",
                columns: table => new
                {
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    Genre_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Movie_Genres_PK", x => new { x.Movie_Id, x.Genre_Id });
                    table.ForeignKey(
                        name: "Movie_Genres_FK1",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                    table.ForeignKey(
                        name: "Movie_Genres_FK2",
                        column: x => x.Genre_Id,
                        principalTable: "Genre",
                        principalColumn: "Genre_Id");
                });

            migrationBuilder.CreateTable(
                name: "Movie_Languages",
                columns: table => new
                {
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    Language_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Movie_Languages_PK", x => new { x.Movie_Id, x.Language_Id });
                    table.ForeignKey(
                        name: "Movie_Languages_FK1",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                    table.ForeignKey(
                        name: "Movie_Languages_FK2",
                        column: x => x.Language_Id,
                        principalTable: "Language",
                        principalColumn: "Language_Id");
                });

            migrationBuilder.CreateTable(
                name: "Movie_Staff",
                columns: table => new
                {
                    Staff_id = table.Column<int>(type: "int", nullable: false),
                    Movie_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Movie_St__F57A77DBD029D42B", x => new { x.Staff_id, x.Movie_id });
                    table.ForeignKey(
                        name: "FK__Movie_Sta__Movie__68487DD7",
                        column: x => x.Movie_id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                    table.ForeignKey(
                        name: "FK__Movie_Sta__Staff__03F0984C",
                        column: x => x.Staff_id,
                        principalTable: "Staff",
                        principalColumn: "Staff_id");
                });

            migrationBuilder.CreateTable(
                name: "Production_Country",
                columns: table => new
                {
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    Country_code = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Production_Country_PK", x => new { x.Movie_Id, x.Country_code });
                    table.ForeignKey(
                        name: "Production_Country_FK1",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                    table.ForeignKey(
                        name: "Production_Country_FK2",
                        column: x => x.Country_code,
                        principalTable: "Country",
                        principalColumn: "Country_code");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    Review_Content = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Created_by = table.Column<int>(type: "int", nullable: false),
                    Updated_by = table.Column<int>(type: "int", nullable: true),
                    Deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Review_PK", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK__Review__Created___71D1E811",
                        column: x => x.Created_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Review__Deleted___73BA3083",
                        column: x => x.Deleted_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK__Review__Updated___72C60C4A",
                        column: x => x.Updated_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "Review_FK1",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "Review_FK2",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                });

            migrationBuilder.CreateTable(
                name: "User_List",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Movie_Id = table.Column<int>(type: "int", nullable: false),
                    User_List_Status_Id = table.Column<int>(type: "int", nullable: false),
                    Movie_Score = table.Column<byte>(type: "tinyint", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    Created_by = table.Column<int>(type: "int", nullable: false),
                    Updated_by = table.Column<int>(type: "int", nullable: true),
                    Deleted_by = table.Column<int>(type: "int", nullable: true),
                    Is_Favorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_List_PK", x => new { x.Customer_Id, x.Movie_Id });
                    table.ForeignKey(
                        name: "User_List_FK1",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "User_List_FK2",
                        column: x => x.Movie_Id,
                        principalTable: "Movie",
                        principalColumn: "Movie_id");
                    table.ForeignKey(
                        name: "User_List_FK3",
                        column: x => x.User_List_Status_Id,
                        principalTable: "User_List_Status",
                        principalColumn: "User_List_Status_Id");
                    table.ForeignKey(
                        name: "User_List_FK4",
                        column: x => x.Created_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "User_List_FK5",
                        column: x => x.Updated_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "User_List_FK6",
                        column: x => x.Deleted_by,
                        principalTable: "Customer",
                        principalColumn: "Customer_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actor_Nationality",
                table: "Actor",
                column: "Nationality");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Country_code",
                table: "Customer",
                column: "Country_code");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Created_by",
                table: "Customer",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Deleted_by",
                table: "Customer",
                column: "Deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Role_id",
                table: "Customer",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Updated_by",
                table: "Customer",
                column: "Updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_Addressee_id",
                table: "Friendship",
                column: "Addressee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_Status_Specified_id",
                table: "Friendship_Status",
                column: "Specified_id");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_Status_Status_code",
                table: "Friendship_Status",
                column: "Status_code");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Created_by",
                table: "Movie",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Deleted_by",
                table: "Movie",
                column: "Deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Rating",
                table: "Movie",
                column: "Rating");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Updated_by",
                table: "Movie",
                column: "Updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Cast_Movie_id",
                table: "Movie_Cast",
                column: "Movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Genres_Genre_Id",
                table: "Movie_Genres",
                column: "Genre_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Languages_Language_Id",
                table: "Movie_Languages",
                column: "Language_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Staff_Movie_id",
                table: "Movie_Staff",
                column: "Movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_Production_Country_Country_code",
                table: "Production_Country",
                column: "Country_code");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Created_by",
                table: "Review",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Customer_Id",
                table: "Review",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Deleted_by",
                table: "Review",
                column: "Deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Movie_Id",
                table: "Review",
                column: "Movie_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Updated_by",
                table: "Review",
                column: "Updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Nationality",
                table: "Staff",
                column: "Nationality");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Staff_role_id",
                table: "Staff",
                column: "Staff_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_List_Created_by",
                table: "User_List",
                column: "Created_by");

            migrationBuilder.CreateIndex(
                name: "IX_User_List_Deleted_by",
                table: "User_List",
                column: "Deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_User_List_Movie_Id",
                table: "User_List",
                column: "Movie_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_List_Updated_by",
                table: "User_List",
                column: "Updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_User_List_User_List_Status_Id",
                table: "User_List",
                column: "User_List_Status_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendship_Status");

            migrationBuilder.DropTable(
                name: "Movie_Cast");

            migrationBuilder.DropTable(
                name: "Movie_Genres");

            migrationBuilder.DropTable(
                name: "Movie_Languages");

            migrationBuilder.DropTable(
                name: "Movie_Staff");

            migrationBuilder.DropTable(
                name: "Production_Country");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "User_List");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Friendship");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User_List_Status");

            migrationBuilder.DropTable(
                name: "Staff_Role");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Movie_Rating");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
