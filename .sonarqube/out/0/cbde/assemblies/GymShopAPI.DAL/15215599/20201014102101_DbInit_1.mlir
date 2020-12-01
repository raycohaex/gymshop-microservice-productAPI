// Skipping function Up(none), it contains poisonous unsupported syntaxes

func @_GymShopAPI.DAL.Migrations.DbInit.Down$Microsoft.EntityFrameworkCore.Migrations.MigrationBuilder$(none) -> () loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :164 :8) {
^entry (%_migrationBuilder : none):
%0 = cbde.alloca none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :164 :37)
cbde.store %_migrationBuilder, %0 : memref<none> loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :164 :37)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :166 :12) // Not a variable of known type: migrationBuilder
%2 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :167 :22) // "Products" (StringLiteralExpression)
%3 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :166 :12) // migrationBuilder.DropTable(                  name: "Products") (InvocationExpression)
%4 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :169 :12) // Not a variable of known type: migrationBuilder
%5 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :170 :22) // "Categories" (StringLiteralExpression)
%6 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :169 :12) // migrationBuilder.DropTable(                  name: "Categories") (InvocationExpression)
%7 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :172 :12) // Not a variable of known type: migrationBuilder
%8 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :173 :22) // "Orders" (StringLiteralExpression)
%9 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :172 :12) // migrationBuilder.DropTable(                  name: "Orders") (InvocationExpression)
%10 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :175 :12) // Not a variable of known type: migrationBuilder
%11 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :176 :22) // "Users" (StringLiteralExpression)
%12 = cbde.unknown : none loc("D:\\School\\semester3\\eigenproject\\docker-dotnet-sql-test1\\GymShopAPI\\GymShopAPI.DAL\\Migrations\\20201014102101_DbInit.cs" :175 :12) // migrationBuilder.DropTable(                  name: "Users") (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
