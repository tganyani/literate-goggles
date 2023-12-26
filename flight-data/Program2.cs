using System;
using Microsoft.EntityFrameworkCore;


public class AirplanesDB : DbContext
{
public AirplanesDB(DbContextOptions options) : base(options)

public DbSet<Airplanes> Airplanes { get; set; }

}

public class Airplanes{
    public int Id { get; set; }
    public string Number { get; set; }
    public int Capacity { get; set; }
}


const string connectionStr = "Data Source = AirplanesDB.db";

var builder = new DbContextOptionsBuilder<AirplanesDB>()
.UseSqlite(connectionStr);

using (var db = new AirplanesDB(builder.Options))
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    for (var i = 0; i < 100; i++){
        var airplane = new Airplanes{
            Number = $"N-{i:000}",
            Capacity = i*100 +1
        }
        db.Airplanes.Add(airplane);
    }

    db.SaveChanges();
}

using (var db = new AirplanesDB(builder.Options)){
    var count = db.Airplanes.Where(a=>a.Capacity > 700).Count();
    Console.WriteLine("The Number of airplanes",count);
    foreach (var number in db.Airplanes.Where(a=>a.Capacity < 1000)
    .Select(args=>args.Number)
    ){
        Console.WriteLine(number);
    }
}

using (var db = new AirplanesDB(builder.Options)){
    
}
