## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Demo](#demo)
* [Setup](#setup)
* [License](#License)

## General info
This is the product service for the Gymshop project. It's requires the authorization service in order to Post, Put and Delete products from the catalog. The authorization service can be found in this <a href="#">Gitlab repository</a>.
	
## Technologies
Project is created with:
* Netcoreapp: 3.1
    * Entity framework: 3.1.9
    * MOQ: 4.14.7
    * Xunit: 2.4.0
* SonarQube: 8.5.1
* Docker 19.*

## Demo
https://gymshop-frontend.herokuapp.com/
	
## Setup
To run this project you simply navigate to the project folder and simply run: `dotnet build`

In order to configure the project correctly you will need to use a database. 
The database should be a MariaDB mysql database configured for UTF-8.
Your appsettings.json file should look like this:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DatabaseConnection": "Server=<<SERVER>>; Port=<<PORT>>; Database=<<Database Name>>; Uid=<<USER>>; pwd=<<PASSWORD>>;"
  }
}
```
You will need to run `Update-Datbase` in order to create the proper database schemes.

## Resources
* [Gymshop Wiki](https://git.fhict.nl/I426114/gymshop-api/-/wikis/%23home)
* Related projects
    * [Gymshop frontend](https://git.fhict.nl/I426114/gymshopapi-frontend)
    * [Gymshop authentication service](https://gymshop-account-service.herokuapp.com/)

## License
Copyright © 2020 Rayco Haex.

This program is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License along with this program. If not, see http://www.gnu.org/licenses/.

