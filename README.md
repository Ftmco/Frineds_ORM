# Frineds_ORM
SQL ORM and RAW SQL for Cs and Fs 

# How Use : 

1.To use this ORM, you need to create a data base in any way you like. 

2.We need an example of the details of the data base connection. 
  # DbConnectionInfo _dbConnectionInfo = new(server:"",dataBase:"",authentication:Authentication.SqlServerAuthentication,userId:"",password:"")
  #If you are using Windows authentication, there is no need for username and password 
 
3. We need an example of the information in the table. 
     #TableInfo _table = _dbConnectionInfo.TryTableAsync(tableName:"SqlTableName",tableType:typeof(CSharpTable))
     #In addition to sql table name, we need to type table in C#
     
 4. Now we can perform operations using table data. 
    # _table.TryGetAll<Model>(); or _table.TryGetAll<Model>("MODEL.name LIKE '%param%'");
    # _table.TryInsert<Model>(new(){}); or _table.TryInsert(modelInstance);
  
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
      
