using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240617_1704 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Create Procedure CreateCarCalendarFromDateRange(@carId int, @startDate datetime, @endDate datetime, @userId int)
                As

                Declare @now datetime = getutcdate();


                ;WITH DatesFromRange(d) AS 
                (
                    SELECT @startDate as d
                    UNION ALL
                    SELECT DATEADD(day, 1, d) as d
                    FROM DatesFromRange
                    WHERE DATEADD(day, 1, d) <= @endDate
                )

                INSERT INTO CarCalendar (CalendarDate, CarId, CreatedDate, ModifiedDate, CreatedUser, ModifiedUser)
                SELECT [d], @carId, @now, @now, @userId, @userId FROM DatesFromRange OPTION(MAXRECURSION 100);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
