# Sss.Umb9.Mutobo

Umbraco 9 based Magic Umbraco Toolbox.


1. Install .NET 5
    - Linux Enviroment (Ubuntu)
      https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu
      
    - Windows Enviroment
      https://dotnet.microsoft.com/download/dotnet/5.0
2. Clone the Repo
3. Remove existing connectionString form ./Sss.Umb9.Mutobo.Web/appSettings.json
   Before:

    "ConnectionStrings": {
    "umbracoDbDSN": "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Umbraco.mdf;Integrated Security=True"
  },
   
   After:
   
     "ConnectionStrings": {
    
  }
5. open shell 
6. cd ./Sss.Umb9.Mutobo.Web
7. dot net run
8. go to the url showed in terminal and perform the umbraco installtion
       
