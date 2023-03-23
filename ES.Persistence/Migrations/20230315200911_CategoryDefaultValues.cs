using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryDefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Мясо', 'Продукция из мяса', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Рыба', 'Продукция из рыбы', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Молочные продукты', 'Продукты из молока', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Мучные изделия', 'Мучные товары', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Макаронные изделия', 'Макаронные изделия', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Бобовые', 'Бобовые продукты', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Овощи', 'Свежие овощи', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Фрукты и ягоды', 'Свежие фрукты и ягоды', null, null)");
            migrationBuilder.Sql("INSERT INTO public.\"Category\"(\"Id\", \"Name\", \"Description\", \"CategoryImageId\", \"RowVersion\") VALUES (gen_random_uuid(), 'Кондитерские изделия', 'Кондитерские продукты', null, null)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
