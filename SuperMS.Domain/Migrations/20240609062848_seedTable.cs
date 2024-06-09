using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMS.Domain
{
    /// <inheritdoc />
    public partial class seedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO categories (name)
                VALUES 
                    ('מוצרי ניקיון'),
                    ('גבינות'),
                    ('ירקות ופירות'),
                    ('בשר ודגים'),
                    ('מאפים');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
