using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240619_1157 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Alter Procedure GetAvailableCars (@fromDate datetime, @toDate datetime, @countryId int, @skip int, @take int)
                As
                declare @now datetime = getutcdate();

                WITH DateRange AS (
                    SELECT @fromDate AS Date
                    UNION ALL
                    SELECT DATEADD(day, 1, Date)
                    FROM DateRange
                    WHERE Date < @toDate
                )

                SELECT 
	                Cars.Id,
	                CarBrands.Name as BrandName,
	                Cars.NumberPlate,
	                Cars.DailyPrice,
	                COUNT(*) OVER (partition by 1) as TotalCount  
                FROM 
	                Cars 
                INNER JOIN
	                CarBrands ON CarBrands.Id = Cars.CarBrandId
                WHERE
	                Cars.IsActive = 1 And
	                Cars.PlacedInCountryId = @countryId And 
	                NOT EXISTS (
    	                SELECT 
    		                1
	                    FROM
    	 	                DateRange 
	                    LEFT JOIN
    		                CarCalendar ON CarCalendar.CarId = Cars.Id AND CarCalendar.CalendarDate = DateRange.Date
	                    WHERE
    	 	                CarCalendar.Status = 1 Or
			                CarCalendar.Id is null Or
			                (CarCalendar.HoldUpToDate is not null And CarCalendar.HoldUpToDate > @now)
	                )

                ORDER BY
	                Cars.Id Desc
                OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY
                OPTION (MAXRECURSION 0)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
