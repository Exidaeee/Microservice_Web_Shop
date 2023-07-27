﻿// <auto-generated />
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230725222604_UpdateImdUrl")]
    partial class UpdateImdUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Host.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Фредрік Бакман",
                            CategoryName = "Художня література",
                            Description = "Час багато чого змінює, але хокейне містечко Бйорнстад продовжує жити, долаючи минуле. Майя знову повертається у місто, аби завітати до улюбленого бару, водночас кипляча напруга та бажання помсти ще жевріє у містечці серед лісів.Через складнощі повсякденного життя та дослідження дружби, вірності та втрати, цей емоційний роман змусить вас переглянути своє ставлення до перемоги, поразок та прощення.",
                            ImageUrl = "/proxy/assets/images/переможці.jpg",
                            Price = 500,
                            Title = "Переможці"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Пилип Білянський",
                            CategoryName = "Художня література",
                            Description = "Прокидатися. Висовувати голову з холодної води, витріщати очі в небо і ляскати ротом. Лякатися. Придумувати собі якийсь ґрунт, землю, основу. Відрощувати ноги, вуха. А опісля — прибиватися до двоногих риб. І скоса поглядати на воду, сумніваючись у правильності своїх рішень.",
                            ImageUrl = "/proxy/assets/images/луни.png",
                            Price = 230,
                            Title = "Луни"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Стівен Кінг",
                            CategoryName = "Триллер",
                            Description = "Сімнадцятирічний Чарлі Рід, який дитиною втратив матір, однак навчився давати собі раду, ще й доглядати за батьком-алкоголіком, порятував відлюдькуватого сусіда Говарда Боудітча та найнявся до нього на роботу. Саме там хлопець знайшов собі вірного друга - собаку Радар.",
                            ImageUrl = "/proxy/assets/images/казка.png",
                            Price = 600,
                            Title = "Казка"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Ілларіон Павлюк",
                            CategoryName = "Детектив",
                            Description = "Київського кримінального психолога Андрія Гайстера відправляють консультантом у богом забуте селище Буськів Сад. Зимової ночі там зникла маленька дівчинка. А ще там водиться Звір — серійний маніяк, убивств якого тамтешні мешканці воліють не помічати...",
                            ImageUrl = "/proxy/assets/images/пітьма.png",
                            Price = 489,
                            Title = "Я бачу, вас цікавить пітьма"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Коллін Гувер",
                            CategoryName = "Художня література",
                            Description = "Як знати, що кохання справжнє? А який він — любовний поцілунок як у книжках? Як вісімнадцятирічним зрозуміти, що ця хімія гормонів переросте в щире кохання на все життя? І чи можна пробачити тому, хто збрехав ще в день знайомства? ",
                            ImageUrl = "/proxy/assets/images/9листопада.png",
                            Price = 550,
                            Title = "9 листопада"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Стівен Кінг",
                            CategoryName = "Триллер",
                            Description = "Legendary storyteller Stephen King goes into the deepest well of his imagination in this spellbinding novel about a seventeen-year-old boy who inherits the keys to a parallel world where good and evil are at war, and the stakes could not be higher - for their world or ours.",
                            ImageUrl = "/proxy/assets/images/феї.png",
                            Price = 500,
                            Title = "Fairy Tale"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Крістін Генна",
                            CategoryName = "Художня література",
                            Description = "Крістін Генна влучно описує слабкість і стійкість людини, майстерно змальовує незламний дух американських першопрохідців і атмосферу вже напівзниклої Аляски — незрівнянно прекрасної і невблаганно небезпечної землі.",
                            ImageUrl = "/proxy/assets/images/глушина.png",
                            Price = 700,
                            Title = "Велика глушина"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Фредрік Бакман",
                            CategoryName = "Художня література",
                            Description = "Це зворушлива комедія, а водночас психологічний роман про злочин, який ніколи не відбувся.",
                            ImageUrl = "/proxy/assets/images/люди.png",
                            Price = 550,
                            Title = "Тривожні люди"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Халед Госсейні",
                            CategoryName = "Художня література",
                            Description = "Одного морозного дня взимку 1975-го афганський хлопчик Амір стає свідком жахливого вчинку. Ця подія назавжди змінює і його власне життя, і долю його близького приятеля Гассана.",
                            ImageUrl = "/proxy/assets/images/ловець.png",
                            Price = 400,
                            Title = "Ловець повітряних зміїв"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Фредрік Бакман",
                            CategoryName = "Художня література",
                            Description = " «Ведмеже місто» розповідає про багатогранну людську природу. У глухому містечку Бьорнстад колись вирувало життя, а зараз лишилось безробіття та безвихідь. Уся надія міста – юнацький хокейний клуб.",
                            ImageUrl = "/proxy/assets/images/місто.png",
                            Price = 385,
                            Title = "Ведмеже місто"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
