Instructions to run code:
1. Install Visual Studio 2022.
2. Ensure ASP.Net and web development workload is checked during installation.
3. Open EventPlatformApp.sln
4. Make sure the following package dependencies are installed correctly:
	- FluentNHibernate
	- Microsoft.Data.Sqlite.Core
	- NHibernate
	- NHibernate.Extensions.Sqlite
	- NHibernate.Linq

5. The skillsAssessmentEvents.db file should be present in the Data folder.
6. Clean and Build project.
7. The application uses https://localhost:7095;http://localhost:5264 as mentioned in launchSettings.json file.
   Ensure the port are available or modify to available port if required.
8. Run project using https to launch - It should successfully run the application.