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
                INSERT INTO categories (id,name)
                VALUES 
                    (1,'מוצרי ניקיון'),
                    (2,'גבינות'),
                    (3,'ירקות ופירות'),
                    (4,'בשר ודגים'),
                    (5,'מאפים');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
