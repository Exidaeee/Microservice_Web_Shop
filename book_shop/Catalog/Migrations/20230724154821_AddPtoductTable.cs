using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Host.Migrations
{
    /// <inheritdoc />
    public partial class AddPtoductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryName", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Фредрік Бакман", "Художня література", "Час багато чого змінює, але хокейне містечко Бйорнстад продовжує жити, долаючи минуле. Майя знову повертається у місто, аби завітати до улюбленого бару, водночас кипляча напруга та бажання помсти ще жевріє у містечці серед лісів.Через складнощі повсякденного життя та дослідження дружби, вірності та втрати, цей емоційний роман змусить вас переглянути своє ставлення до перемоги, поразок та прощення.", "/Proxy/assets/images/переможці.jpg", 500, "Переможці" },
                    { 2, "Пилип Білянський", "Художня література", "Прокидатися. Висовувати голову з холодної води, витріщати очі в небо і ляскати ротом. Лякатися. Придумувати собі якийсь ґрунт, землю, основу. Відрощувати ноги, вуха. А опісля — прибиватися до двоногих риб. І скоса поглядати на воду, сумніваючись у правильності своїх рішень.", "/Proxy/assets/images/луни.png", 230, "Луни" },
                    { 3, "Стівен Кінг", "Триллер", "Сімнадцятирічний Чарлі Рід, який дитиною втратив матір, однак навчився давати собі раду, ще й доглядати за батьком-алкоголіком, порятував відлюдькуватого сусіда Говарда Боудітча та найнявся до нього на роботу. Саме там хлопець знайшов собі вірного друга - собаку Радар.", "/Proxy/assets/images/казка.png", 600, "Казка" },
                    { 4, "Ілларіон Павлюк", "Детектив", "Київського кримінального психолога Андрія Гайстера відправляють консультантом у богом забуте селище Буськів Сад. Зимової ночі там зникла маленька дівчинка. А ще там водиться Звір — серійний маніяк, убивств якого тамтешні мешканці воліють не помічати...", "/Proxy/assets/images/пітьма.png", 489, "Я бачу, вас цікавить пітьма" },
                    { 5, "Коллін Гувер", "Художня література", "Як знати, що кохання справжнє? А який він — любовний поцілунок як у книжках? Як вісімнадцятирічним зрозуміти, що ця хімія гормонів переросте в щире кохання на все життя? І чи можна пробачити тому, хто збрехав ще в день знайомства? ", "/Proxy/assets/images/9листопада.png", 550, "9 листопада" },
                    { 6, "Стівен Кінг", "Триллер", "Legendary storyteller Stephen King goes into the deepest well of his imagination in this spellbinding novel about a seventeen-year-old boy who inherits the keys to a parallel world where good and evil are at war, and the stakes could not be higher - for their world or ours.", "/Proxy/assets/images/феї.png", 500, "Fairy Tale" },
                    { 7, "Крістін Генна", "Художня література", "Крістін Генна влучно описує слабкість і стійкість людини, майстерно змальовує незламний дух американських першопрохідців і атмосферу вже напівзниклої Аляски — незрівнянно прекрасної і невблаганно небезпечної землі.", "/Proxy/assets/images/глушина.png", 700, "Велика глушина" },
                    { 8, "Фредрік Бакман", "Художня література", "Це зворушлива комедія, а водночас психологічний роман про злочин, який ніколи не відбувся.", "/Proxy/assets/images/люди.png", 550, "Тривожні люди" },
                    { 9, "Халед Госсейні", "Художня література", "Одного морозного дня взимку 1975-го афганський хлопчик Амір стає свідком жахливого вчинку. Ця подія назавжди змінює і його власне життя, і долю його близького приятеля Гассана.", "/Proxy/assets/images/ловець.png", 400, "Ловець повітряних зміїв" },
                    { 10, "Фредрік Бакман", "Художня література", " «Ведмеже місто» розповідає про багатогранну людську природу. У глухому містечку Бьорнстад колись вирувало життя, а зараз лишилось безробіття та безвихідь. Уся надія міста – юнацький хокейний клуб.", "/Proxy/assets/images/місто.png", 385, "Ведмеже місто" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
