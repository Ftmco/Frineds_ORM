# Frineds_ORM
SQL ORM for Cs and Fs 

# How Use : 
  
  ```
    Package Manager : 
       Install-Package FTeam.Orm -Version v
    
    dotnet CLI :
      dotnet add package FTeam.Orm --version v
      
     Package Refrence : 
      <PackageReference Include="FTeam.Orm" Version="v" />
      
     Paket CLI :
      paket add FTeam.Orm --version v
      
     Script & Interactive : 
      #r "nuget: FTeam.Orm, v"
      
     Cake : 
      // Install FTeam.Orm as a Cake Addin
      #addin nuget:?package=FTeam.Orm&version=v

      // Install FTeam.Orm as a Cake Tool
      #tool nuget:?package=FTeam.Orm&version=v
   ```
    
   NuGet Url : https://www.nuget.org/packages/fteam.orm

1.To use this ORM, you need to create a data base in any way you like. 

2.We need an example of the details of the data base connection. 

```
Code :
     DbConnectionInfo _dbConnectionInfo = 
     new(server:"",dataBase:"",authentication:Authentication.SqlServerAuthentication,userId:"",password:"")
     
      DbConnectionInfo _dbConnectionInfo = 
     new(server:"",dataBase:"",authentication:Authentication.WindowsAuthentication)
 ```
If you are using Windows authentication, there is no need for username and password 
 
3. We need an example of the information in the table.  
 
     ```
     Code :
         TableInfo _table = _dbConnectionInfo.TryTableAsync(tableName:"SqlTableName",tableType:typeof(CSharpTable));
         In addition to sql table name, we need to type table in C#
     ```
4. Now we can perform operations using table data. 

      ```
     _table.TryGetAll<Model>(); or _table.TryGetAll<Model>("MODEL.name LIKE '%param%'");
     _table.TryInsert<Model>(new(){}); or _table.TryInsert(modelInstance);
     ```
  
 Note :
    There are four modes for operations 
  
 
    Example : 
        _table.TryGetAll<Model>();
        _table.GetAll<Model>();
        _table.TryGetAllAsync<Model>();
        _table.GetAllAsync<Model>();
  
   Try modes run without Exceptions and show Exceptions with a status
  
   
    Example : 
      QueryStatus status = await _table.TryInsertAsync<Model>(new(){});
      
      Exceptions Mode :
      try{
        await _table.InsertAsync<Model>(new(){});
      }
      cath(Exception ex){
        Debug.WriteLine(ex.Message);
      }
     
