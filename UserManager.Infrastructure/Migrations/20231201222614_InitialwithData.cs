using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialwithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    StreetAddress = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "City", "Email", "FirstName", "LastName", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0187f608-f85a-9e4d-817f-724059d9f62d"), 67, "Uptonmouth", "Tracy59@gmail.com", "Freida", "Wilderman", "Mississippi", "5069 Clementina Trail", "23448" },
                    { new Guid("0e3e9f9e-59e3-3568-edad-f720e965d029"), 29, "North Mose", "Victor.Toy@hotmail.com", "Hoyt", "Douglas", "Mississippi", "797 Jarred Walks", "64561-8961" },
                    { new Guid("10e3548d-402e-61d7-e92b-521149b3d45d"), 82, "West Jeromyfurt", "Angeline_Boyer@hotmail.com", "Rollin", "Moore", "Minnesota", "85628 Harris Village", "97088-1000" },
                    { new Guid("14d61416-5880-d8e2-a5cf-28663cfda9de"), 51, "Rosenbaumstad", "Asa70@gmail.com", "Raymond", "Prohaska", "Wisconsin", "1943 Ankunding Bypass", "09229" },
                    { new Guid("1948aa92-d588-dabd-981b-b19a8af47602"), 49, "Feltonshire", "Dahlia2@hotmail.com", "Pietro", "Lynch", "Massachusetts", "879 Ryleigh Plaza", "36871" },
                    { new Guid("1a7b3f50-d830-2680-03ef-ece3d12ec90d"), 100, "Rileychester", "Consuelo22@yahoo.com", "Garret", "Powlowski", "Utah", "38914 Lance Point", "90661-8012" },
                    { new Guid("21fe6ecb-46ab-962d-21a5-e3dac9ca3add"), 27, "Davisbury", "Mariah6@hotmail.com", "Jennie", "Jaskolski", "Indiana", "63899 Paucek Bypass", "65682-5022" },
                    { new Guid("24d30425-5188-fa7a-ee41-6783149374ee"), 58, "Conroyside", "Hollis_Waelchi18@gmail.com", "Arnoldo", "Pfeffer", "Mississippi", "03219 Wisoky Summit", "48784" },
                    { new Guid("2af1a251-2bd2-1416-80ef-a5922214fcae"), 27, "East Heber", "Maud.Walsh7@hotmail.com", "Levi", "Effertz", "Utah", "8325 D'Amore Grove", "02689-6735" },
                    { new Guid("2f020d38-892f-9eac-91e0-c5d102b7cf4d"), 88, "D'Amorebury", "Sherman.Ortiz@hotmail.com", "Dion", "Carter", "Vermont", "9479 Kellie Summit", "06953" },
                    { new Guid("301c0c32-ff0e-0796-0bd6-b2000d905d2f"), 40, "Guadalupebury", "Jerry64@gmail.com", "Mandy", "Crist", "Massachusetts", "86780 Bette Inlet", "36585-3336" },
                    { new Guid("35c1727c-2b06-f333-3f72-873bf1c2b2ae"), 57, "South Orie", "Idell.Wolf@yahoo.com", "Tierra", "O'Connell", "Missouri", "8150 Tromp Isle", "63128" },
                    { new Guid("35d841c5-6d58-e772-9f7c-ae9a83259277"), 48, "North Ali", "Stacy8@hotmail.com", "Maryam", "McGlynn", "West Virginia", "69926 Tate Unions", "79693-4502" },
                    { new Guid("3682a428-d7f5-33b3-fbbf-0949d4545a36"), 48, "North Enochton", "Leland.Lynch@yahoo.com", "Santino", "Boyle", "Maryland", "3887 Bria Orchard", "32393" },
                    { new Guid("4c6bc1d2-939a-6881-c411-56a8aecf77c9"), 76, "North Janetside", "Hilbert71@yahoo.com", "Nikolas", "Kreiger", "Tennessee", "20265 McGlynn Squares", "00260" },
                    { new Guid("5923b62f-081e-c694-1038-372d3a657ff5"), 65, "New Julian", "Gerhard15@hotmail.com", "Carlos", "Conn", "Oklahoma", "833 Eryn Port", "64107" },
                    { new Guid("5a3b33f3-bc4c-82fb-c2fe-4f80b087d04e"), 60, "Watsicastad", "Clare.Hartmann@hotmail.com", "Jody", "Quigley", "Delaware", "2770 Hobart Mall", "46944-7934" },
                    { new Guid("5fc858b7-776b-7983-648e-60f1f76ab48a"), 53, "East Malinda", "Velma_Schuster@gmail.com", "Buford", "Bernhard", "Vermont", "7469 Bailee Springs", "90698-9632" },
                    { new Guid("6175556d-0a49-cce4-3882-e67f2e5e58d4"), 69, "West Mike", "Buford.Beatty@gmail.com", "Afton", "Hoppe", "New Jersey", "954 Fisher Isle", "35087" },
                    { new Guid("633737c1-2475-189a-a374-f8702c44678d"), 85, "Kulasstad", "Irma_Stanton28@yahoo.com", "Rosamond", "Bauch", "Missouri", "354 Fahey Fields", "33368-3107" },
                    { new Guid("706cc3c5-f9c6-e009-929c-66196ff42991"), 77, "East Noeliashire", "Zola.Lebsack6@gmail.com", "Kiel", "Rohan", "Indiana", "45507 Novella Landing", "12576" },
                    { new Guid("70e448a5-87e4-af98-30b2-62e26261cb48"), 93, "New Destineychester", "Astrid_Blanda@hotmail.com", "Peggie", "Parisian", "Mississippi", "000 Gulgowski Plains", "20494-3930" },
                    { new Guid("74cbadd6-f89a-35e6-e95c-505950959399"), 100, "Donaldport", "Linnea_Bogisich58@hotmail.com", "Roger", "Fahey", "Montana", "174 Hazle Gardens", "01044" },
                    { new Guid("800b0e2f-3568-7d8c-b138-578dac02c48f"), 71, "South Jaron", "Talia97@hotmail.com", "Lawson", "Pfannerstill", "Hawaii", "591 Gregoria Vista", "69161-6668" },
                    { new Guid("8438eaaa-2fc2-a406-eaa1-ae1e2fdb3a14"), 70, "West Benedict", "William_Thompson@yahoo.com", "Brisa", "Tromp", "Idaho", "682 Ondricka Causeway", "34303" },
                    { new Guid("849a7061-fd34-fdee-a646-d93364480181"), 80, "Ciarashire", "Domenico.Larkin86@hotmail.com", "Leda", "Simonis", "Arkansas", "792 Howell Greens", "86554-2851" },
                    { new Guid("8afbd162-4b71-56f6-f15e-6642c02cd9ca"), 42, "Lake Pinkton", "Felicity87@yahoo.com", "Aubrey", "D'Amore", "North Carolina", "93591 Stehr Hollow", "69545" },
                    { new Guid("97098b68-4e3a-beb5-3263-6555b98477be"), 23, "Parisview", "Cydney_Kautzer@hotmail.com", "Joyce", "Rath", "Tennessee", "70407 Kasandra Village", "14428-8392" },
                    { new Guid("9b532d58-0a55-cca7-9f21-29142492799d"), 97, "North Izaiah", "Connie.Towne@gmail.com", "Brad", "Fay", "Georgia", "23651 Brendon Parks", "70164-8308" },
                    { new Guid("9bcd109c-7eb8-2a45-4941-1e1578451136"), 35, "Rosalindaside", "Reece_Breitenberg8@hotmail.com", "Sadye", "Mante", "Kansas", "20306 Wilfredo Street", "09992" },
                    { new Guid("9e34d92a-d8ed-0605-e1e4-35986624e9fe"), 47, "Botsfordland", "Zelda.Koepp60@yahoo.com", "Easter", "Nicolas", "North Carolina", "81417 Rohan Creek", "95911-9484" },
                    { new Guid("adcd65bb-f784-e2d8-b1e5-c866f89c5d94"), 87, "Ocieside", "Nash_Moen73@hotmail.com", "Nettie", "Lynch", "Colorado", "047 Metz Throughway", "21998-1651" },
                    { new Guid("b0e8823e-7053-cf7b-7491-0c740062c29d"), 82, "Leschstad", "Margaret_Aufderhar96@hotmail.com", "Shania", "Kertzmann", "South Carolina", "64518 Lenna Brooks", "21307-4733" },
                    { new Guid("b72c6117-a1fd-cb15-950b-a9ee3f57689e"), 77, "Allanton", "Vance_Thiel@hotmail.com", "Jarod", "Rowe", "Alaska", "65070 Ryan Meadows", "49896" },
                    { new Guid("bd2fcac5-e8d9-70f2-4810-0224f0a735bc"), 45, "Spencerville", "Sofia5@hotmail.com", "Jarrod", "Brown", "New Mexico", "88072 Cormier Lodge", "27074-4293" },
                    { new Guid("c0a95dae-4099-4e11-f8ee-c87067aa014a"), 67, "East Xzavierfort", "Brain17@hotmail.com", "Niko", "Mosciski", "Mississippi", "497 Daren Neck", "41458" },
                    { new Guid("c2c19439-3eb2-9975-0305-ac0e4c3184a1"), 82, "Handchester", "Hilton_McKenzie@gmail.com", "Gaylord", "Bruen", "Wyoming", "5962 Emard Flat", "82079-3070" },
                    { new Guid("c3186edc-6765-7dd2-2581-e2a171993eba"), 64, "Lake Antoinette", "Velma.Waelchi40@hotmail.com", "Denis", "Goodwin", "Massachusetts", "50066 Chasity Port", "86975-7488" },
                    { new Guid("cb16fed1-32ae-80ba-13c9-cc3f3473df94"), 32, "New Emely", "Fannie_Kassulke@yahoo.com", "Liam", "Lesch", "New Mexico", "16773 Lane Roads", "37933" },
                    { new Guid("dcce889e-16b2-f64f-3e20-591a4a8c54bf"), 74, "West Cielo", "Gabrielle_Spinka@yahoo.com", "Adrien", "Littel", "Arizona", "7350 Adan Trail", "21548-5117" },
                    { new Guid("dd1478e7-b80f-b009-03ca-0fa5ffffb0ef"), 34, "Hilarioport", "Kameron.Stark@gmail.com", "Xzavier", "Watsica", "Montana", "93419 Kling Course", "97935-5424" },
                    { new Guid("de22317e-3ef8-ad2f-24bd-76256ddc6b85"), 68, "Watsicaberg", "Dale.Hegmann56@hotmail.com", "Antwon", "Smith", "South Carolina", "030 Sabrina Tunnel", "14718-7981" },
                    { new Guid("e1ebca6d-8474-114a-74ac-88baaf381368"), 64, "West Amyhaven", "Asha.Schmidt@yahoo.com", "Ronaldo", "Spencer", "New Mexico", "04962 Wunsch Lakes", "85956-3574" },
                    { new Guid("e50f5076-2549-e2cd-9e32-2878669d6adb"), 32, "Claudineburgh", "Daija53@gmail.com", "Jovanny", "Pollich", "Wisconsin", "074 Eino Terrace", "42019-5037" },
                    { new Guid("e5116f06-fc57-0438-141f-0fec8b721d6e"), 41, "Schoenhaven", "Chelsea_Bechtelar25@gmail.com", "Harold", "Schowalter", "Kentucky", "70790 Nolan Court", "89371-3318" },
                    { new Guid("ea78cf86-e94b-9570-c553-00e5bb7c4d0b"), 18, "West Colleenmouth", "Minnie82@yahoo.com", "Daphney", "Klocko", "Oklahoma", "85084 VonRueden Station", "80291" },
                    { new Guid("f4090f9c-fd6c-3f10-0edb-63883b430148"), 39, "Orrinbury", "Gail72@yahoo.com", "Queenie", "Nienow", "New Hampshire", "66873 Welch Path", "62010" },
                    { new Guid("fa557abc-8680-d52a-062c-cf790b057d6e"), 57, "Lake Maximofort", "Filiberto_Morar34@gmail.com", "Colleen", "Schultz", "New Jersey", "5502 Favian Ford", "73729" },
                    { new Guid("fa849768-f01f-4ea3-bd18-2e18994490a7"), 37, "Port Amie", "Camryn45@gmail.com", "Quincy", "Predovic", "North Carolina", "18989 Frami Camp", "96882-9048" },
                    { new Guid("fb2c08e7-9eac-c54e-6573-4fe3d0127d46"), 47, "Loyalmouth", "Duncan_Kertzmann18@hotmail.com", "Grant", "Bartoletti", "Connecticut", "176 Trevion Shore", "17205" }
                });

            migrationBuilder.CreateIndex(
                name: "Id",
                table: "User",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
