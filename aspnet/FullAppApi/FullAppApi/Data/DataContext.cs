using FullAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FullAppApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        //Um eine Entitaet in der DB als tabelle zu sehen, hier als prop hinzufuegen

        public virtual DbSet<NbaPlayerViewModel> NbaPlayer => Set<NbaPlayerViewModel>();
    }
}
