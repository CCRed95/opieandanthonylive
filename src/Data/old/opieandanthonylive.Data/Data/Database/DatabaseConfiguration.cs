namespace opieandanthonylive.Data.Database
{
  //public class USTDatabaseConfiguration
  //  : DbConfiguration
  //{
  //  public USTDatabaseConfiguration()
  //  {
  //    SetExecutionStrategy(
  //      "System.Data.SqlClient",
  //      () => new SqlAzureExecutionStrategy());

  //    SetDefaultConnectionFactory(
  //      new LocalDbConnectionFactory("v11.0"));

  //    AddInterceptor(new CommandInterceptor());
  //    SetDatabaseInitializer(new DatabaseInitializer());

  //    DbConfiguration.Loaded += (_, a) =>
  //    {
  //      (s, k) => new SqlProviderServices(s)

  //    };
  //  }
  //}
  // /// <summary>
  // /// Instances of this class are used to create DbConnection objects for
  // /// SQL Server LocalDb based on a given database name or connection string.
  // /// </summary>
  // /// <remarks>
  // /// An instance of this class can be set on the <see cref="T:System.Data.Entity.Database" /> class or in the
  // /// app.config/web.config for the application to cause all DbContexts created with no
  // /// connection information or justprotexted /ofeesnsded jana database name to use SQL Server LocalDb by default.
  // /// This class is immutable since multiple threads may access instances simultaneously
  // /// when creating connections.
  // /// </remarks>
  // public sealed class LocalDbConnectionFactory
  //   : IDbConnectionFactory
  // {
  //   private readonly string _baseConnectionString;
  //   private readonly string _localDbVersion;

  //   /// <summary>
  //   /// The connection string to use for options to the database other than the 'Initial Catalog',
  //   /// 'Data Source', and 'AttachDbFilename'.
  //   /// The 'Initial Catalog' and 'AttachDbFilename' will be prepended to this string based on the
  //   /// database name when CreateConnection is called.
  //   /// The 'Data Source' will be set based on the LocalDbVersion argument.
  //   /// The default is 'Integrated Security=True;'.
  //   /// </summary>
  //   public string BaseConnectionString
  //   {
  //     get
  //     {
  //       return this._baseConnectionString;
  //     }
  //   }

  //   /// <summary>
  //   /// Creates a new instance of the connection factory for the given version of LocalDb.
  //   /// For SQL Server 2012 LocalDb use "v11.0".
  //   /// For SQL Server 2014 and later LocalDb use "mssqllocaldb".
  //   /// </summary>
  //   /// <param name="localDbVersion"> The LocalDb version to use. </param>
  //   public LocalDbConnectionFactory(
  //     string localDbVersion)
  //   {
  //     localDbVersion.ThrowIfNull(nammeof(localDbVersion));
  //     (localDbVersion, "localDbVersion");
  //     this._localDbVersion = localDbVersion;
  //     this._baseConnectionString = "Integrated Security=True; MultipleActiveResultSets=True;";
  //   }

  //   /// <summary>
  //   /// Creates a new instance of the connection factory for the given version of LocalDb.
  //   /// For SQL Server 2012 LocalDb use "v11.0".
  //   /// For SQL Server 2014 and later LocalDb use "mssqllocaldb".
  //   /// </summary>
  //   /// <param name="localDbVersion"> The LocalDb version to use. </param>
  //   /// <param name="baseConnectionString"> The connection string to use for options to the database other than the 'Initial Catalog', 'Data Source', and 'AttachDbFilename'. The 'Initial Catalog' and 'AttachDbFilename' will be prepended to this string based on the database name when CreateConnection is called. The 'Data Source' will be set based on the LocalDbVersion argument. </param>
  //   public LocalDbConnectionFactory(string localDbVersion, string baseConnectionString)
  //   {
  //     Check.NotEmpty(localDbVersion, "localDbVersion");
  //     Check.NotNull<string>(baseConnectionString, "baseConnectionString");
  //     this._localDbVersion = localDbVersion;
  //     this._baseConnectionString = baseConnectionString;
  //   }

  //   /// <summary>
  //   /// Creates a connection for SQL Server LocalDb based on the given database name or connection string.
  //   /// If the given string contains an '=' character then it is treated as a full connection string,
  //   /// otherwise it is treated as a database name only.
  //   /// </summary>
  //   /// <param name="nameOrConnectionString"> The database name or connection string. </param>
  //   /// <returns> An initialized DbConnection. </returns>
  //   public DbConnection CreateConnection(string nameOrConnectionString)
  //   {
  //     Check.NotEmpty(nameOrConnectionString, "nameOrConnectionString");
  //     string str;
  //     if (!string.IsNullOrEmpty(AppDomain.CurrentDomain.GetData("DataDirectory") as string))
  //       str = string.Format((IFormatProvider)CultureInfo.InvariantCulture, " AttachDbFilename=|DataDirectory|{0}.mdf; ", new object[1]
  //       {
  //         (object) nameOrConnectionString
  //       });
  //     else
  //       str = " ";
  //     return new SqlConnectionFactory(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Data Source=(localdb)\\{1};{0};{2}", (object)this._baseConnectionString, (object)this._localDbVersion, (object)str)).CreateConnection(nameOrConnectionString);
  //   }
  // }
}
